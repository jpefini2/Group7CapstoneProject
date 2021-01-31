using AdvisementManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerWebApp.DAL
{
    public class UserDTO
    {
        public User GetUser(string username, string password)
        {
            User u = null;
            if (username == "user1")
            {
                u = new User();
                u.Username = "user1";
                u.FirstName = "Bill";
                u.LastName = "Ross";
                u.Address = "California";
                u.Email = "bill@webtrainingroom.com";
                u.Password = "password1";
            }
            return u;
        }
        public User GetUser(string username)
        {
            User u = null;
            if (username == "user2")
            {
                u = new User();
                u.Username = "user2";
                u.FirstName = "Joey";
                u.LastName = "Hanson";
                u.Address = "California";
                u.Email = "bill@webtrainingroom.com";
                u.Password = "password1";
            }
            return u;
        }
    }
}
