using AdvisementManagerWebApp.Models;
using System.Linq;
using AdvisementManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AdvisementManagerWebApp.DAL
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
            var session =  context.AdvisementSession.FromSqlRaw(
                              "SELECT sessionID, sessionDate, notes, stage, studentID, completed, advisorID FROM AdvisementSession WHERE studentID = {0} and completed = 0 and sessionDate = (SELECT Max(sessionDate) FROM AdvisementSession WHERE studentID = {0})", id).FirstOrDefault();

            return session;
        }
    }
}
