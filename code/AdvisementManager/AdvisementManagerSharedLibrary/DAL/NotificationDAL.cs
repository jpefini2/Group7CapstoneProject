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
                         && notification.StudentId == studentID && notification.IsRemovedFromAdvisor == false && notification.IsRemovedFromStudent == false
                         select notification).ToList();

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
                         where notification.StudentId == studentID && notification.IsRemovedFromStudent == false
                         select notification).ToList();

            return notif;
        }

        /// <summary>
        /// Retrieves all notifications associated with a given AdvisorID
        /// </summary>
        /// <param name="advisorID">The advisorID associated with the notifications.</param>
        /// <param name="context">The ApplicationDBContext to use.</param>
        /// <returns></returns>
        public List<Notification> GetNotificationsByAdvisorID(int advisorID, ApplicationDbContext context)
        {
            var notif = (from notification in context.Notification
                         where notification.AdvisorId == advisorID && notification.IsRemovedFromAdvisor == false
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

        /// <summary>
        ///     Removes a single notification
        /// </summary>
        /// <param name="id">The ID of the notification.</param>
        /// <param name="removeForStudent">If the notification should be removed for the student</param>
        /// /// <param name="removeForAdvisor">If the notification should be removed for the advisor</param>
        /// <returns></returns>
        public void RemoveNotification(int? id, bool removeForStudent, bool removeForAdvisor)
        {
            if (removeForStudent)
            {
                var notif = this.GetNotificationByKeyId(id, context);
                notif.IsRemovedFromStudent = true;

                context.Entry(notif).State = EntityState.Modified;
                context.SaveChanges();
            }

            if (removeForAdvisor)
            {
                var notif = this.GetNotificationByKeyId(id, context);
                notif.IsRemovedFromAdvisor = true;

                context.Entry(notif).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        ///     Removes all notifications for an advisor
        /// </summary>
        /// <param name="advisorId">The ID of the advisor.</param>
        /// <returns></returns>
        public void RemoveAllAdvisorNotifications(int? advisorId)
        {
            var notifs = (from notifications in context.Notification
                where notifications.AdvisorId == advisorId
                select notifications).ToList();

            foreach (var notif in notifs)
            {
                notif.IsRemovedFromAdvisor = true;
                context.Entry(notif).State = EntityState.Modified;
            }

            context.SaveChanges();
        }

        /// <summary>
        ///     Removes all notifications for a student
        /// </summary>
        /// <param name="advisorId">The ID of the student.</param>
        /// <returns></returns>
        public void RemoveAllStudentNotifications(int? studentId)
        {
            var notifs = (from notifications in context.Notification
                where notifications.StudentId == studentId
                select notifications).ToList();

            foreach (var notif in notifs)
            {
                notif.IsRemovedFromStudent = true;
                context.Entry(notif).State = EntityState.Modified;
            }

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
