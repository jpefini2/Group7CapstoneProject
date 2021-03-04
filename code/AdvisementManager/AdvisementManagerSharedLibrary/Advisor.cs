using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary
{
    /// <summary>
    ///   The Advisor class for the currently signed in advisor.
    /// </summary>
    public class Advisor
    {
        /// <summary>Gets or sets the unique identifier for the advisor.</summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("advisorID")]
        public int Id { get; set; }

        /// <summary>Gets or sets the first name for the advisor.</summary>
        /// <value>The first name.</value>
        [Column("firstName")]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name for the advisor.</summary>
        /// <value>The last name.</value>
        [Column("lastName")]
        public string LastName { get; set; }

        /// <summary>Gets or sets the email for the advisor.</summary>
        /// <value>The email.</value>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is faculty advisor.</summary>
        /// <value>
        ///   <c>true</c> if this instance is faculty advisor; otherwise, <c>false</c>.</value>
        [Column("isFacultyAdvisor")]
        public bool IsFacultyAdvisor { get; set; }


        /// <summary>Gets or sets the username for the advisor.</summary>
        /// <value>The name of the user.</value>
        [Column("username")]
        public string UserName { get; set; }

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
    }
}
