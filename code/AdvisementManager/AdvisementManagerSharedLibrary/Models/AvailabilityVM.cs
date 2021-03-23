using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvisementManagerSharedLibrary.Models
{
    public class AvailabilityVM
    {
        public IList<SelectListItem> DaysOfWeek { get; set; }

        public IList<SelectListItem> TimeSlots { get; set; }

        public Advisor CurrentUser { get; set; }

        public int AdvisorId
        {
            get
            {
                return this.CurrentUser.Id;
            }
        }

        [BindProperty(SupportsGet = true)]
        public string Day { get; set; }

        [BindProperty(SupportsGet = true)]
        public string StartTime { get; set; }

        [BindProperty(SupportsGet = true)]
        public string EndTime { get; set; }

        public AvailabilityVM()
        {
            this.TimeSlots = this.createTimeSlots();
            this.DaysOfWeek = this.createDaysOfWeek();
        }

        private IList<SelectListItem> createDaysOfWeek()
        {
            var days = new List<string> {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday"};
            return days.Select(day => new SelectListItem {Value = day, Text = day}).ToList();
        }

        private IList<SelectListItem> createTimeSlots()
        {
            var timeSlots = new List<SelectListItem>();
            var timeLoop = new DateTime(0);
            timeLoop = timeLoop.Add(new TimeSpan(00, 00, 0));
            const int numberOfIntervals = 48;

            for (var i = 0; i < numberOfIntervals; i++)
            {
                var time = timeLoop.ToString("h:mm tt");
                timeSlots.Add(new SelectListItem {Value = time, Text = time });
                timeLoop = timeLoop.Add(new TimeSpan(0, 30, 0));
            }

            return timeSlots;
        }
    }
}
