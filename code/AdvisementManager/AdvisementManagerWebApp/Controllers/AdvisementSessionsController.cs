using Microsoft.AspNetCore.Mvc;
using AdvisementManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerWebApp.DAL;
using AdvisementManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvisementManagerWebApp.Controllers
{
    public class AdvisementSessionsController : Controller
    {
        private readonly ApplicationDbContext context;

        private readonly StudentDal studentDal = new();

        private readonly HoldDAL holdDal = new();

        private readonly AdvisementSessionDAL sessionDal= new();
        
        public AdvisementSessionsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult AdvisementSessions()
        {

            var students = this.studentDal.ObtainStudentsWithHolds(this.context);

            var studentsWithHolds = new StudentsVM {
                Students = students
            };

            return View(studentsWithHolds);
        }

        public async Task<IActionResult> AdvisementSession(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student =  await this.context.Student.FindAsync(id);

            student.Meeting = this.sessionDal.ObtainSession(id, this.context);
            student.Hold = this.holdDal.ObtainHold(id, this.context);

            return View(student);
        }

        public RedirectToRouteResult ApproveMeeting(int? id)
        {
            const string approvalReason = "Student has met with faculty advisor hold pending removal.";
            var hold = this.context.Hold.First(holdToFind => holdToFind.Id == id);
            hold.Reason = approvalReason;
            
            this.context.SaveChanges();

            return RedirectToRoute(new { action = "AdvisementSessions", controller = "AdvisementSessions"});
        }

        public RedirectToRouteResult RemoveHold(int? id)
        {
            var hold = this.context.Hold.First(holdToFind => holdToFind.Id == id);

            hold.IsActive = false;
            hold.Reason = "No holds";
            this.context.SaveChanges();

            return RedirectToRoute(new { action = "AdvisementSessions", controller = "AdvisementSessions" });
        }
    }
}
