using AdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentAdvisementManagerWebApp.Models;

namespace StudentAdvisementManagerWebApp.Data
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

        /// <summary>Gets or sets the user.</summary>
        /// <value>The user.</value>
        public DbSet<User> Login { get; set; }

        /// <summary>Login Sessions stored in the database</summary>
        /// <value>The login session.</value>
        public DbSet<LoginSession> LoginSession { get; set; }
    }
}
