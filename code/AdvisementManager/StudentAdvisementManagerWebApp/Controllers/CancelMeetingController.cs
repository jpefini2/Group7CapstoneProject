using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;

namespace StudentAdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///The controller for the cancel meeting view page
    /// </summary>
    public class CancelMeetingController : Controller
    {
        private ApplicationDbContext context { get; }

        /// <summary>Initializes a new instance of the <see cref="CancelMeetingController" /> class.</summary>
        /// <param name="context">The context.</param>
        public CancelMeetingController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Loads the view model with the cancel meetings pages info to be used by the view</summary>
        /// <param name="meetingId">The meeting identifier.</param>
        /// <param name="studentId">The student identifier.</param>
        /// <returns>
        ///   The associated view with the cancel meeting view model.
        /// </returns>
        public IActionResult CancelMeeting(int meetingId, int studentId)
        {
            var student = this.context.Student.Find(studentId);
            var meeting = this.context.AdvisementSession.Find(meetingId);
            var advisor = this.context.Advisor.Find(meeting.AdvisorId);

            var cancelMeetingVm = new CancelMeetingVM {
                Student = student,
                Advisor = advisor,
                Meeting = meeting
            };

            return View(cancelMeetingVm);
        }

        public IActionResult ConfirmCancel(int meetingId)
        {
            //TODO add meeting cancellation binding here.

            TempData["CancelMeetingConfirmation"] = "Meeting Canceled";
            return RedirectToAction("StudentHome", "Home");
        }
    }
}
