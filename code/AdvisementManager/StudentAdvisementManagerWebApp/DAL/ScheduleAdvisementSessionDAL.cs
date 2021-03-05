using Microsoft.EntityFrameworkCore;
using AdvisementManagerSharedLibrary.Models;
using AdvisementManagerSharedLibrary.Data;

namespace StudentAdvisementManagerWebApp.DAL
{
    public class ScheduleAdvisementSessionDAL
    {
        /// <summary>Inserts a new advisement session</summary>
        /// <param name="session">The session model</param>
        /// <param name="context">The context.</param>
        public void ScheduleAdvisementSession(AdvisementSession session, ApplicationDbContext context)
        {
            context.Entry(session).State = EntityState.Added;
            context.SaveChanges();
        }
    }
}
