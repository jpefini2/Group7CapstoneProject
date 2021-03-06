﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.Models
{
    /// <summary>The view model for cancelling a meeting page.</summary>
    public class CancelMeetingVM
    {

        /// <summary>Gets or sets the advisor.</summary>
        /// <value>The advisor.</value>
        public Advisor Advisor { get; set; }

        /// <summary>Gets or sets the student.</summary>
        /// <value>The student.</value>
        public Student Student { get; set; }

        /// <summary>Gets or sets the meeting.</summary>
        /// <value>The meeting.</value>
        public AdvisementSession Meeting { get; set; }
    }
}
