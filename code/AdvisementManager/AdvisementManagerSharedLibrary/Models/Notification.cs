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

        /// <summary>Gets or sets the email tied to this notification.</summary>
        /// <value>The user's email.</value>
        [Column("email")]
        public string Email { get; set; }

        /// <summary>Gets or sets the message associated with this notification.</summary>
        /// <value>The message.</value>
        [Column("message")]
        public string Message { get; set; }
    }
}
