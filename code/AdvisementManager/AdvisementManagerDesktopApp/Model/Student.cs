using System.Collections.Generic;

namespace AdvisementManagerDesktopApp.Model
{
    /// <summary>
    ///   The student class
    /// </summary>
    public class Student
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>Gets or sets the general advisor.</summary>
        /// <value>The general advisor.</value>
        public Advisor GeneralAdvisor { get; set; }

        /// <summary>Gets or sets the faculty advisor.</summary>
        /// <value>The faculty advisor.</value>
        public Advisor FacultyAdvisor { get; set; }


        /// <summary>Gets or sets the hold.</summary>
        /// <value>The hold.</value>
        public Hold Hold { get; set; }

        /// <summary>Gets or sets the meetings.</summary>
        /// <value>The meetings.</value>
        public AdvisementSession Meeting { get; set; }
    }
}
