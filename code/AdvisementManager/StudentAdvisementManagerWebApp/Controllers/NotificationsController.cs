﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;
using System.Web;
using AdvisementManagerSharedLibrary.DAL;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StudentAdvisementManagerWebApp.Controllers
{
    /// <summary>The notification controller class used to manage the notifications between the model and view.</summary>
    public class NotificationsController : Controller
    {

        private IList<Notification> _oNotifications = new List<Notification>();

        private NotificationDAL notificationDal;
        private StudentDal studentDal;

        /// <summary>Gets the context.</summary>
        /// <value>The context.</value>
        public ApplicationDbContext context { get; }

        /// <summary>Initializes a new instance of the <see cref="NotificationsController" /> class.</summary>
        /// <param name="context">The context.</param>
        public NotificationsController(ApplicationDbContext context)
        {
            this.context = context;
            this.notificationDal = new NotificationDAL(this.context);
            this.studentDal = new StudentDal();
        }

        /// <summary>Clears all notifications for the specified user.</summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>the view back to the current screen</returns>
        public IActionResult ClearAllNotifications(string returnUrl)
        {
            var username = Request.Cookies["StudentAdvisementManager.LoginUser"];
            var student = this.studentDal.ObtainStudentWithUsername(username, this.context);

            this.notificationDal.RemoveAllStudentNotifications(student.Id);
            this._oNotifications.Clear();
            return Redirect(returnUrl);
        }

        /// <summary>Removes the notification for the specified user.</summary>
        /// <returns>the result of the notification being removed.</returns>
        public IActionResult RemoveNotification(string returnUrl, int notificationId)
        {
            this.notificationDal.RemoveNotification(notificationId, true, false);
            return Redirect(returnUrl); ;
        }

        /// <summary>Gets the notifications for the specified user.</summary>
        /// <returns>All of the notifications for the user</returns>
        public JsonResult GetNotifications()
        {
            var user = Request.Cookies["StudentAdvisementManager.LoginUser"];
            var student = this.context.Student
                              .FirstOrDefault(loggedInAdvisor => loggedInAdvisor.UserName == user);
            var notificationDal = new NotificationDAL(this.context);

            if (student != null)
            {
                this._oNotifications = notificationDal.GetNotificationsByStudentID(student.Id, this.context);

            }
            return Json(this._oNotifications);
        }
    }
}
