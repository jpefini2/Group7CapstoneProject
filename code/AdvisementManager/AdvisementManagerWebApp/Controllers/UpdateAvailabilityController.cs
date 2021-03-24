using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;

namespace AdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The update avaliability controller for displaying and handling the page to update an advisors availability
    /// </summary>
    public class UpdateAvailabilityController : Controller
    {

        private ApplicationDbContext context { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvisementSessionsController"/> class.
        /// </summary>
        /// <param name="context">The Dbcontext.</param>
        public UpdateAvailabilityController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult UpdateAvailability(string userName)
        {
            this.createInitialTempDataIfEmpty();
            var user = this.context.Advisor
                           .FirstOrDefault(loggedInAdvisor => loggedInAdvisor.UserName == userName);

            var avilabilityVM = new AvailabilityVM{CurrentUser = user};
            
            return View(avilabilityVM);
        }

        private void createInitialTempDataIfEmpty()
        {
            var days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            foreach (var day in days)
            {
                TempData[day] ??= new List<string>();
            }
        }
        
        public IActionResult AddTime(int advisorId, string day, string startTime, string endTime)
        {
            var advisor = this.context.Advisor.Find(advisorId);
            var previousTimes = TempData.Peek(day) as IEnumerable<string>;
            var timesToAddToo = (previousTimes ?? Array.Empty<string>()).ToList();

            var timeToAdd = startTime + "-" + endTime;

            if (previousTimes == null)
            {
                timesToAddToo = new List<string>() {timeToAdd};
            }
            else
            {
                timesToAddToo.Add(timeToAdd);
            }

            TempData[day] = timesToAddToo;
            TempData["UserMessage"] = "Availability Changes have not been saved yet.";

            return RedirectToAction("UpdateAvailability", "UpdateAvailability", new { userName = advisor.UserName});
        }

        public IActionResult RemoveTime(int advisorId, string day, string timeToRemove)
        {
            var advisor = this.context.Advisor.Find(advisorId);
            var previousTimes = TempData.Peek(day) as IEnumerable<string>;
            var timesToRemoveFrom = (previousTimes ?? Array.Empty<string>()).ToList();

            timesToRemoveFrom.Remove(timeToRemove);
            TempData[day] = timesToRemoveFrom;
            TempData["UserMessage"] = "Availability Changes have not been saved yet.";

            return RedirectToAction("UpdateAvailability", "UpdateAvailability", new { userName = advisor.UserName });
        }

        public IActionResult Cancel(string userName)
        {
            TempData["UserMessage"] = "Availability Changes were not saved";
            this.emptyAvailabilityTempData();

            return RedirectToAction("AdvisementSessions", "AdvisementSessions", new { userName });
        }

        private void emptyAvailabilityTempData()
        {
            var daysOfWeek = AvailabilityVM.CreateDaysOfWeek();
            foreach (var day in daysOfWeek)
            {
                TempData.Remove(day.Text);
            }

        }

        public IActionResult Update(string userName, int advisorId)
        {
            TempData["UserMessage"] = "Availability Updated";
            this.emptyAvailabilityTempData();

            return RedirectToAction("AdvisementSessions", "AdvisementSessions", new { userName });
        }
    }
}
