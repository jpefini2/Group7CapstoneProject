using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentAdvisementManagerWebApp.Models
{
    /// <summary>
    ///   The schedule advisement model
    /// </summary>
    public class ScheduleAdvisementModel
    {
        /// <summary>Gets or sets the student.</summary>
        /// <value>The student.</value>
        public Student Student { get; set; }

        /// <summary>Gets or sets the advisor.</summary>
        /// <value>The advisor.</value>
        public Advisor Advisor { get; set; }

        /// <summary>Gets the student identifier.</summary>
        /// <value>The student identifier.</value>
        public int StudentId
        {
            get { return Student.Id; }
        }

        /// <summary>Gets the advisor identifier.</summary>
        /// <value>The advisor identifier.</value>
        public int AdvisorId
        {
            get { return Advisor.Id; }
        }

        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        [BindProperty(SupportsGet = true)]
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the time.</summary>
        /// <value>The time.</value>
        [BindProperty(SupportsGet = true)]
        public TimeSpan Time { get; set; }

        /// <summary>Gets or sets the available session times.</summary>
        /// <value>The available session times.</value>
        public IList<SelectListItem> AvailableSessionTimes { get; set; }

        public bool IsSessionTimeValid
        {
            get 
            {
                var sessionTime = this.Date.AddMinutes(this.Time.TotalMinutes);
                return DateTime.Compare(sessionTime, DateTime.Now) < 0;
            }
        }


        /// <summary>Sets the available session times list items.</summary>
        /// <param name="advisor">The advisor.</param>
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
