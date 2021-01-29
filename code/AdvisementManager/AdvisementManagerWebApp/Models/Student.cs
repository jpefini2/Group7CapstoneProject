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

        public override string ToString()
        {
            return "Student: " + this.FirstName + " " + this.LastName;
        }
    }
}
