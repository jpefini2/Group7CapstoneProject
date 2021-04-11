using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerSharedLibrary.Models;

namespace AdvisementManagerDesktopApp.Controller
{
    /// <summary>The notification contorller for managing notifications between the model and the view</summary>
    public class NotificationController
    {
        /// <summary>Gets the notifications for the selected advisor.</summary>
        /// <param name="advisorId">The advisor identifier.</param>
        /// <returns>A list of notifications for the specific advisor.</returns>
        public IList<Notification> GetNotifications(int advisorId)
        {
            IList<Notification> notifications = new List<Notification>();
            NotificationDal notificationDal = new NotificationDal();
            notifications = notificationDal.GetNotificationsByAdvisorID(advisorId);

            return notifications;
        }

        /// <summary>Removes all notifications for the specified advisor.</summary>
        public void RemoveAllNotifications()
        {
            //TODO need to remove all notifications once the DAL method is set up.
        }

        /// <summary>Gets the notification text data.</summary>
        /// <param name="notifications">The notifications.</param>
        /// <returns>all of the notification messages in the list of notifications.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static List<string> GetNotificationTextData(IList<Notification> notifications)
        {
            return notifications.Select(notification => notification.NotifMessage).ToList();
        }
    }
}
