﻿using StudentAdvisementManagerWebApp.Data;
using StudentAdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using StudentAdvisementManagerWebApp.DAL;

namespace StudentAdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The Schedule advisement session controller class
    /// </summary>
    public class ScheduleAdvisementSessionController : Controller
    {
        private readonly string departmentAdvisementHoldReason = "Need to meet with dept advisor";

        private readonly string facultyAdvisementHoldReason = "Need to meet with faculty advisor";

        private readonly ApplicationDbContext context;

        private readonly ScheduleAdvisementSessionDAL scheduleDal = new();

        private readonly StudentDal studentDal = new();

        private readonly AdvisorDAL advisorDal = new();

        /// <summary>Initializes a new instance of the <see cref="ScheduleAdvisementSessionController" /> class.</summary>
        /// <param name="context">The context.</param>
        public ScheduleAdvisementSessionController(ApplicationDbContext context)
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

            return View("../ScheduleAdvisementSession/ScheduleAdvisementSession", model);
        }

        /// <summary>Initializes the schedule advisment model.</summary>
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

        /// <summary>Confirms the appointment.</summary>
        /// <param name="studentid">The studentid.</param>
        /// <param name="advisorid">The advisorid.</param>
        /// <param name="date">The date.</param>
        /// <param name="time">The time.</param>
        /// <returns>
        ///   Redirections to the student home page
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

            return View("../ScheduleAdvisementSession/ScheduleAdvisementSession", scheduleModel);
        }

        private bool IsSessionTimeInTheFuture(DateTime sessionTime)
        {
            return DateTime.Compare(sessionTime, DateTime.Now) > 0;
        }

        /// <summary>Schedules the session.</summary>
        /// <param name="studentid">The studentid.</param>
        /// <param name="advisorid">The advisorid.</param>
        /// <param name="sessionTime">The date of the session.</param>
        /// <returns>
        ///   Redirections to the student home page
        /// </returns>
        private void ScheduleSession(int studentId, int advisorId, DateTime sessionTime)
        {
            AdvisementSession session = new AdvisementSession
            {
                StudentId = studentId,
                AdvisorId = advisorId,
                Date = sessionTime,
                Completed = false
            };
            this.scheduleDal.ScheduleAdvisementSession(session, this.context);
        }
    }
}