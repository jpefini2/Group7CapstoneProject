using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAdvisementManagerWebApp.Models
{
    /// <summary>
    /// Represents a User, used for authentication.
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// The username associated with this user.
        /// </summary>
        [Key]
        [Column("username")]
        public string Username { get; set; }

        /// <summary>
        /// The password hash associated with this user.
        /// </summary>
        [Column("passwordHash")]
        public string PasswordHash { get; set; }
    }
}
