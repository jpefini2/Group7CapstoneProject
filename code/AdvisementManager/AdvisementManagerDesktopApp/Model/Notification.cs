using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.Models
{
    /// <summary>
    /// The model class for storing messages pertaining to advisement sessions.
    /// The notifications are tied to the user's email.
    /// </summary>
    public class Notification
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets studentID tied to this notification.</summary>
        /// <value>The advisorID.</value>
        public int StudentId { get; set; }

        /// <summary>Gets or sets the advisorID tied to this notification.</summary>
        /// <value>The advisorID.</value>
        public int AdvisorId { get; set; }

        /// <summary>Gets or sets the message associated with this notification.</summary>
        /// <value>The message.</value>
        public string NotifMessage { get; set; }
    }
}
