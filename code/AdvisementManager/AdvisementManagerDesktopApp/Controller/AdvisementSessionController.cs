using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerDesktopApp.Model;
using AdvisementManagerDesktopApp.Resources;

namespace AdvisementManagerDesktopApp.Controller
{

    /// <summary>
    ///   The Advisement session controller
    /// </summary>
    public class AdvisementSessionController
    {
        private readonly HoldsDal holdsDal = new HoldsDal();

        private readonly AdvisementSessionDal sessionDal = new AdvisementSessionDal();

        /// <summary>Approves the meeting.</summary>
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

        /// <summary>Removes the hold.</summary>
        /// <param name="student">The student.</param>
        public void RemoveHold(Student student)
        {
            student.Hold.Reason = ConstantManager.ReadyToRegister;
            student.Hold.IsActive = false;
            this.holdsDal.RemoveHold(student);

        }

        public AdvisementSession CheckForMeeting(Student student)
        {
            return this.holdsDal.CheckForMeetings(student);
        }
    }
}
