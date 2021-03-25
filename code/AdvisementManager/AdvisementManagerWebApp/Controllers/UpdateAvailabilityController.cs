using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using AdvisementManagerSharedLibrary.DAL;

namespace AdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The update avaliability controller for displaying and handling the page to update an advisors availability
    /// </summary>
    public class UpdateAvailabilityController : Controller
    {
        private ApplicationDbContext context { get; }

        private AvailabilityDAL availabilityDal = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="AdvisementSessionsController"/> class.
        /// </summary>
        /// <param name="context">The Dbcontext.</param>
        public UpdateAvailabilityController(ApplicationDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        ///     Initializes and displays the UpdateAvailability view for the logged-in advisor
        /// </summary>
        /// <param name="userName">The advisor's username</param>
        /// <returns>The UpdateAvailability View</returns>
        public IActionResult UpdateAvailability(string userName)
        {
            var user = this.context.Advisor
                           .FirstOrDefault(loggedInAdvisor => loggedInAdvisor.UserName == userName);

            this.createInitialTempDataIfEmpty(user.Id);

            var avilabilityVM = new AvailabilityVM{CurrentUser = user};
            
            return View(avilabilityVM);
        }

        private void createInitialTempDataIfEmpty(int advisorId)
        {
            var days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

            var currentAvailability = this.availabilityDal.GetAdvisorAvailability(advisorId, this.context);
            foreach (var timeSlot in currentAvailability)
            {
                var startTime = timeSlot.StartTime.ToString("h:mm tt");
                var endTime = timeSlot.EndTime.ToString("h:mm tt");
                var day = (DayOfTheWeek)timeSlot.DayOfTheWeek;

                TempData[day.ToString()] ??= new List<string>();

                var timesOnDayEnumerator = TempData.Peek(day.ToString()) as IEnumerable<string>;
                var timesOnDayList = (timesOnDayEnumerator ?? Array.Empty<string>()).ToList();
                timesOnDayList.Add(startTime + "-" + endTime);

                TempData[day.ToString()] = timesOnDayList;
            }

            foreach (var day in days)
            {
                //TODO fill each day with a list of time slots in appropriate format
                TempData[day] ??= new List<string>();
            }
        }

        /// <summary>
        ///     Adds the provided timeslot to the tempdata and redisplays the view
        /// </summary>
        /// <param name="advisorId">The advisor's identifier</param>
        /// <param name="day">The day of the timeslot</param>
        /// <param name="startTime">The beginning of the timeslot</param>
        /// <param name="endTime">The end of the timeslot</param>
        /// <returns>The UpdateAvailability View</returns>
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

            //return RedirectToAction("UpdateAvailability", "UpdateAvailability", new { userName = advisor.UserName});
            var avilabilityVM = new AvailabilityVM { CurrentUser = advisor };
            return View("UpdateAvailability", avilabilityVM);
        }

        /// <summary>
        ///     Removes the provided timeslot from the tempdata and redisplays the view
        /// </summary>
        /// <param name="advisorId">The advisor's identifier</param>
        /// <param name="day">The day of the timeslot</param>
        /// <param name="timeToRemove">The time</param>
        /// <returns>The UpdateAvailability View</returns>
        public IActionResult RemoveTime(int advisorId, string day, string timeToRemove)
        {
            var advisor = this.context.Advisor.Find(advisorId);
            var previousTimes = TempData.Peek(day) as IEnumerable<string>;
            var timesToRemoveFrom = (previousTimes ?? Array.Empty<string>()).ToList();

            timesToRemoveFrom.Remove(timeToRemove);
            TempData[day] = timesToRemoveFrom;
            TempData["UserMessage"] = "Availability Changes have not been saved yet.";

            //return RedirectToAction("UpdateAvailability", "UpdateAvailability", new { userName = advisor.UserName});
            var avilabilityVM = new AvailabilityVM { CurrentUser = advisor };
            return View("UpdateAvailability", avilabilityVM);
        }

        /// <summary>
        ///     Returns to the Advisor's homepage
        /// </summary>
        /// <param name="userName">The advisor's username</param>
        /// <returns>Redirect to the AdvisementSessions action in AdvisementSession controller</returns>
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

        /// <summary>
        ///     Persists the advisor's selected availability to the database and
        ///     returns to the Advisor's homepage.
        /// </summary>
        /// <param name="userName">The advisor's username</param>
        /// <param name="advisorId">The advisor's id</param>
        /// <returns>The AdvisementSessions View</returns>
        public IActionResult Update(string userName, int advisorId)
        {
            var timeSlots = this.getSelectedAvailabilityTimeSlots(advisorId);
            this.availabilityDal.SetAdvisorAvailability(advisorId, timeSlots, this.context);

            TempData["UserMessage"] = "Availability Updated";
            this.emptyAvailabilityTempData();

            return RedirectToAction("AdvisementSessions", "AdvisementSessions", new { userName });
        }

        private List<Availability> getSelectedAvailabilityTimeSlots(int advisorId)
        {
            var mondayTimes = this.getSelectedAvailabilityTimeslotForDay("Monday", advisorId);
            var tuesdayTimes = this.getSelectedAvailabilityTimeslotForDay("Tuesday", advisorId);
            var wednesdayTimes = this.getSelectedAvailabilityTimeslotForDay("Wednesday", advisorId);
            var thursdayTimes = this.getSelectedAvailabilityTimeslotForDay("Thursday", advisorId);
            var fridayTimes = this.getSelectedAvailabilityTimeslotForDay("Friday", advisorId);

            var availabilityTimeSlots = mondayTimes.Concat(tuesdayTimes).Concat(wednesdayTimes).Concat(thursdayTimes).Concat(fridayTimes).ToList();
            return availabilityTimeSlots;
        }

        private List<Availability> getSelectedAvailabilityTimeslotForDay(string day, int advisorId)
        {
            var timeSlots = new List<Availability>();

            var timesResult = TempData.Peek(day) as IEnumerable<string>;
            var times = (timesResult ?? Array.Empty<string>()).ToList();
            foreach (var timeString in times)
            {
                var startAndEndTimes = timeString.Split("-");
                var startTime = DateTime.ParseExact(startAndEndTimes[0], "h:mm tt", null, System.Globalization.DateTimeStyles.None);
                var endTime = DateTime.ParseExact(startAndEndTimes[1], "h:mm tt", null, System.Globalization.DateTimeStyles.None);

                DayOfTheWeek dayEnum = (DayOfTheWeek)Enum.Parse(typeof(DayOfTheWeek), day, true);

                Availability availability = new Availability
                {
                    DayOfTheWeek = (int)dayEnum,
                    StartTime = startTime,
                    EndTime = endTime,
                    AdvisorId = advisorId,
                };

                timeSlots.Add(availability);
            }

            return timeSlots;
        }
    }
}
