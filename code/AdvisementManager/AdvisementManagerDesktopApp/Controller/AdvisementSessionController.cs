using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerDesktopApp.Model;

namespace AdvisementManagerDesktopApp.Controller
{

    /// <summary>
    ///   The Advisement session controller
    /// </summary>
    public class AdvisementSessionController
    {
        /// <summary>Approves the meeting.</summary>
        /// <param name="student">The student.</param>
        /// <param name="advisor">The advisor.</param>
        public void ApproveMeeting(Student student, Advisor advisor)
        {
            var holdsDal = new HoldsDal();
            if (advisor.IsFacultyAdvisor)
            {
                holdsDal.ApproveFacultyAdvisorMeeting(student);
            }

        }

        /// <summary>Removes the hold.</summary>
        /// <param name="student">The student.</param>
        public void RemoveHold(Student student)
        { 
            var holdsDal = new HoldsDal();
            holdsDal.RemoveHold(student);

        }
    }
}
