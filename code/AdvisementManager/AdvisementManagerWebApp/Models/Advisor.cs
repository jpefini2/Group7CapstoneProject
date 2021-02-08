using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvisementManagerWebApp.Models
{
    /// <summary>
    ///   The Advisor class
    /// </summary>
    public class Advisor
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("advisorID")]
        public int Id { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        [Column("firstName")]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        [Column("lastName")]
        public string LastName { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is faculty advisor.</summary>
        /// <value>
        ///   <c>true</c> if this instance is faculty advisor; otherwise, <c>false</c>.</value>
        [Column("isFacultyAdvisor")]
        public bool IsFacultyAdvisor { get; set; }

        [Column("username")]
        public string UserName { get; set; }

        /// <summary> Gets the Advisor's full name</summary>
        /// <value> FirstName + " " + LastName</value>
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        /// <summary>Gets the available advisement session times.</summary>
        /// <value>The available advisement session times.</value>
        public IList<TimeSpan> AvailableAdvisementSessionTimes
        {
            get { return GetAvailableAdvisementSessionTimes(); }
        }

        /// <summary>Gets the available advisement session times.</summary>
        /// <returns>
        ///   The available times
        /// </returns>
        public IList<TimeSpan> GetAvailableAdvisementSessionTimes()
        {
            IList<TimeSpan> availableTimes = new List<TimeSpan>();
            TimeSpan nextAvailableTime = TimeSpan.Zero;

            for (int i = 0; i < 48; i++)
            {
                availableTimes.Add(nextAvailableTime);
                nextAvailableTime = nextAvailableTime.Add(new TimeSpan(0, 30, 0));
            }

            return availableTimes;
        }


        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.FullName;
        }
    }
}
