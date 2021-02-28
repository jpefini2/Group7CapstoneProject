using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAdvisementManagerWebApp.Models
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

        [Column("advisorGeneralId")]
        public int generalAdvisorId { get; set; }

        [Column("advisorFacultyId")]
        public int facultyAdvisorId { get; set; }

        [Column("username")]
        public string UserName { get; set; }

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

        /// <summary> Gets a message indicating whether the student is scheduled for an advisement</summary>
        /// <value> Datetime of meeting if already scheduled</value>
        public string AdvisementSessionStatusMessage
        {
            get
            {
                if (this.hasUpcomingAdvisementSession())
                {
                    return "Meeting at " + this.Meeting.Date;
                }
                else
                {
                    if (this.Meeting == null || this.Meeting.Completed)
                    {
                        return "No meeting scheduled.";
                    }
                    else
                    {
                        return "Meeting awaiting approval.";
                    }
                }
            }
        }

        /// <summary>
        /// Returns if the student has an upcoming meeting;
        /// </summary>
        /// <returns>bool of if the student has an upcoming meeting</returns>
        private bool hasUpcomingAdvisementSession()
        {
            return this.Meeting != null && DateTime.Compare(this.Meeting.Date, DateTime.Now) > 0;
        }

        /// <summary>
        /// Returns if the student's latest meeting is incomplete.
        /// </summary>
        /// <returns>bool of if the student's latest meeting is incomplete</returns>
        private bool isLastMeetingIncomplete()
        {
            return this.Meeting != null && !this.Meeting.Completed;
        }

        /// <summary>
        /// Returns if the student is ready to schedule a meeting;
        /// </summary>
        /// <returns>bool of if the student is ready to schedule a meeting</returns>
        public bool CanScheduleMeeting()
        {
            if (this.hasUpcomingAdvisementSession())
                return false;

            if (this.isLastMeetingIncomplete())
                return false;

            return this.Hold.Reason.ToLower() == "need to meet with dept advisor" || this.Hold.Reason.ToLower() == "need to meet with faculty advisor";
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.FullName;
        }
    }
}
