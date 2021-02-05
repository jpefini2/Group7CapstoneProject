using StudentAdvisementManagerWebApp.Data;
using StudentAdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using StudentAdvisementManagerWebApp.DAL;

namespace StudentAdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The Schedule advisement session controller class
    /// </summary>
    public class ScheduleAdvisementSessionController : Controller
    {
        private readonly ApplicationDbContext context;

        private readonly ScheduleAdvisementSessionDAL scheduleDal = new();

        private readonly StudentDal studentDal = new();

        private readonly AdvisorDAL advisorDal = new();

        /// <summary>Initializes a new instance of the <see cref="ScheduleAdvisementSessionController" /> class.</summary>
        /// <param name="context">The context.</param>
        public ScheduleAdvisementSessionController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>Schedules the advisement session asynchronous.</summary>
        /// <param name="studentid">The studentid.</param>
        /// <param name="holdreason">The holdreason.</param>
        /// <param name="generaladvisorid">The generaladvisorid.</param>
        /// <param name="facultyadvisorid">The facultyadvisorid.</param>
        /// <returns>
        ///   The view to the schedule advisement session
        /// </returns>
        public IActionResult ScheduleAdvisementSessionAsync(int studentid, string holdreason, int generaladvisorid, int facultyadvisorid)
        {
            Student student = this.studentDal.ObtainStudentWithId(studentid, this.context);

            ScheduleAdvisementModel model = initializeScheduleAdvismentModel(student, holdreason);

            return View("../ScheduleAdvisementSession/ScheduleAdvisementSession", model);
        }

        /// <summary>Initializes the schedule advisment model.</summary>
        /// <param name="student">The student.</param>
        /// <param name="holdreason">The holdreason.</param>
        /// <returns>
        ///   The schedule model
        /// </returns>
        private ScheduleAdvisementModel initializeScheduleAdvismentModel(Student student, string holdreason)
        {
            ScheduleAdvisementModel scheduleModel = new ScheduleAdvisementModel();
            scheduleModel.Student = student;

            if (holdreason == "Student must meet with general advisor")
            {
                scheduleModel.Advisor = student.GeneralAdvisor;
            }
            else if (holdreason == "Student must meet with faculty advisor")
            {
                scheduleModel.Advisor = student.FacultyAdvisor;
            }
            else
            {
                Debug.Print("Must add students that have standard reasons");
                scheduleModel.Advisor = student.GeneralAdvisor;
            }

            scheduleModel.SetAvailableSessionTimesListItems(student.GeneralAdvisor);
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
            AdvisementSession session = new AdvisementSession
            {
                StudentId = studentid.Value,
                AdvisorId = advisorid.Value,
                Date = date.AddMinutes(time.TotalMinutes),
                Completed = false
            };

            this.scheduleDal.ScheduleAdvisementSession(session, this.context);

            return RedirectToAction("StudentHome", "Home");
        }
    }
}
