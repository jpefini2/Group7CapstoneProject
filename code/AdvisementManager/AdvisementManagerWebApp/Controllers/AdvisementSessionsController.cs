using Microsoft.AspNetCore.Mvc;
using AdvisementManagerWebApp.Models;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerWebApp.DAL;
using AdvisementManagerWebApp.Data;

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

        /// <summary>
        /// Advisements the sessions.
        /// </summary>
        /// <returns>
        ///     The current views students with holds
        /// </returns>
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
            if (id == null)
            {
                return NotFound();
            }

            var student =  await this.context.Student.FindAsync(id);

            student.Meeting = this.sessionDal.ObtainSession(id, this.context);
            student.Hold = this.holdDal.ObtainHold(id, this.context);

            return View(student);
        }

        /// <summary>
        /// Approves the meeting.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///     A redirection to the advisement sessions view
        /// </returns>
        public RedirectToRouteResult ApproveMeeting(int? id)
        {
            const string approvalReason = "Student has met with faculty advisor hold pending removal.";
            var hold = this.context.Hold.First(holdToFind => holdToFind.Id == id);
            hold.Reason = approvalReason;
            
            this.context.SaveChanges();

            return RedirectToRoute(new { action = "AdvisementSessions", controller = "AdvisementSessions"});
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
            hold.Reason = "No holds";
            this.context.SaveChanges();

            return RedirectToRoute(new { action = "AdvisementSessions", controller = "AdvisementSessions" });
        }
    }
}
