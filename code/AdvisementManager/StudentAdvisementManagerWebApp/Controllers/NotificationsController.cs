using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace StudentAdvisementManagerWebApp.Controllers
{
    public class NotificationsController : Controller
    {

        private List<Notification> _oNotifications = new List<Notification>();
        public ApplicationDbContext context { get; }

        public NotificationsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Clears all notifications for the specified user.</summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns>the view back to the current screen</returns>
        public IActionResult ClearAllNotifications(string returnUrl)
        {
            //TODO start here
            this._oNotifications.Clear();
            return Redirect(returnUrl);
        }

        /// <summary>Removes the notification for the specified user.</summary>
        /// <returns>the result of the notification being removed.</returns>
        public IActionResult RemoveNotification(string returnUrl)
        {
            //TODO need to implement removing notificaiton

            return Redirect(returnUrl);
        }

        /// <summary>Gets the notifications for the specified user.</summary>
        /// <returns>All of the notifications for the user</returns>
        public JsonResult GetNotifications()
        {
            var user = Request.Cookies["AdvisementManager.LoginUser"];
            var student = this.context.Student
                              .FirstOrDefault(loggedInAdvisor => loggedInAdvisor.UserName == user);
            this._oNotifications = (from notification in this.context.Notification
                                    where notification.StudentId == student.Id
                                    select notification).ToList();
            return Json(this._oNotifications);
        }
    }
}
