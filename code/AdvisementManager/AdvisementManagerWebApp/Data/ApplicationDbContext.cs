using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AdvisementManagerWebApp.Models;

namespace AdvisementManagerWebApp.Data
{
    /// <summary>
    ///   The Application data context class for managing data from the database within the application.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        /// <summary>Initializes a new instance of the <see cref="ApplicationDbContext" /> class.</summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>Gets or sets the students data from the relevant student table in the database.</summary>
        /// <value>The student.</value>
        public DbSet<Student> Student { get; set; }

        /// <summary>Gets or sets the advisement sessions from the relevant advisement session table in the database.</summary>
        /// <value>The advisement session.</value>
        public DbSet<AdvisementSession> AdvisementSession { get; set; }

        /// <summary>Gets or sets the holds from the relevant hold table in the database.</summary>
        /// <value>The hold.</value>
        public DbSet<Hold> Hold { get; set; }

        /// <summary>Gets or sets the advisors from the relevant advisor table in the database.</summary>
        /// <value>The advisor.</value>
        public DbSet<Advisor> Advisor { get; set; }

        /// <summary>Gets or sets the user from the relevant login table in the database.</summary>
        /// <value>The user.</value>
        public DbSet<User> Login { get; set; }

        /// <summary>Login Sessions stored in the database</summary>
        /// <value>The login session.</value>
        public DbSet<LoginSession> LoginSession { get; set; }

    }
}
