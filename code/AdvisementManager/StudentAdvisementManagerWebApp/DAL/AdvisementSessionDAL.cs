using System.Collections.Generic;
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
        /// <param name="studentId">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   The retrieved session
        /// </returns>
        public AdvisementSession ObtainLatestIncompleteSession(int? studentId, ApplicationDbContext context)
        {
            var sessions = from sessionToFind in context.AdvisementSession where sessionToFind.StudentId == studentId && sessionToFind.Completed == false select sessionToFind;
            var upcomingSession = sessions.FirstOrDefault(s => s.Date == sessions.Max(x => x.Date));

            return upcomingSession;
        }

        public AdvisementSession ObtainLatestSession(int? studentId, ApplicationDbContext context)
        {
            var sessions = from sessionToFind in context.AdvisementSession where sessionToFind.StudentId == studentId select sessionToFind;
            var upcomingSession = sessions.FirstOrDefault(s => s.Date == sessions.Max(x => x.Date));

            return upcomingSession;
        }

        public List<AdvisementSession> ObtainSessions(int? studentId, ApplicationDbContext context)
        {
            var sessions = from sessionToFind in context.AdvisementSession where sessionToFind.StudentId == studentId select sessionToFind;
            return sessions.ToList();
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
