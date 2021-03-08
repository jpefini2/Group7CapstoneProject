using System;

namespace AdvisementManagerDesktopApp.Model
{
    /// <summary>The advisement session class for managing meetings</summary>
    public class AdvisementSession
    {
        /// <summary>Gets or sets the end date of the session.</summary>
        /// <value>The end date.</value>
        public DateTime EndDate { get; set; }

        /// <summary>Gets or sets the unique identifier for the session.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the student the session is for.</summary>
        /// <value>The student.</value>
        public Student Student { get; set; }

        /// <summary>
        ///   Gets or sets the student identifier.
        /// </summary>
        /// <value>The student identifier.</value>
        public int StudentID { get; set; }

        /// <summary>Gets or sets the advisor the session is for.</summary>
        /// <value>The advisor.</value>
        public Advisor Advisor { get; set; }

        /// <summary>
        ///   Gets or sets the advisor identifier.
        /// </summary>
        /// <value>The advisor identifier.</value>
        public int AdvisorID { get; set; }

        /// <summary>Gets or sets the hold identifier.</summary>
        /// <value>The hold identifier.</value>
        public int HoldID { get; set; }

        /// <summary>Gets or sets the hold.</summary>
        /// <value>The hold.</value>
        public Hold Hold { get; set; }

        /// <summary>Gets or sets the date the session is to be held.</summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the stage the session is in.</summary>
        /// <value>The stage.</value>
        public int Stage { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="AdvisementSession" /> is completed.</summary>
        /// <value>
        ///   <c>true</c> if completed; otherwise, <c>false</c>.</value>
        public bool Completed { get; set; }


        /// <summary>Gets or sets the notes.</summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }
    }
}
