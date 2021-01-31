using AdvisementManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerWebApp.DAL
{
    public interface IAuthService
    {
        User GetUser(string username, string password);
        User GetUser(string username);
    }


    public class AuthService : IAuthService
    {
        public User GetUser(string username, string password)
        {
            UserDTO dto = new UserDTO();
            return dto.GetUser(username, password);
        }
        public User GetUser(string username)
        {
            UserDTO dto = new UserDTO();
            return dto.GetUser(username);
        }
    }
}
