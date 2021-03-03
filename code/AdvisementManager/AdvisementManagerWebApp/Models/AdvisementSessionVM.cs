using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerWebApp.Models
{
    /// <summary>
    ///   The Advisement session view model for passing session information to the view from the model classes that come together to
    ///   make up the view.
    /// </summary>
    public class AdvisementSessionVM
    {
        /// <summary>Gets or sets the student doe this session</summary>
        /// <value>The student.</value>
        public Student student { get; set; }

        /// <summary>Gets or sets the advisor for this session</summary>
        /// <value>The advisor.</value>
        public Advisor advisor { get; set; }

        /// <summary>Gets or sets the notes.</summary>
        /// <value>The notes.</value>
        public string Notes { get; set; }

        /// <summary>Gets or sets the past sessions.</summary>
        /// <value>The past sessions.</value>
        public IList<AdvisementSession> PastSessions { get; set; }
    }
}
