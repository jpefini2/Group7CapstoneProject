using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AdvisementManagerWebApp.Models;

namespace AdvisementManagerWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }

        public DbSet<AdvisementSession> AdvisementSession { get; set; }

        public DbSet<Hold> Hold { get; set; }

        public DbSet<Advisor> Advisor { get; set; }

    }
}
