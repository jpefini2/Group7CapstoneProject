using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.Models
{
    /// <summary>
    ///   The Adisor Home VM class for passing the lists of students with holds and advisor's upcoming meetings
    ///   to the view from the controller.
    /// </summary>
    public class AdvisorHomeVM
    {
        /// <summary>Gets or sets the students with holds</summary>
        /// <value>The students.</value>
        public IList<Student> Students { get; set; }

        /// <summary>Gets or sets the advisor's upcoming meetings</summary>
        /// <value>The upcoming meetings.</value>
        public IList<AdvisementSession> UpcomingMeetings { get; set; }
    }
}
