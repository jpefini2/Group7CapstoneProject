using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.DAL
{
    /// <summary>
    /// Data access layer class for creating and retrieving notifications from the server.
    /// </summary>
    public class NotificationDAL
    {
        ApplicationDbContext context;
        public NotificationDAL(ApplicationDbContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Retrieves all notifications associated with a given email.
        /// </summary>
        /// <param name="email">The email associated with the notifications.</param>
        /// <param name="context">The ApplicationDBContext to use.</param>
        /// <returns></returns>
        public IList<Notification> GetNotificationsByEmail(string email, ApplicationDbContext context)
        {
            var notif = (from notification in context.Notification 
                           where notification.Email.Equals(email) select notification).ToList();

            return notif;
        }

        /// <summary>
        /// Retrieves a single notification given its unique ID.
        /// </summary>
        /// <param name="id">The ID of the notification.</param>
        /// <param name="context">The database context to use.</param>
        /// <returns></returns>
        public Notification GetNotificationById(int? id, ApplicationDbContext context)
        {
            var notif = (from notification in context.Notification 
                           where notification.Id == id select notification).FirstOrDefault();
            return notif;
        }

        /// <summary>
        /// Adds a notification to the database.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public void AddNotification(string email, string message, ApplicationDbContext context)
        {
            var notification = new Notification
            {
                Email = email,
                Message = message
            };
            context.Notification.Add(notification);
        }
    }
}
