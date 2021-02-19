using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvisementManagerWebApp.Models
{
    /// <summary>
    ///   The student class for managing a student in the system.
    /// </summary>
    public class Student
    {
        /// <summary>Gets or sets the unique identifier of the student.</summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("studentID")]
        public int Id { get; set; }

        /// <summary>Gets or sets the first name of the student.</summary>
        /// <value>The first name.</value>
        [Display(Name = "First Name")]
        [Column("firstName")]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name of the student.</summary>
        /// <value>The last name.</value>
        [Display(Name = "Last Name")]
        [Column("lastName")]
        public string LastName { get; set; }

        /// <summary>Gets or sets the email of the student.</summary>
        /// <value>The email.</value>
        [Display(Name = "Email")]
        [Column("email")]
        public string Email { get; set; }

        /// <summary>Gets or sets the general advisors id assigned to the current student.</summary>
        /// <value>The general advisor identifier.</value>
        [Column("advisorGeneralId")]
        public int generalAdvisorId { get; set; }

        /// <summary>Gets or sets the faculty advisor id assigned to the current student.</summary>
        /// <value>The faculty advisor identifier.</value>
        [Column("advisorFacultyId")]
        public int facultyAdvisorId { get; set; }

        /// <summary>Gets or sets the general advisor assigned to the student.</summary>
        /// <value>The general advisor.</value>
        [NotMapped]
        public Advisor GeneralAdvisor { get; set; }

        /// <summary>Gets or sets the faculty advisor assigned to the student.</summary>
        /// <value>The faculty advisor.</value>
        [NotMapped]
        public Advisor FacultyAdvisor { get; set; }


        /// <summary>Gets or sets the hold that a student has.</summary>
        /// <value>The hold.</value>
        [NotMapped]
        public Hold Hold { get; set; }

        /// <summary>Gets or sets the meetings that a student currently has.</summary>
        /// <value>The meetings.</value>
        [NotMapped]
        public AdvisementSession Meeting { get; set; }

        /// <summary>Gets or sets the multiple meetings that a student has/had.</summary>
        /// <value>The meetings.</value>
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
                    return "No meeting scheduled";
                }
            }
        }

        /// <summary>Initializes a new instance of the <see cref="Student" />.</summary>
        public Student()
        {
            this.Meetings = new List<AdvisementSession>();
        }

        /// <summary>
        /// Returns if the student has an upcoming meeting;
        /// </summary>
        /// <returns>bool of if the student has an upcoming meeting</returns>
        private bool hasUpcomingAdvisementSession()
        {
            return this.Meeting != null;
        }

        /// <summary>converts the students full name via the ToString method.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.FullName;
        }
    }
}
