using StudentAdvisementManagerWebApp.Data;
using StudentAdvisementManagerWebApp.Models;
using System;
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
        public bool AttemptLogin(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return false;
            }
            try
            {
                User user = this.context.Login.Find(username);
                Student student = this.context.Student.First(user => user.UserName.Equals(username));
                if (student == null)
                {
                    return false;
                }
                return user.Password.Equals(password);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}
