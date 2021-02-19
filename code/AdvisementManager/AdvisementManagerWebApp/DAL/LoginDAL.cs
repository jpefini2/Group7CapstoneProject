using AdvisementManagerWebApp.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AdvisementManagerWebApp.Models;
using System.Diagnostics;
using System;
using System.Data.SqlClient;

namespace AdvisementManagerWebApp.DAL
{
    public class LoginDAL
    {
        public ApplicationDbContext context;
        public LoginDAL(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Determines if the log in information is valid.</summary>
        /// <param name="context">The database context.</param>
        /// <param name="username">The input username.</param>
        /// <param name="password">The input password.</param>
        /// <returns>True if the login information is valid, false otherwise.</returns>
        public String AttemptLogin(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return null;
            }
            try
            {
                User user = this.context.Login.Find(username);
                Advisor advisor = this.context.Advisor.First(user => user.UserName.Equals(username));
                if(advisor == null)
                {
                    return null;
                }

                string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);

                Trace.WriteLine(username + "'s password hash: " + passwordHash);

                if ( BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
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
            } catch(InvalidOperationException)
            {
                return false;
            }
        }
    }
}
