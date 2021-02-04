using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerWebApp.Models
{
    /// <summary>
    ///   The Advisement session view model
    /// </summary>
    public class AdvisementSessionVM
    {
        public Student student { get; set; }

        public Advisor advisor { get; set; }
    }
}
