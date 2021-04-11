using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Models;

namespace AdvisementManagerDesktopApp.Controller
{
    /// <summary>The notification contorller for managing notifications between the model and the view</summary>
    public class NotificationController
    {
        /// <summary>Gets the notifications for the selected advisor.</summary>
        /// <param name="advisorId">The advisor identifier.</param>
        /// <returns>A list of notifications for the specific advisor.</returns>
        public List<Notification> GetNotifications(int advisorId)
        {
            var notifications = new List<Notification>();
            //TODO get notifications from DAL when it is implimented.

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
        public static List<string> GetNotificationTextData(List<Notification> notifications)
        {
            return notifications.Select(notification => notification.NotifMessage).ToList();
        }
    }
}
