using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerWebApp.Controllers
{
    public class ScheduleAdvisementSessionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheduleAdvisementSessionController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> ScheduleAdvisementSessionAsync(int studentid, string holdreason, int generaladvisorid, int facultyadvisorid)
        {
            Student student = await _context.Student.FindAsync(studentid);
            Advisor generalAdvisor = await _context.Advisor.FindAsync(generaladvisorid);
            Advisor facultyAdvisor = await _context.Advisor.FindAsync(facultyadvisorid);

            student.GeneralAdvisor = generalAdvisor;
            student.FacultyAdvisor = facultyAdvisor;

            ScheduleAdvisementModel model = initializeScheduleAdvismentModel(student, holdreason);

            return View("../ScheduleAdvisementSession/ScheduleAdvisementSession", model);
        }

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

        public IActionResult ConfirmAppointment(int? studentid, int? advisorid, DateTime date, TimeSpan time)
        {
            AdvisementSession session = new AdvisementSession
            {
                StudentId = studentid.Value,
                AdvisorId = advisorid.Value,
                Date = date.AddMinutes(time.TotalMinutes),
                Completed = false
            };

            this._context.Entry(session).State = EntityState.Added;
            this._context.SaveChanges();

            return RedirectToAction("StudentHome", "Home");
        }
    }
}
