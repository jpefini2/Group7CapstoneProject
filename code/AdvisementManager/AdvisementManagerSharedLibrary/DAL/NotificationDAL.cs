using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
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
        /// Retrieves all notifications associated with both a userID and advisorID.
        /// </summary>
        /// <param name="studentID">The studentID associated with the notifications.</param>
        /// <param name="advisorID">The advisorID associated with the notifications.</param>
        /// <param name="context">The ApplicationDBContext to use.</param>
        /// <returns></returns>
        public IList<Notification> GetNotificationsByBothID(int advisorID, int studentID, ApplicationDbContext context)
        {
            var notif = (from notification in context.Notification where notification.AdvisorId==advisorID 
                         && notification.StudentId == studentID select notification).ToList();

            return notif;
        }

        /// <summary>
        /// Retrieves all notifications associated with a given Student ID
        /// </summary>
        /// <param name="studentID">The studentID associated with the notifications.</param>
        /// <param name="context">The ApplicationDBContext to use.</param>
        /// <returns></returns>
        public IList<Notification> GetNotificationsByStudentID(int studentID, ApplicationDbContext context)
        {
            var notif = (from notification in context.Notification
                         where notification.StudentId == studentID
                         select notification).ToList();

            return notif;
        }

        /// <summary>
        /// Retrieves all notifications associated with a given AdvisorID
        /// </summary>
        /// <param name="advisorID">The advisorID associated with the notifications.</param>
        /// <param name="context">The ApplicationDBContext to use.</param>
        /// <returns></returns>
        public IList<Notification> GetNotificationsByAdvisorID(int advisorID, ApplicationDbContext context)
        {
            var notif = (from notification in context.Notification
                         where notification.AdvisorId == advisorID
                         select notification).ToList();

            return notif;
        }

        /// <summary>
        /// Retrieves a single notification given its unique ID.
        /// </summary>
        /// <param name="id">The ID of the notification.</param>
        /// <param name="context">The database context to use.</param>
        /// <returns></returns>
        public Notification GetNotificationByKeyId(int? id, ApplicationDbContext context)
        {
            var notif = (from notification in context.Notification 
                           where notification.Id == id select notification).FirstOrDefault();
            return notif;
        }

        public void DeleteNotification(int? id, ApplicationDbContext context)
        {
            var notif = this.GetNotificationByKeyId(id, context);
            context.Entry(notif).State = EntityState.Deleted;
            context.SaveChanges();

        }

        /// <summary>
        /// Adds a notification to the database.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <param name="context"></param>
        public void AddNotification(string message, int studentID, int advisorID, ApplicationDbContext context)
        {
            var notification = new Notification
            {
                NotifMessage = message,
                StudentId = studentID,
                AdvisorId = advisorID
            };
            context.Entry(notification).State = EntityState.Added;
            context.SaveChanges();
        }
    }
}
