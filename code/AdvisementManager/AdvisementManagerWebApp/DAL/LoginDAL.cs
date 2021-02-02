using AdvisementManagerWebApp.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AdvisementManagerWebApp.Models;

namespace AdvisementManagerWebApp.DAL
{
    public class LoginDAL
    {

        public bool isLoginValid(ApplicationDbContext context)
        {
            try
            {
                var s = context.User.FromSqlRaw("SELECT * FROM Login WHERE username = 'gsmith' AND password = 'password1'");
                s.Single();
                return true;
            }
            
            catch (System.InvalidOperationException)
            {
                return false;
            }
        }
    }
}
