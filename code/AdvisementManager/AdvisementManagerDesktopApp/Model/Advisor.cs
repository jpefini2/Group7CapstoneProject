using System.Collections.Generic;

namespace AdvisementManagerDesktopApp.Model
{
    /// <summary>
    ///   The Advisor class the currently signed in advisor.
    /// </summary>
    public class Advisor
    {
        /// <summary>Gets or sets the unique identifier for the advisor.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the first namef or the advisor.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name for the advisor.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>Gets or sets the email for the advisor.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is faculty advisor.</summary>
        /// <value>
        ///   <c>true</c> if this instance is faculty advisor; otherwise, <c>false</c>.</value>
        public bool IsFacultyAdvisor { get; set; }

        /// <summary>Gets or sets the students.</summary>
        /// <value>The students.</value>
        public IList<Student> Students { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;
    }
}
