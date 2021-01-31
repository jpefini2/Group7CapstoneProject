using System;
using System.Collections.Generic;

namespace AdvisementManagerWebApp.Models
{
    public partial class LoginUserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
