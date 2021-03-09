using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using AdvisementManagerSharedLibrary.Models;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.DAL;

namespace StudentAdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The Schedule advisement session controller class
    /// </summary>
    public class AdvisementSessionController : Controller
    {
        private readonly string departmentAdvisementHoldReason = "need to meet with dept advisor";

        private readonly string facultyAdvisementHoldReason = "need to meet with faculty advisor";

        public ApplicationDbContext context { get; }

        private readonly AdvisementSessionDAL sessionDal = new();
        private readonly StudentDal studentDal = new();
        private readonly AdvisorDAL advisorDal = new();
        private readonly HoldDAL holdDal = new();

        /// <summary>Initializes a new instance of the <see cref="AdvisementSessionController" /> class.</summary>
        /// <param name="context">The context.</param>
        public AdvisementSessionController(ApplicationDbContext context)
        {
            this.context = context;
            ViewBag.InvalidInputMessage = String.Empty;
        }

        /// <summary>Schedules the advisement session asynchronous.</summary>
        /// <param name="studentid">The studentid.</param>
        /// <param name="holdreason">The holdreason.</param>
        /// <param name="generaladvisorid">The generaladvisorid.</param>
        /// <param name="facultyadvisorid">The facultyadvisorid.</param>
        /// <returns>
        ///   The view to the schedule advisement session
        /// </returns>
        public IActionResult ScheduleAdvisementSession(int studentid, string holdreason, int generaladvisorid, int facultyadvisorid)
        {
            ScheduleAdvisementModel model = InitializeScheduleAdvismentModel(studentid);

            return View("../AdvisementSession/ScheduleAdvisementSession", model);
        }

        /// <summary>
        ///     Initializes the schedule advisment model. 
        ///     Determines which advisor the student must meet with and gets there available times to display.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <param name="holdreason">The holdreason.</param>
        /// <returns>
        ///   The schedule model
        /// </returns>
        private ScheduleAdvisementModel InitializeScheduleAdvismentModel(int studentId)
        {
            ScheduleAdvisementModel scheduleModel = new ScheduleAdvisementModel();
            Student student = this.studentDal.ObtainStudentWithId(studentId, this.context);

            scheduleModel.Student = student;

            if (student.Hold.Reason == this.departmentAdvisementHoldReason)
            {
                scheduleModel.Advisor = scheduleModel.Student.GeneralAdvisor;
            }
            else if (student.Hold.Reason == this.facultyAdvisementHoldReason)
            {
                scheduleModel.Advisor = scheduleModel.Student.FacultyAdvisor;
            }
            else
            {
                Debug.Print("Must add students that have standard reasons");
                scheduleModel.Advisor = scheduleModel.Student.GeneralAdvisor;
            }

            scheduleModel.SetAvailableSessionTimesListItems(scheduleModel.Student.GeneralAdvisor);
            return scheduleModel;
        }

        /// <summary>
        ///     Confirms the appointment is scheduled for a valid time and date,
        ///     returns Schedule view if not, schedules session on the database if so.
        /// </summary>
        /// <param name="studentid">The studentid.</param>
        /// <param name="advisorid">The advisorid.</param>
        /// <param name="date">The date.</param>
        /// <param name="time">The time.</param>
        /// <returns>
        ///     Redirections to the student home page, or
        ///     return Schedule view to get new dateTime.
        /// </returns>
        public IActionResult ConfirmAppointment(int? studentid, int? advisorid, DateTime date, TimeSpan time)
        {
            var sessionTime = date.AddMinutes(time.TotalMinutes);

            if (IsSessionTimeInTheFuture(sessionTime))
            {
                this.ScheduleSession(studentid.Value, advisorid.Value, sessionTime);
                return RedirectToAction("StudentHome", "Home");
            }

            ScheduleAdvisementModel scheduleModel = InitializeScheduleAdvismentModel(studentid.Value);

            ViewBag.InvalidInputMessage = "The appointment time cannot be in the past.";

            return View("../AdvisementSession/ScheduleAdvisementSession", scheduleModel);
        }

        /// <summary>Determines if the appointment time is in the future</summary>
        /// <param name="sessionTime">The date of the session.</param>
        /// <returns>
        ///   bool, if the sessionTime is in the future or not.
        /// </returns>
        private bool IsSessionTimeInTheFuture(DateTime sessionTime)
        {
            return DateTime.Compare(sessionTime, DateTime.Now) > 0;
        }

        /// <summary>Schedules the advisement session to the database.</summary>
        /// <param name="studentid">The studentid.</param>
        /// <param name="advisorid">The advisorid.</param>
        /// <param name="sessionTime">The date of the session.</param>
        private void ScheduleSession(int studentId, int advisorId, DateTime sessionTime)
        {
            AdvisementSession session = new AdvisementSession
            {
                StudentId = studentId,
                AdvisorId = advisorId,
                Date = sessionTime,
                Completed = false,
                HoldId = this.holdDal.ObtainHold(studentId, this.context).Id
            };
            this.sessionDal.ScheduleAdvisementSession(session, this.context);
        }

        public IActionResult AdvisementSessions(int? studentid, int? holdid)
        {
            var studentsSessions = this.sessionDal.ObtainPastSessionsFromIDs(this.context, studentid.Value, holdid.Value);

            foreach (var session in studentsSessions)
            {
                session.Advisor = this.advisorDal.ObtainAdvisorWithId(session.AdvisorId, this.context);
            }

            return View(studentsSessions);
        }
    }
}
