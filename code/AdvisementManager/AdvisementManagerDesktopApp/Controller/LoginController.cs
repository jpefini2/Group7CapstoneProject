using AdvisementManagerDesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopApp.Controller
{
    class LoginController
    {
        internal bool Authenticate(string username, string password)
        {
            var loginDAL = new LoginDAL();
            return loginDAL.Authenticate(username, password);
        }

        internal void InitializeLogin(string username)
        {
            var loginDAL = new LoginDAL();
            loginDAL.LogInUser(username);
        }
    }
}
