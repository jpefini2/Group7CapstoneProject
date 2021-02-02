using AdvisementManagerWebApp.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AdvisementManagerWebApp.Models;
using System.Diagnostics;
using System;

namespace AdvisementManagerWebApp.DAL
{
    public class LoginDAL
    {

        public bool isLoginValid(ApplicationDbContext context, string username, string password)
        {
            if(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return false;
            }
            try
            {
                var s = context.User.FromSqlRaw("SELECT * From Login Where username = '" + username + "' AND password = '" + password + "'");
                Trace.WriteLine(s);
                return s.Single().Password == password;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}
