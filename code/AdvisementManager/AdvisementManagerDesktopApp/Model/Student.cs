using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>Gets or sets a value indicating whether this <see cref="Student" /> is hold.</summary>
        /// <value>
        ///   <c>true</c> if hold; otherwise, <c>false</c>.</value>
        public bool Hold { get; set; }

        /// <summary>Gets or sets the meetings.</summary>
        /// <value>The meetings.</value>
        public IList<AdvisementSession> Meetings { get; set; }


    }
}
