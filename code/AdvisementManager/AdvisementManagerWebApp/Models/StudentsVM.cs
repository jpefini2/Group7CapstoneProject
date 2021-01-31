using System.Collections.Generic;

namespace AdvisementManagerWebApp.Models
{
    /// <summary>
    ///   The student VM class
    /// </summary>
    public class StudentsVM
    {
        /// <summary>Gets or sets the students.</summary>
        /// <value>The students.</value>
        public IList<Student> Students { get; set; }
    }
}
