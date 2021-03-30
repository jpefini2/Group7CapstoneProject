using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerDesktopApp.Model;

namespace AdvisementManagerDesktopApp.Controller
{
    public class UpdateAvailabilityController
    {
        private AvailabilityDAL availabilityDal = new();

        public Dictionary<string, IList<string>> RetrieveAdvisorCurrentAvailability(Advisor advisor)
        {
            var availability = new Dictionary<string, IList<string>>();

            var availabilityFromDb = this.availabilityDal.ObtainAvailability(advisor);
            foreach (var timeslot in availabilityFromDb)
            {
                DateTime startTime = DateTime.Today.Add(timeslot.StartTime);
                string startTimeDisplay = startTime.ToString("hh:mm tt");

                DateTime endTime = DateTime.Today.Add(timeslot.EndTime);
                string endTimeDisplay = endTime.ToString("hh:mm tt");

                WeekDay dayOfTimeslot = (WeekDay)timeslot.DayOfTheWeek;

                if (!availability.ContainsKey(dayOfTimeslot.ToString()))
                {
                    availability.Add(dayOfTimeslot.ToString(), new List<string>());
                }

                string timeSlotDisplay = startTimeDisplay + "-" + endTimeDisplay;
                availability[dayOfTimeslot.ToString()].Add(timeSlotDisplay);
            }

            return availability;
        }

        /// <summary>
        ///     Persists the selected availability.
        /// </summary>
        /// <param name="advisor">The advisor</param>
        /// <param name="timeSlots">The advisor's new availability</param>
        public void UpdateAvailability(Advisor advisor, Dictionary<string, List<string>> timeSlots)
        {
            availabilityDal.ClearAvailability(advisor);
            availabilityDal.UpdateAvailability(advisor, timeSlots);
        }
    }
}
