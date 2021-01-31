using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

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
