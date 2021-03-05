using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibrary.DAL
{
    /// <summary>
    ///   The Advisement sessions DAL class for managing, updating and pulling infomration related to the advisement session table in the DbContext/Database.
    /// </summary>
    public class AdvisementSessionDAL
    {
        /// <summary>Obtains the session, with the passed in session Id, from the DbContext.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   The session found in the DbContext.
        /// </returns>
        public AdvisementSession ObtainSession(int? id, ApplicationDbContext context)
        {
            var sessions = from sessionToFind in context.AdvisementSession where sessionToFind.StudentId == id && sessionToFind.Completed == false select sessionToFind;
            var upcomingSession = sessions.FirstOrDefault(s => s.Date == sessions.Max(x => x.Date));

            return upcomingSession;
        }

        public AdvisementSession ObtainLatestSession(int? studentId, ApplicationDbContext context)
        {
            var sessions = from sessionToFind in context.AdvisementSession where sessionToFind.StudentId == studentId select sessionToFind;
            var upcomingSession = sessions.FirstOrDefault(s => s.Date == sessions.Max(x => x.Date));

            return upcomingSession;
        }
    }
}
