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
        public bool AttemptLogin(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return false;
            }
            try
            {
                User user = this.context.Login.Find(username);
                
                return user != null;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}
