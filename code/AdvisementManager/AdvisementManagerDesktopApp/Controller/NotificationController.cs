using System;
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
        private readonly NotificationDal notificationDal = new();

        /// <summary>Gets the notifications for the selected advisor.</summary>
        /// <param name="advisorId">The advisor identifier.</param>
        /// <returns>A list of notifications for the specific advisor.</returns>
        public List<Notification> GetNotifications(int advisorId)
        {
            NotificationDal notificationDal = new NotificationDal();
            var notifications = notificationDal.GetNotificationsByAdvisorID(advisorId).ToList();

            return notifications;
        }

        /// <summary>Removes all notifications for the specified advisor.</summary>
        public void RemoveAllNotifications(int advisorId)
        {
            notificationDal.ClearNotifications(advisorId);
        }

        public void RemoveNotification(int id)
        {
            notificationDal.ClearNotifications(id);
        }

        /// <summary>Gets the notification text data.</summary>
        /// <param name="notifications">The notifications.</param>
        /// <returns>all of the notification messages in the list of notifications.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public static List<NotificationPanel.Model.Notification> GetPanelNotifications(List<Notification> notifications)
        {
            List<NotificationPanel.Model.Notification> panelNotifs = new List<NotificationPanel.Model.Notification>();
            foreach (var notif in notifications)
            {
                var panelNotif = new NotificationPanel.Model.Notification()
                {
                    Id = notif.Id,
                    NotifMessage = notif.NotifMessage
                };
                panelNotifs.Add(panelNotif);
            }

            return panelNotifs;
        }
    }
}
