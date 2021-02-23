using StudentAdvisementManagerWebApp.Models;
using System.Linq;
using StudentAdvisementManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace StudentAdvisementManagerWebApp.DAL
{
    /// <summary>
    ///   The Advisement sessions DAL class
    /// </summary>
    public class AdvisementSessionDAL
    {
        /// <summary>Obtains the session.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   The retrieved session
        /// </returns>
        public AdvisementSession ObtainSession(int? id, ApplicationDbContext context)
        {
            var sessions = from sessionToFind in context.AdvisementSession where sessionToFind.StudentId == id && sessionToFind.Completed == false select sessionToFind;
            var upcomingSession = sessions.FirstOrDefault(s => s.Date == sessions.Max(x => x.Date));

            return upcomingSession;
        }
    }
}
