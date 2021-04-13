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
        [Key]
        [Column("notificationID")]
        public int Id { get; set; }

        /// <summary>Gets or sets studentID tied to this notification.</summary>
        /// <value>The advisorID.</value>
        [Column("studentID")]
        public int StudentId { get; set; }

        /// <summary>Gets or sets the advisorID tied to this notification.</summary>
        /// <value>The advisorID.</value>
        [Column("advisorID")]
        public int AdvisorId { get; set; }

        /// <summary>Gets or sets the message associated with this notification.</summary>
        /// <value>The message.</value>
        [Column("isRemovedFromAdvisor")]
        public bool IsRemovedFromAdvisor { get; set; }

        [Column("isRemovedFromStudent")]
        public bool IsRemovedFromStudent { get; set; }

        [Column("notifMessage")]
        public string NotifMessage { get; set; }
    }
}
