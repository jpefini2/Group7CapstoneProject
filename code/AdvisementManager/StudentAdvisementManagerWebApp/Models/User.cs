using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAdvisementManagerWebApp.Models
{
    public partial class User
    {
        [Key]
        [Column("username")]
        public string Username { get; set; }

        [Column("passwordHash")]
        public string PasswordHash { get; set; }
    }
}
