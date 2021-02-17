using StudentAdvisementManagerWebApp.Data;
using StudentAdvisementManagerWebApp.Models;
using System;
using System.Diagnostics;
using System.Linq;

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
                Student student = this.context.Student.First(user => user.UserName.Equals(username));
                if (student == null)
                {
                    return null;
                }

                string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password, salt);

                Trace.WriteLine(username + "'s password hash: " + passwordHash);

                if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
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
            Models.LoginSession loginSession = new Models.LoginSession
            {
                Username = username,
                SessionKey = hash,
                ExpirationDate = DateTime.Now.AddMinutes(60)
            };

            //this.context.LoginSession.Add(loginSession);
            //return VerifyCurrentSession(this.context, username, hash);
            return true;
        }
    }
}
