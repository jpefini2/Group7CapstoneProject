using System.Collections.Generic;
using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerDesktopApp.Model;

namespace AdvisementManagerDesktopApp.Controller
{
    /// <summary>
    ///   The advisement sessions controller for managing and processing data between the view and model for available advisement sessions
    /// </summary>
    public class AdvisementSessionsController
    {
        /// <summary>Obtains the students with active holds from the database to be passed to the view.
        /// This should not be used to gather a list of students for a
        /// different advisor than the one that is assigned to that advisor.</summary>
        /// <returns>
        ///   The list of students who currently have holds in the system.
        /// </returns>
        public IList<Student> ObtainStudentsWithHolds(Advisor advisor)
        {
            var studentDal = new StudentDal();

            var students = studentDal.ObtainStudentsWithHolds(advisor);

            return students;
        }

        /// <summary>Obtains the upcoming meetings of the advisor from the database to be passed to the view.</summary>
        /// <returns>
        ///   The list of upcoming meetings for the advisor.
        /// </returns>
        public IList<AdvisementSession> ObtainUpcomingMeetings(Advisor advisor)
        {
            var sessionDal = new AdvisementSessionDal();

            var sessions = sessionDal.ObtainAdvisorsUpcomingSessions(advisor);

            return sessions;
        }
    }
}
