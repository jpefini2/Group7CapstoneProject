using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.Models
{
    public class Availability
    {
        /// <summary>Gets or sets the unique identifier for the availability.</summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("availabilityID")]
        public int Id { get; set; }

        /// <summary>Gets or sets the day of the week for the availability.</summary>
        /// <value>The day.</value>
        [Column("dayOfTheWeek")]
        public int DayOfTheWeek { get; set; }

        /// <summary>Gets or sets the start time for the availability.</summary>
        /// <value>The start time.</value>
        [Column("timeBegin")]
        public DateTime StartTime { get; set; }

        /// <summary>Gets or sets the end time for the availability.</summary>
        /// <value>The end time.</value>
        [Column("timeEnd")]
        public DateTime EndTime { get; set; }

        /// <summary>Gets or sets the unique identifier advisor the availability belongs to.</summary>
        /// <value>The identifier for the advisor.</value>
        [Column("advisorID")]
        public int AdvisorId { get; set; }
    }
}
