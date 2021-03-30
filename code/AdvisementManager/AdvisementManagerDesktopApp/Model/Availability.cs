using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopApp.Model
{
    public class Availability
    {
        /// <summary>Gets or sets the unique identifier for the availability.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the day of the week for the availability.</summary>
        /// <value>The day.</value>
        public int DayOfTheWeek { get; set; }

        /// <summary>Gets or sets the start time for the availability.</summary>
        /// <value>The start time.</value>
        public TimeSpan StartTime { get; set; }

        /// <summary>Gets or sets the end time for the availability.</summary>
        /// <value>The end time.</value>
        public TimeSpan EndTime { get; set; }

        /// <summary>Gets or sets the unique identifier advisor the availability belongs to.</summary>
        /// <value>The identifier for the advisor.</value>
        public int AdvisorId { get; set; }
    }
}
