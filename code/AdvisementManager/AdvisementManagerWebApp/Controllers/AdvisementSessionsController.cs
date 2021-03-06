﻿using System;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.DAL;
using AdvisementManagerSharedLibrary.Models;
using AdvisementManagerSharedLibrary;
using AdvisementManagerWebApp.Resources;
using System.Collections.Generic;
using System.Diagnostics;

namespace AdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The Advisement Sessions Controller class for managing data between the view, model and DAL.
    /// </summary>
    public class AdvisementSessionsController : Controller
    {
        /// <summary>Gets the Dbcontext for editing and pulling information in the database.</summary>
        /// <value>The Dbcontext.</value>
        public ApplicationDbContext context { get; }
        private readonly StudentDal studentDal = new();
        private readonly HoldDAL holdDal = new();
        private readonly AdvisementSessionDAL sessionDal= new();
        private readonly AdvisorDAL advisorDal = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvisementSessionsController"/> class.
        /// </summary>
        /// <param name="context">The Dbcontext.</param>
        public AdvisementSessionsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Obtains a list of students that have holds.
        /// Returns a page back to the user with the results. This
        /// should not be used to gather a list of students for a
        /// different advisor than the one that is assigned to the advisor.</summary>
        /// <returns>The current views students with holds</returns>
        public IActionResult AdvisementSessions()
        {
            var user = this.context.Advisor
                           .FirstOrDefault(loggedInAdvisor => loggedInAdvisor.UserName == Request.Cookies["AdvisementManager.LoginUser"]);

            var studentsWithHolds = this.studentDal.ObtainStudentsWithHolds(this.context, user);
            var upcomingMeetings = this.sessionDal.ObtainUpcomingSessions(this.context, user);

            var viewModel = new AdvisorHomeVM {
                StudentsWithHolds = studentsWithHolds,
                UpcomingMeetings = upcomingMeetings
            };
            return View(viewModel);
        }

        public IActionResult AdvisementSession(int? id)
        {
            var sessionVM = this.setUpAdvisementSessionViewModel(id);

            return View(sessionVM);
        }

        private AdvisementSessionVM setUpAdvisementSessionViewModel(int? meetingId)
        {
            var session = this.sessionDal.ObtainSessionFromId(meetingId, this.context);
            var student = this.studentDal.ObtainStudentWithId(session.StudentId, this.context);
            var advisor = this.advisorDal.ObtainAdvisorWithId(session.AdvisorId, this.context);

            var pastSessions = this.sessionDal.ObtainPastSessions(this.context, student);

            foreach (var pastSession in pastSessions)
            {
                pastSession.Advisor = this.advisorDal.ObtainAdvisorWithId(pastSession.AdvisorId, this.context);
            }

            var advisementSessionVM = new AdvisementSessionVM
            {
                sessionId = session.Id,
                student = student,
                advisor = advisor,
                Notes = session.Notes,
                meetingTime = session.Date,
                PastSessions = pastSessions
            };

            return advisementSessionVM;
        }

        /// <summary>
        ///     Gets the current advisement session for the student with the passed in Id, and the currently logged in advisor.
        ///     Sets the current advisor and student in the sessionVM and returns the view with that viewmodel to be displayed and used
        ///     in the advisement sessions page.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///     The current views student or the not found page if the id or user is null.
        /// </returns>
        public async Task<IActionResult> StudentAdvisementSummary(int? id)
        {
            var user = this.context.Advisor
                           .FirstOrDefault(loggedInAdvisor => loggedInAdvisor.UserName == Request.Cookies["AdvisementManager.LoginUser"]);
            if (id == null || user == null)
            {
                return NotFound();
            }

            var sessionVM = await this.setUpStudentAdvisementViewModel(id, user);

            return View(sessionVM);
        }

        private async Task<AdvisementSessionVM> setUpStudentAdvisementViewModel(int? id, Advisor user)
        {
            var student = await this.context.Student.FindAsync(id);
            var advisor = await this.context.Advisor.FindAsync(user.Id);

            student.Meeting = this.sessionDal.ObtainLatestIncompleteSessionFromStudent(id, this.context);
            student.Hold = this.holdDal.ObtainHold(id, this.context);

            var pastSessions = this.sessionDal.ObtainPastSessions(this.context, student);

            foreach (var session in pastSessions)
            {
                session.Advisor = this.advisorDal.ObtainAdvisorWithId(session.AdvisorId, this.context);
            }

            var sessionVM = new AdvisementSessionVM {
                student = student,
                advisor = advisor,
                PastSessions = pastSessions
            };
            return sessionVM;
        }

        [HttpPost]
        public IActionResult ApproveMeetingAndUpdateHold(int? id, string notes, int? holdId)
        {
            var session = this.sessionDal.ObtainSessionFromId(id, this.context);

            if (session.Date > DateTime.Now)
            {
                return RedirectToAdvisementSession(id);
            }

            var advisor = this.advisorDal.ObtainAdvisorWithId(session.AdvisorId, this.context);
            var student = this.studentDal.ObtainStudentWithId(session.StudentId, this.context);
            var hold = this.holdDal.ObtainHold(student.Hold.Id, this.context);

            session.Notes = notes;
            session.Completed = true;
            updateHoldReason(advisor, hold);
            this.context.SaveChanges();

            return RedirectToRoute(new { action = "AdvisementSessions", controller = "AdvisementSessions" }); ;
        }

        private RedirectToRouteResult RedirectToAdvisementSession(int? id)
        {
            TempData["MeetingTimeError"] = "Please wait until the meeting time to approve";

            var redirectRoute = RedirectToRoute(new
            {
                action = "AdvisementSession",
                controller = "AdvisementSessions",
                id
            });
            return redirectRoute;
        }

        /// <summary>
        /// Approves the meeting meeting in the DbContext then saves the changes to the database.
        /// After approval the user is redirected back to the advisementSessions page. If the time passed
        /// in is not after the current time then the user is redirected back to the current page to wait until the time has passed
        /// before being able to approve the meeting.
        /// </summary>
        /// <param name="holdId">The hold identifier.</param>
        /// <param name="time">The time.</param>
        /// <param name="advisorId">The advisor identifier.</param>
        /// <param name="meetingId">The meeting identifier.</param>
        /// <param name="notes">The notes.</param>
        /// <returns>
        /// A redirection to the advisement sessions view
        /// </returns>
        [HttpPost]
        public RedirectToRouteResult ApproveMeeting(int? holdId, DateTime? time, int advisorId, int? meetingId, string notes)
        {
            var redirectRoute = RedirectToRoute(new { action = "AdvisementSessions", controller = "AdvisementSessions" });

            if (time > DateTime.Now)
            {
                redirectRoute = this.redirectToStudentAdvisementSummaryPage(holdId);
            }
            else
            {
                var advisor = this.context.Advisor.Find(advisorId);
                var hold = this.context.Hold.First(holdToFind => holdToFind.Id == holdId);
                var session = this.context.AdvisementSession.First(sessionToFind => sessionToFind.Id == meetingId);
                session.Completed = true;
                session.Notes = notes;
                updateHoldReason(advisor, hold);

                this.context.SaveChanges();
            }

            return redirectRoute;
        }

        private RedirectToRouteResult redirectToStudentAdvisementSummaryPage(int? id)
        {
            TempData["MeetingTimeError"] = "Please wait until the meeting time to approve a student";

            var redirectRoute = RedirectToRoute(new {
                action = "StudentAdvisementSummary",
                controller = "AdvisementSessions",
                id
            });
            return redirectRoute;
        }


        private static void updateHoldReason(Advisor advisor, Hold hold)
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
        ///     Removes the hold in the DbContext with the passed in hold id by setting the IsActive flag to false in the
        ///     DbContext then updating the hold reason. Afterwords it saves the changes in the DbContext to the database
        ///     then redirects the user to the advisement sessions page. 
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
