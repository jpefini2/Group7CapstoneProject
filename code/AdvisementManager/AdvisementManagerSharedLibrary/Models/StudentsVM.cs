using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.Models
{
    /// <summary>
    ///   The student VM class for passing the list of students to the view from the students in the model.
    /// </summary>
    public class StudentsVM
    {
        /// <summary>Gets or sets the students to be used.</summary>
        /// <value>The students.</value>
        public IList<Student> Students { get; set; }
    }
}
