using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.Models
{
    /// <summary>
    ///   The holds class for managing a students hold
    /// </summary>
    public class Hold
    {
        /// <summary>Gets or sets the unique identifier for the hold.</summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("holdID")]
        public int Id { get; set; }

        /// <summary>Gets or sets the reason for the hold.</summary>
        /// <value>The reason.</value>
        [Column("reason")]
        public string Reason { get; set; }

        /// <summary>Gets or sets the date the hold as applied.</summary>
        /// <value>The date.</value>
        [Column("dateAdded")]
        public DateTime Date { get; set; }

        /// <summary>Gets or sets a value indicating whether the hold is active.</summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.</value>
        [Column("isActive")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the studentID associated with this hold.
        /// </summary>
        /// <value>The studentID</value>
        [Column("studentID")]
        public int StudentId { get; set; }

        /// <summary>
        /// Gets the string that represents this Hold.
        /// </summary>
        /// <returns>A string representing this Hold.</returns>
        public override string ToString()
        {
            if (this.IsActive)
            {
                return "Hold: " + this.Reason;
            }
            else
            {
                return "No Hold";
            }
        }
    }
}
