using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AdvisementManagerWebApp.Models;

namespace AdvisementManagerWebApp.Data
{
    /// <summary>
    ///   The Application data context class
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>Initializes a new instance of the <see cref="ApplicationDbContext" /> class.</summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>Gets or sets the student.</summary>
        /// <value>The student.</value>
        public DbSet<Student> Student { get; set; }

        /// <summary>Gets or sets the advisement session.</summary>
        /// <value>The advisement session.</value>
        public DbSet<AdvisementSession> AdvisementSession { get; set; }

        /// <summary>Gets or sets the hold.</summary>
        /// <value>The hold.</value>
        public DbSet<Hold> Hold { get; set; }

        /// <summary>Gets or sets the advisor.</summary>
        /// <value>The advisor.</value>
        public DbSet<Advisor> Advisor { get; set; }

    }
}
