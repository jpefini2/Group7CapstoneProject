using AdvisementManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace AdvisementManagerWebApp.DAL
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
            var session =  context.AdvisementSession.FromSqlRaw(
                              "SELECT sessionID, sessionDate, notes, stage, studentID, completed, advisorID FROM AdvisementSession WHERE studentID = {0} and sessionDate = (SELECT Max(sessionDate) FROM AdvisementSession WHERE studentID = {0})", id).FirstOrDefault();

            return session;
        }
    }
}
