using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvisementManagerWebApp.Models
{
    public class LoginSession
    {
        /// <summary>
        /// The username associated with this session.
        /// </summary>
        [Key]
        [Column("username")]
        public string Username { get; set; }

        /// <summary>
        /// The random SessionKey associated with this session.
        /// </summary>
        [Column("sessionKey")]
        public string SessionKey { get; set; }

        /// <summary>
        /// The time this session should expire.
        /// </summary>
        [Column("expirationDate")]
        public DateTime ExpirationDate { get; set; }
    }
}
