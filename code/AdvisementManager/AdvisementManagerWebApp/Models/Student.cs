using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvisementManagerWebApp.Models
{
    /// <summary>
    ///   The student class
    /// </summary>
    public class Student
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("studentID")]
        public int Id { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        [Display(Name = "First Name")]
        [Column("firstName")]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        [Display(Name = "Last Name")]
        [Column("lastName")]
        public string LastName { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [Display(Name = "Email")]
        [Column("email")]
        public string Email { get; set; }

        /// <summary>Gets or sets the general advisor.</summary>
        /// <value>The general advisor.</value>
        [NotMapped]
        public Advisor GeneralAdvisor { get; set; }

        /// <summary>Gets or sets the faculty advisor.</summary>
        /// <value>The faculty advisor.</value>
        [NotMapped]
        public Advisor FacultyAdvisor { get; set; }


        /// <summary>Gets or sets the hold.</summary>
        /// <value>The hold.</value>
        [NotMapped]
        public Hold Hold { get; set; }

        /// <summary>Gets or sets the meetings.</summary>
        /// <value>The meetings.</value>
        [NotMapped]
        public AdvisementSession Meeting { get; set; }

        [NotMapped]
        public IList<AdvisementSession> Meetings { get; set; }

        /// <summary> Gets the Student's full name</summary>
        /// <value> FirstName + " " + LastName</value>
        public string FullName => this.FirstName + " " + LastName;

        /// <summary> Gets a message describing the students advisement status</summary>
        /// <value> Incomplete or Complete and Hold reeason if incomplete</value>
        public string AdvisementStatusMessage
        {
            get
            {
                if (this.Hold.IsActive)
                {
                    return "Incomplete - " + this.Hold.Reason;
                }
                else
                {
                    return "Complete";
                }
            }
        }

        /// <summary> Gets a message indicating whether the student is scheduled for an advisement/summary>
        /// <value> Datetime of meeting if already scheduled</value>
        public string AdvisementSessionStatusMessage
        {
            get
            {
                DateTime? upcomingMeetingTime = this.hasUpcomingAdvisementSession();

                if (upcomingMeetingTime.HasValue)
                {
                    return "Meeting at " + upcomingMeetingTime.ToString();
                }
                else
                {
                    return "No meeting scheduled";
                }
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Student" /> class.</summary>
        public Student()
        {
            this.Meetings = new List<AdvisementSession>();
        }

        /// <summary>
        /// Returns the dateTime of the students upcoming meeting, if there are any.
        /// </summary>
        /// <returns>DateTime of meeting if havent passed yet, null if all have passed</returns>
        private DateTime? hasUpcomingAdvisementSession()
        {
            foreach (var meeting in this.Meetings)
            {
                if (meeting.Date.CompareTo(DateTime.Now) == -1)
                {
                    return meeting.Date;
                }
            }

            return null;
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.FullName;
        }
    }
}
