using AdvisementManagerSharedLibrary.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AdvisementManagerSharedLibrary.Models
{
    /// <summary>
    ///   The Advisor class for the currently signed in advisor.
    /// </summary>
    public class Advisor : IValidatableObject
    {
        /// <summary>Gets or sets the unique identifier for the advisor.</summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("advisorID")]
        public int Id { get; set; }

        /// <summary>Gets or sets the first name for the advisor.</summary>
        /// <value>The first name.</value>
        [Column("firstName")]
        [StringLength(45, ErrorMessage = "First name must be between 2 and 45 characters.", MinimumLength = 2)]
        [Required(ErrorMessage = "Must provide a first name.")]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name for the advisor.</summary>
        /// <value>The last name.</value>
        [Column("lastName")]
        [StringLength(45, ErrorMessage = "Last name must be between 2 and 45 characters.", MinimumLength = 2)]
        [Required(ErrorMessage = "Must provide a last name.")]
        public string LastName { get; set; }

        /// <summary>Gets or sets the email for the advisor.</summary>
        /// <value>The email.</value>
        [Column("email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Must input a valid email address.")]
        [StringLength(45, ErrorMessage = "Email must be 45 characters or less.")]
        [Required(ErrorMessage = "Must provide an email address.")]
        public string Email { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is faculty advisor.</summary>
        /// <value>
        ///   <c>true</c> if this instance is faculty advisor; otherwise, <c>false</c>.</value>
        [Column("isFacultyAdvisor")]
        public bool IsFacultyAdvisor { get; set; }


        /// <summary>Gets or sets the username for the advisor.</summary>
        /// <value>The name of the user.</value>
        [Column("username")]
        [StringLength(15, ErrorMessage = "Username must be between 2 and 15 characters.", MinimumLength = 2)]
        [Required(ErrorMessage = "Must provide a username.")]
        public string UserName { get; set; }

        [Column("gender")]
        [Required(ErrorMessage = "Must select a gender.")]
        public string Gender { get; set; }

        [NotMapped]
        [StringLength(20, ErrorMessage = "Password must be between 2 and 20 characters.", MinimumLength = 2)]
        [Required(ErrorMessage = "Must provide a password.")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Must confirm your password.")]
        public string ConfirmPassword { get; set; }

        /// <summary> Gets the Advisor's full name</summary>
        /// <value> FirstName + " " + LastName</value>
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        /// <summary>Converts the advisors full name via the ToString method.</summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return this.FullName;
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ConfirmPassword != Password)
            {
                yield return new ValidationResult("Passwords do not match.");
            }
        }

    }
}
