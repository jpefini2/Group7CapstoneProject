using Microsoft.AspNetCore.Mvc;
using AdvisementManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvisementManagerWebApp.Controllers
{
    public class AdvisementSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdvisementSessionsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult AdvisementSessions()
        {
            var students = this._context.Student.FromSqlRaw("SELECT distinct student.studentID, student.firstName, student.lastName, student.email From Student INNER JOIN Hold ON Hold.studentID = Student.studentID  WHERE isActive = 1;").ToList();

            var studentsWithHolds = new StudentsVM() {
                Students = students
            };

            return View(studentsWithHolds);
        }

        public async Task<IActionResult> ViewDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
    }
}
