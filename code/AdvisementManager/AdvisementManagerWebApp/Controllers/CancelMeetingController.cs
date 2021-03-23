using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using AdvisementManagerSharedLibrary.DAL;

namespace AdvisementManagerWebApp.Controllers
{
    /// <summary>Controller for the cancel meeting view page to determine whether a meeting is to be cancelled or not.</summary>
    public class CancelMeetingController : Controller
    {

        private ApplicationDbContext context { get; }
        private AdvisementSessionDAL advisementDal;

        /// <summary>Initializes a new instance of the <see cref="CancelMeetingController" /> class.</summary>
        /// <param name="context">The context.</param>
        public CancelMeetingController(ApplicationDbContext context)
        {
            this.context = context;
            advisementDal = new AdvisementSessionDAL();
        }

        /// <summary>sets up the view model for the cancel meeting page then returns the view with the view model.</summary>
        /// <param name="meetingId">The meeting identifier.</param>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>The cancel meeting page with the cancel meetings view model.</returns>
        public IActionResult CancelMeeting(int meetingId, int studentId)
        {
            var student = this.context.Student.Find(studentId);
            var meeting = this.context.AdvisementSession.Find(meetingId);
            var advisor = this.context.Advisor.Find(meeting.AdvisorId);

            var cancelMeetingVm = new CancelMeetingVM
            {
                Student = student,
                Advisor = advisor,
                Meeting = meeting
            };
            return View(cancelMeetingVm);
        }

        /// <summary>Confirms and cancels the selected meeting from the view page.</summary>
        /// <param name="user">The user.</param>
        /// <param name="meetingId">The meeting identifier.</param>
        /// <returns>Redirect to the advisement seesions page.</returns>
        public IActionResult ConfirmCancel(string user, int meetingId)
        {
            var meeting = this.context.AdvisementSession.Find(meetingId);

            advisementDal.CancelAdvisementSession(meeting, this.context);

            TempData["CancelMeetingConfirmation"] = "Meeting Canceled";
            return RedirectToAction("AdvisementSessions", "AdvisementSessions", new {userName = user});
        }
    }
}
