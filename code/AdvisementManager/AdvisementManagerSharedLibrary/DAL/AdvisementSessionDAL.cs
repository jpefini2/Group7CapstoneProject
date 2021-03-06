using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvisementManagerSharedLibrary.DAL
{
    /// <summary>
    ///   The Advisement sessions DAL class for managing, updating and pulling infomration related to the advisement session table in the DbContext/Database.
    /// </summary>
    public class AdvisementSessionDAL
    {
        public AdvisementSession ObtainSessionFromId(int? id, ApplicationDbContext context)
        {
            var session = (from sessionToFind in context.AdvisementSession 
                          where sessionToFind.Id == id
                          select sessionToFind).FirstOrDefault();

            return session;
        }

        /// <summary>Obtains the session, with the passed in session Id, from the DbContext.</summary>
        /// <param name="studentId">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   The session found in the DbContext.
        /// </returns>
        public AdvisementSession ObtainLatestIncompleteSessionFromStudent(int? studentId, ApplicationDbContext context)
        {
            var sessions = from sessionToFind in context.AdvisementSession where 
                               sessionToFind.StudentId == studentId && sessionToFind.Completed == false select sessionToFind;

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

        /// <summary>Obtains the upcoming sessions for the desired advisor</summary>
        /// <param name="context">The context.</param>
        /// <param name="advisor">The advisor.</param>
        /// <returns>A list of the advisor's upcoming advisement sessions</returns>
        public IList<AdvisementSession> ObtainUpcomingSessions(ApplicationDbContext context, Advisor advisor)
        {
            List<AdvisementSession> upcomingSessions = (from upcomingSession in context.AdvisementSession
                                                        where upcomingSession.AdvisorId == advisor.Id && upcomingSession.Completed == false
                                                        select upcomingSession).ToList();
            StudentDal studentDal = new StudentDal();
            foreach (var session in upcomingSessions)
            {
                session.Student = studentDal.ObtainStudentWithId(session.StudentId, context);
                session.Advisor = advisor;
            }

            return upcomingSessions;
        }

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
    }
}
