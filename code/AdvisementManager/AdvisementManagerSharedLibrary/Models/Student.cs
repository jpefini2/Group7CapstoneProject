using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvisementManagerSharedLibrary.Models
{
    /// <summary>
    ///   The student class for managing a student in the system.
    /// </summary>
    public class Student : IValidatableObject
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
        [StringLength(25, ErrorMessage = "First name must be between 2 and 25 characters.", MinimumLength = 2)]
        [Required(ErrorMessage = "Must provide a first name.")]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name of the student.</summary>
        /// <value>The last name.</value>
        [Display(Name = "Last Name")]
        [Column("lastName")]
        [StringLength(25, ErrorMessage = "Last name must be between 2 and 25 characters.", MinimumLength = 2)]
        [Required(ErrorMessage = "Must provide a last name.")]
        public string LastName { get; set; }

        /// <summary>Gets or sets the email of the student.</summary>
        /// <value>The email.</value>
        [Display(Name = "Email")]
        [Column("email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must input a valid email address.")]
        [Required(ErrorMessage = "Must provide an email address.")]
        public string Email { get; set; }

        [Column("gender")]
        [Required(ErrorMessage = "Must select a gender.")]
        public string Gender { get; set; }

        /// <summary>Gets or sets the general advisors id assigned to the current student.</summary>
        /// <value>The general advisor identifier.</value>
        [Column("advisorGeneralId")]
        [Required(ErrorMessage = "Must select a general advisor.")]
        public int generalAdvisorId { get; set; }

        /// <summary>Gets or sets the faculty advisor id assigned to the current student.</summary>
        /// <value>The faculty advisor identifier.</value>
        [Column("advisorFacultyId")]
        [Required(ErrorMessage = "Must select a faculty advisor.")]
        public int facultyAdvisorId { get; set; }

        /// <summary>Gets or sets the general advisor assigned to the student.</summary>
        /// <value>The general advisor.</value>
        [NotMapped]
        public Advisor GeneralAdvisor { get; set; }

        /// <summary>Gets or sets the faculty advisor assigned to the student.</summary>
        /// <value>The faculty advisor.</value>
        [NotMapped]
        public Advisor FacultyAdvisor { get; set; }

        [NotMapped]
        [StringLength(20, ErrorMessage = "Password must be between 2 and 20 characters.", MinimumLength = 2)]
        [Required(ErrorMessage = "Must provide a password.")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Must confirm your password.")]
        public string ConfirmPassword { get; set; }

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

        [Column("username")]
        [StringLength(20, ErrorMessage = "Username must be between 2 and 20 characters.", MinimumLength = 2)]
        [Required(ErrorMessage = "Must provide a username.")]
        public string UserName { get; set; }

        /// <summary> Gets the Student's full name</summary>
        /// <value> FirstName + " " + LastName</value>
        public string FullName => this.FirstName + " " + LastName;

        /// <summary> Gets a message describing the students advisement status</summary>
        /// <value> Incomplete or Complete and Hold reeason if incomplete</value>
        public string AdvisementStatusMessage
        {
            get
            {
                if (this.Hold == null)
                {
                    return "No hold found";
                }
                else if (this.Hold.IsActive)
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ConfirmPassword != Password)
            {
                yield return new ValidationResult("Passwords do not match.");
            }
        }
    }
}
