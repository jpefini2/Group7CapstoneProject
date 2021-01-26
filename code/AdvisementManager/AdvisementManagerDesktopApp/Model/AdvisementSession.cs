using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopApp.Model
{
    /// <summary>
    ///   The advisement session class
    /// </summary>
    public class AdvisementSession
    {
        /// <summary>Gets or sets the end date.</summary>
        /// <value>The end date.</value>
        public DateTime EndDate { get; set; }

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the student.</summary>
        /// <value>The student.</value>
        public Student Student { get; set; }

        /// <summary>Gets or sets the advisor.</summary>
        /// <value>The advisor.</value>
        public Advisor Advisor { get; set; }

        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the stage.</summary>
        /// <value>The stage.</value>
        public int Stage { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="AdvisementSession" /> is completed.</summary>
        /// <value>
        ///   <c>true</c> if completed; otherwise, <c>false</c>.</value>
        public bool Completed { get; set; }



    }
}
