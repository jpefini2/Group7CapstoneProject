using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Design;

namespace AdvisementManagerWebApp.Models
{
    /// <summary>
    ///   The advisement session class for managing meetings
    /// </summary>
    public class AdvisementSession
    {
        /// <summary>Gets or sets the end date of the session.</summary>
        /// <value>The end date.</value>
        [NotMapped]
        public DateTime EndDate { get; set; }

        /// <summary>Gets or sets the unique identifier for the session.</summary>
        /// <value>The identifier.</value>
        [Key]
        [Column("sessionID")]
        public int Id { get; set; }

        /// <summary>Gets or sets the student the session is for.</summary>
        /// <value>The student.</value>
        [NotMapped]
        public Student Student { get; set; }

        /// <summary>Gets or sets the studentId.</summary>
        /// <value>The advisor.</value>
        [Column("studentID")]
        public int StudentId { get; set; }

        /// <summary>Gets or sets the advisor the session is for.</summary>
        /// <value>The advisor.</value>
        [NotMapped]
        public Advisor Advisor { get; set; }

        /// <summary>Gets or sets the advisorId.</summary>
        /// <value>The advisor.</value>
        [Column("advisorID")]
        public int AdvisorId { get; set; }

        /// <summary>Gets or sets the date the session is to be held.</summary>
        /// <value>The date.</value>
        [Column("sessionDate")]
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the stage the session is in.</summary>
        /// <value>The stage.</value>
        [Column("stage")]
        public short Stage { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="AdvisementSession" /> is completed.</summary>
        /// <value>
        ///   <c>true</c> if completed; otherwise, <c>false</c>.</value>
        [Column("completed")]
        public bool Completed { get; set; }

        /// <summary>Gets or sets the notes.</summary>
        /// <value>The notes.</value>
        [Column("notes")]
        public string Notes { get; set; }

    }
}
