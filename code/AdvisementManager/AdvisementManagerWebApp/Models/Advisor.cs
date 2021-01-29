using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvisementManagerWebApp.Models
{
    /// <summary>
    ///   The Advisor class
    /// </summary>
    public class Advisor
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("advisorID ")]
        public int Id { get; set; }

        /// <summary>Gets or sets the first name.</summary>
        /// <value>The first name.</value>
        [Column("firstName ")]
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name.</summary>
        /// <value>The last name.</value>
        [Column("lastName ")]
        public string LastName { get; set; }

        /// <summary>Gets or sets the email.</summary>
        /// <value>The email.</value>
        [Column("email  ")]
        public string Email { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is faculty advisor.</summary>
        /// <value>
        ///   <c>true</c> if this instance is faculty advisor; otherwise, <c>false</c>.</value>
        [Column("isFacultyAdvisor ")]
        public bool IsFacultyAdvisor { get; set; }
    }
}
