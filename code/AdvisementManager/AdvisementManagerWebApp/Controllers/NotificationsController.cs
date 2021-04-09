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

namespace AdvisementManagerWebApp.Controllers
{
    public class NotificationsController : Controller
    {

        private List<Notification> _oNotifications = new List<Notification>();
        /// <summary>Gets the context.</summary>
        /// <value>The context.</value>
        public ApplicationDbContext context { get; }

        /// <summary>Initializes a new instance of the <see cref="NotificationsController" /> class.</summary>
        /// <param name="context">The context.</param>
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
            return Redirect("returnUrl");
        }

        /// <summary>Removes the notification for the specified user.</summary>
        /// <returns>the result of the notification being removed.</returns>
        public JsonResult RemoveNotification()
        {
            //TODO need to implement removing notificaiton

            return Json(this._oNotifications);
        }

        /// <summary>Gets the notifications for the specificd user.</summary>
        /// <returns>All of the notifications for the user</returns>
        public JsonResult GetNotifications()
        {
            var user = Request.Cookies["AdvisementManager.LoginUser"];
            var advisor = this.context.Advisor
                              .FirstOrDefault(loggedInAdvisor => loggedInAdvisor.UserName == user);
            this._oNotifications = (from notification in this.context.Notification
                                    where notification.AdvisorId == advisor.Id
                                    select notification).ToList();
            return Json(this._oNotifications);
        }
    }
}
