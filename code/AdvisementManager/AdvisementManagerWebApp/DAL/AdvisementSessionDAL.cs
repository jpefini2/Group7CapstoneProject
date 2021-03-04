using System.Collections.Generic;
using AdvisementManagerWebApp.Models;
using System.Linq;
using AdvisementManagerWebApp.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

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
            var sessions = from sessionToFind in context.AdvisementSession where 
                               sessionToFind.StudentId == id && sessionToFind.Completed == false select sessionToFind;

            var upcomingSession = sessions.FirstOrDefault(s => s.Date == sessions.Max(x => x.Date));

            return upcomingSession;
        }

        /// <summary>Obtains the past sessions for the desired student that are a part of the students hold period</summary>
        /// <param name="context">The context.</param>
        /// <param name="student">The student.</param>
        /// <returns>A list of past advisement sessions that are part of the current hold period for the student.</returns>
        public IList<AdvisementSession> ObtainPastSessions(ApplicationDbContext context, Student student)
        {
            return (from oldSessions in context.AdvisementSession
                    where oldSessions.HoldId == student.Hold.Id && oldSessions.Completed == true && oldSessions.StudentId
                        == student.Id select oldSessions).ToList();
        }
    }
}
