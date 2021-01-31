using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerDesktopApp.Model;
using System;

namespace AdvisementManagerDesktopApp.Controller
{

    /// <summary>
    ///   The Advisement session controller
    /// </summary>
    public class AdvisementSessionController
    {
        private readonly HoldsDal holdsDal = new HoldsDal();

        /// <summary>Approves the meeting.</summary>
        /// <param name="student">The student.</param>
        /// <param name="advisor">The advisor.</param>
        public void ApproveMeeting(Student student, Advisor advisor)
        {
            if (advisor.IsFacultyAdvisor)
            {
                student.Hold.Reason = @"Student has met with faculty advisor hold pending removal.";
                this.holdsDal.ApproveFacultyAdvisorMeeting(student);
            }

        }

        /// <summary>Removes the hold.</summary>
        /// <param name="student">The student.</param>
        public void RemoveHold(Student student)
        {
            this.holdsDal.RemoveHold(student);

        }

        public AdvisementSession CheckForMeeting(Student student)
        {
            return this.holdsDal.CheckForMeetings(student);
        }
    }
}
