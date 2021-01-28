using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerDesktopApp.Model;

namespace AdvisementManagerDesktopApp.Controller
{

    /// <summary>
    ///   The Advisement session controller
    /// </summary>
    public class AdvisementSessionController
    {
        public void ApproveMeeting(Student student, Advisor advisor)
        {
            var holdsDal = new HoldsDal();
            if (advisor.IsFacultyAdvisor)
            {
                holdsDal.ApproveFacultyAdvisorMeeting(student);
            }

        }

        public void RemoveHold(Student student)
        { 
            var holdsDal = new HoldsDal();
            holdsDal.RemoveHold(student);

        }
    }
}
