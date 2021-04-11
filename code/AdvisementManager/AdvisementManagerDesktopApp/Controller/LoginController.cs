using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerDesktopApp.Model;
using AdvisementManagerSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopApp.Controller
{
    class LoginController
    {   
        /// <summary>
        /// Passes the username and password to the loginDAL
        /// to check for login success.
        /// </summary>
        /// <param name="username">The username supplied by the user.</param>
        /// <param name="password">The password supplied by the user.</param>
        /// <returns></returns>
        internal static bool Authenticate(string username, string password)
        {
            var loginDAL = new LoginDAL();
            return loginDAL.Authenticate(username, password);
        }

        /// <summary>
        /// Initializes a session based on the given username.
        /// </summary>
        /// <param name="username">The user name to create a login session for.</param>
        /// <returns></returns>
        internal static Advisor InitializeLogin(string username)
        {
            var loginDAL = new LoginDAL();
            Advisor advisor = loginDAL.LogInUser(username);



            NotificationDal dal = new NotificationDal();
            IList<Notification> notifs = dal.GetNotificationsByAdvisorID(advisor.Id);

            foreach(Notification n in notifs)
            {
                Trace.WriteLine(n.NotifMessage);
            }





            return advisor;
        }
    }
}
