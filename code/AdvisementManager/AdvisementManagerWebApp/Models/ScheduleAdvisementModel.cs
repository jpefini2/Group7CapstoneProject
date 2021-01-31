using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace AdvisementManagerWebApp.Models
{
    public class ScheduleAdvisementModel
    {
        public Student Student { get; set; }

        public Advisor Advisor { get; set; }

        public int StudentId
        {
            get { return Student.Id; }
        }

        public int AdvisorId
        {
            get { return Advisor.Id; }
        }

        [BindProperty(SupportsGet = true)]
        public DateTime Date { get; set; }

        [BindProperty(SupportsGet = true)]
        public TimeSpan Time { get; set; }

        public IList<SelectListItem> AvailableSessionTimes { get; set; }

        public void SetAvailableSessionTimesListItems(Advisor advisor)
        {
            List<SelectListItem> availableTimes = new List<SelectListItem>();

            foreach (var time in advisor.AvailableAdvisementSessionTimes)
            {
                availableTimes.Add(new SelectListItem { Value = time.ToString(), Text = time.ToString() });
            }

            this.AvailableSessionTimes = availableTimes;
        }
    }
}
