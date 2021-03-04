using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.Models
{
    /// <summary>
    /// Represents a unique User in the database, used for authentication.
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// This user's username.
        /// </summary>
        [Key]
        [Column("username")]
        public string Username { get; set; }

        /// <summary>
        /// This user's password.
        /// </summary>
        [Column("passwordHash")]
        public string PasswordHash { get; set; }
    }
}
