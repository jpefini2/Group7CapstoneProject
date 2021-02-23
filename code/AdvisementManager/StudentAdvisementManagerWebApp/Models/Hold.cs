using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAdvisementManagerWebApp.Models
{
    /// <summary>
    ///   The holds class
    /// </summary>
    public class Hold
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("holdID")]
        public int Id { get; set; }

        /// <summary>Gets or sets the reason.</summary>
        /// <value>The reason.</value>
        [Column("reason")]
        public string Reason { get; set; }

        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        [Column("dateAdded")]
        public DateTime Date { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is active.</summary>
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
