using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAdvisementManagerWebApp.Models
{
    /// <summary>
    ///   The advisement session class
    /// </summary>
    public class AdvisementSession
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("sessionID")]
        public int Id { get; set; }

        /// <summary>Gets or sets the studentId.</summary>
        /// <value>The advisor.</value>
        [Column("studentID")]
        public int StudentId { get; set; }

        /// <summary>Gets or sets the advisorId.</summary>
        /// <value>The advisor.</value>
        [Column("advisorID")]
        public int AdvisorId { get; set; }

        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        [Column("sessionDate")]
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the stage.</summary>
        /// <value>The stage.</value>
        [Column("stage")]
        public short Stage { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="AdvisementSession" /> is completed.</summary>
        /// <value>
        ///   <c>true</c> if completed; otherwise, <c>false</c>.</value>
        [Column("completed")]
        public bool Completed { get; set; }

        /// <summary>Gets or sets the end date.</summary>
        /// <value>The end date.</value>
        [NotMapped]
        public DateTime EndDate { get; set; }

        /// <summary>Gets or sets the student.</summary>
        /// <value>The student.</value>
        [NotMapped]
        public Student Student { get; set; }

        /// <summary>Gets or sets the advisor.</summary>
        /// <value>The advisor.</value>
        [NotMapped]
        public Advisor Advisor { get; set; }
    }
}
