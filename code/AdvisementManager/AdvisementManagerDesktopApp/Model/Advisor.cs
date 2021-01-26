using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopApp.Model
{
    /// <summary>
    ///   The Advisor class
    /// </summary>
    public class Advisor
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

        /// <summary>Gets or sets a value indicating whether this instance is faculty advisor.</summary>
        /// <value>
        ///   <c>true</c> if this instance is faculty advisor; otherwise, <c>false</c>.</value>
        public bool IsFacultyAdvisor { get; set; }

        /// <summary>Gets or sets the students.</summary>
        /// <value>The students.</value>
        public IList<Student> Students { get; set; }
    }
}
