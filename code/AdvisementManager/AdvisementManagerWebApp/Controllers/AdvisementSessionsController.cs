using System;
using Microsoft.AspNetCore.Mvc;
using AdvisementManagerWebApp.Models;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerWebApp.DAL;
using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Resources;

namespace AdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The Advisement Sessions Controller class
    /// </summary>
    public class AdvisementSessionsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly StudentDal studentDal = new();
        private readonly HoldDAL holdDal = new();
        private readonly AdvisementSessionDAL sessionDal= new();

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvisementSessionsController"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public AdvisementSessionsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Obtains a list of students that have holds. 
        /// Returns a page back to the user with the results.</summary>
        /// <returns>The current views students with holds</returns>
        public IActionResult AdvisementSessions()
        {
            var students = this.studentDal.ObtainStudentsWithHolds(this.context);

            var studentsWithHolds = new StudentsVM {
                Students = students
            };
            return View(studentsWithHolds);
        }

        /// <summary>
        /// Advisements the session.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///     The current views student
        /// </returns>
        public async Task<IActionResult> AdvisementSession(int? id)
        {
            var user = this.context.Advisor
                           .FirstOrDefault(loggedInAdvisor => loggedInAdvisor.UserName == Request.Cookies["AdvisementManager.LoginUser"]);
            if (id == null || user == null)
            {
                return NotFound();
            }

            var student =  await this.context.Student.FindAsync(id);
            var advisor = await this.context.Advisor.FindAsync(user.Id);

            student.Meeting = this.sessionDal.ObtainSession(id, this.context);
            student.Hold = this.holdDal.ObtainHold(id, this.context);

            var sessionVM = new AdvisementSessionVM {
                student = student,
                advisor = advisor
            };

            return View(sessionVM);
        }

        /// <summary>
        /// Approves the meeting.
        /// </summary>
        /// <param name="holdId">The hold identifier.</param>
        /// <param name="time">The time.</param>
        /// <param name="advisorId">The advisor identifier.</param>
        /// <param name="meetingId">The meeting identifier.</param>
        /// <returns>
        /// A redirection to the advisement sessions view
        /// </returns>
        public RedirectToRouteResult ApproveMeeting(int? holdId, DateTime? time, int advisorId, int? meetingId)
        {
            var redirectRoute = RedirectToRoute(new { action = "AdvisementSessions", controller = "AdvisementSessions" });

            if (time > DateTime.Now)
            {
                redirectRoute = this.RedirectToCurrentPage(holdId);
            }
            else
            {
                var advisor = this.context.Advisor.Find(advisorId);
                var hold = this.context.Hold.First(holdToFind => holdToFind.Id == holdId);
                var session = this.context.AdvisementSession.First(sessionToFind => sessionToFind.Id == meetingId);
                session.Completed = true;
                UpdateHoldReason(advisor, hold);

                this.context.SaveChanges();
            }

            return redirectRoute;
        }

        /// <summary>
        /// Redirects to the current page.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// A redirection to the current view
        /// </returns>
        private RedirectToRouteResult RedirectToCurrentPage(int? id)
        {
            TempData["MeetingTimeError"] = "Please wait until the meeting time to approve a student";

            var redirectRoute = RedirectToRoute(new {
                action = "AdvisementSession",
                controller = "AdvisementSessions",
                id
            });
            return redirectRoute;
        }

        /// <summary>
        /// Updates the reason for the given hold.
        /// </summary>
        /// <param name="advisor">The advisor doing the updating.</param>
        /// <param name="hold">The hold to update.</param>
        private static void UpdateHoldReason(Advisor advisor, Hold hold)
        {
            if (advisor.IsFacultyAdvisor)
            {
                hold.Reason = ConstantManager.WaitingForHoldRemoval;
            }
            else
            {
                hold.Reason = ConstantManager.NeedToMeetFacAdvisor;
            }
        }

        /// <summary>
        /// Removes the hold.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///     A redirection to the advisement sessions view
        /// </returns>
        public RedirectToRouteResult RemoveHold(int? id)
        {
            var hold = this.context.Hold.First(holdToFind => holdToFind.Id == id);

            hold.IsActive = false;
            hold.Reason = ConstantManager.ReadyToRegister;
            this.context.SaveChanges();

            return RedirectToRoute(new { action = "AdvisementSessions", controller = "AdvisementSessions" });
        }
    }
}
