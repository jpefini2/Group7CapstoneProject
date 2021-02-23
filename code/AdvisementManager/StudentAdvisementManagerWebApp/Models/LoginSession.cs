using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAdvisementManagerWebApp.Models
{
    public class LoginSession
    {
        /// <summary>
        /// The username associated with this session
        /// </summary>
        [Key]
        [Column("username")]
        public string Username { get; set; }

        /// <summary>
        /// The random session key associated with this session.
        /// </summary>
        [Column("sessionKey")]
        public string SessionKey { get; set; }

        /// <summary>
        /// The date this session should expire.
        /// </summary>
        [Column("expirationDate")]
        public DateTime ExpirationDate { get; set; }
    }
}
