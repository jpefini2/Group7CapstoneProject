using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvisementManagerWebApp.Models
{
    public class LoginSession
    {
        [Key]
        [Column("username")]
        public string Username { get; set; }

        [Column("sessionKey")]
        public string SessionKey { get; set; }

        [Column("expirationDate")]
        public DateTime ExpirationDate { get; set; }
    }
}
