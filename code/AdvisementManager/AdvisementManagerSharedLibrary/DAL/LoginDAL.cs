﻿using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace AdvisementManagerSharedLibrary.DAL
{
    public enum LoginType
    {
        ADVISOR,
        STUDENT,
        ADMIN,
        NONE
    }

    public class LoginDAL
    {
        private ApplicationDbContext context;

        public ApplicationDbContext Context { get => context; set => context = value; }

        public LoginDAL(ApplicationDbContext context)
        {
            this.Context = context;
        }

        /// <summary>Determines if the log in information is valid.</summary>
        /// <param name="context">The database context.</param>
        /// <param name="username">The input username.</param>
        /// <param name="password">The input password.</param>
        /// <returns>True if the login information is valid, false otherwise.</returns>
        public String AttemptLogin(string username, string password, LoginType loginType)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return null;
            }
            try
            {
                String hash;

                if (loginType == LoginType.ADMIN)
                {
                    AdminUser user = this.Context.AdminLogin.Find(username);
                    if(user == null)
                    {
                        return null;
                    }

                    if (!user.Username.Equals(username))
                    {
                        return null;
                    }
                    hash = user.PasswordHash;
                }
                else if (loginType == LoginType.ADVISOR)
                {
                    User user = this.Context.Login.Find(username);
                    Advisor advisor = this.Context.Advisor.First(user => user.UserName.Equals(username));
                    hash = user.PasswordHash;

                    if (advisor == null)
                    {
                        return null;
                    }
                }
                else if (loginType == LoginType.STUDENT)
                {
                    User user = this.Context.Login.Find(username);
                    Student student = this.Context.Student.First(user => user.UserName.Equals(username));
                    hash = user.PasswordHash;

                    if (student == null)
                    {
                        return null;
                    }
                } else
                {
                    return null;
                }
                string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);

                Trace.WriteLine(username + "'s password hash: " + passwordHash);

                if (BCrypt.Net.BCrypt.Verify(password, hash))
                {
                    Trace.WriteLine("Returned " + passwordHash);
                    return passwordHash;
                }
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            return null;
        }

        /// <summary>Attempts to create a new session for the user.</summary>
        /// <param name="username">The input username.</param>
        /// <param name="hash">The password hash.</param>
        /// <returns>True if the the session was created, false otherwise.</returns>
        public bool createNewLoginSession(String username, String hash)
        {
            LoginSession loginSession = new LoginSession
            {
                Username = username,
                SessionKey = hash,
                ExpirationDate = DateTime.Now.AddMinutes(60)
            };

            //this.context.LoginSession.Add(loginSession);
            //return VerifyCurrentSession(this.context, username, hash);
            return true;
        }
        /// <summary>
        /// Checks the supplied username and password hash against the database.
        /// </summary>
        /// <param name="context">The DBContext</param>
        /// <param name="username">The username supplied by the user.</param>
        /// <param name="passwordHash">The password hash supplied by the user.</param>
        /// <returns>True if successfully verified, false otherwise.</returns>
        public static bool VerifyCurrentSession(ApplicationDbContext context, String username, String passwordHash)
        {
            try
            {
                LoginSession session = context.LoginSession.First(sessionUser => sessionUser.Username.Equals(username));
                if (session == null)
                {
                    return false;
                }
                return BCrypt.Net.BCrypt.Verify(session.SessionKey, passwordHash);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        public LoginType GetUserType(string username)
        {
            var advisor = context.Advisor.FirstOrDefault(sessionUser => sessionUser.UserName.Equals(username));
            var student = context.Student.FirstOrDefault(sessionUser => sessionUser.UserName.Equals(username));
            if (advisor != null)
            {
                return LoginType.ADVISOR;
            } else if (student != null)
            {
                return LoginType.STUDENT;
            }
            return LoginType.ADMIN;
        }
    }
}
