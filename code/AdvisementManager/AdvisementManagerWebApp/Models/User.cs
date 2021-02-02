﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvisementManagerWebApp.Models
{
    public partial class User
    {
        [Key]
        [Column("username")]
        public string Username { get; set; }

        [Column("password")]
        public string Password { get; set; }
    }
}
