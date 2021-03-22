using System.Collections.Generic;
using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerDesktopApp.Model;
using AdvisementManagerDesktopApp.Resources;

namespace AdvisementManagerDesktopApp.Controller
{

    /// <summary>
    ///   The Advisement session controller for managing data between the view and model for individual advisement sessions.
    /// </summary>
    public class AdvisementSessionController
    {
        private readonly HoldsDal holdsDal = new HoldsDal();

        private readonly AdvisementSessionDal sessionDal = new AdvisementSessionDal();

        /// <summary>
        ///     Approves the meeting between and advisor and student in the database and updates the hold reason accordingly
        ///     based off of the particular advisor that approved the meeting.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <param name="advisor">The advisor.</param>
        public void ApproveMeeting(Student student, Advisor advisor)
        {
            if (advisor.IsFacultyAdvisor)
            {
                student.Hold.Reason = ConstantManager.WaitingForHoldRemoval;
            }
            else
            {
                student.Hold.Reason = ConstantManager.NeedToMeetFacAdvisor;
            }

            student.Meeting.Completed = true;

            this.holdsDal.ApproveAdvisorMeeting(student);
            this.sessionDal.UpdateMeeting(student);
        }

        /// <summary>Obtains the student sessions for past meetings to be used in the view for displaying notes.</summary>
        /// <param name="student">The student.</param>
        /// <returns>
        ///     A list of sessions for students past meetings.
        /// </returns>
        public IList<AdvisementSession> ObtainStudentSessions(Student student)
        {
            var advisorDal = new AdvisorDAL();

            var sessions = this.sessionDal.ObtainStudentSessions(student);
            
            foreach(var session in sessions)
            {
                session.Advisor = advisorDal.ObtainAdvisor(session.AdvisorID);
            }

            return sessions;
        }

        /// <summary>Removes the hold for a particular student in the database and updated the reason to ready to register.</summary>
        /// <param name="student">The student.</param>
        public void RemoveHold(Student student)
        {
            student.Hold.Reason = ConstantManager.ReadyToRegister;
            student.Hold.IsActive = false;
            this.holdsDal.RemoveHold(student);

        }

        /// <summary>Checks the database to see if a particular student has a meeting scheduled and if so returns that meeting.</summary>
        /// <param name="student">The student.</param>
        /// <returns>
        ///   The meeting for the particular student.
        /// </returns>
        public AdvisementSession CheckForMeeting(Student student)
        {
            return this.holdsDal.CheckForMeetings(student);
        }

        public void CancelMeeting(int meetingId)
        {
            //TODO add cancelling meeting functionality here.
        }
    }
}
