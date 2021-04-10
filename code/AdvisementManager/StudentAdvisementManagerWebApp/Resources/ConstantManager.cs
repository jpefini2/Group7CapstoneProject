using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Models;

namespace StudentAdvisementManagerWebApp.Resources
{
    /// <summary>
    ///   The Constant Manager Class.
    /// </summary>
    public static class ConstantManager
    {

        /// <summary>The need to meet DPT advisor</summary>
        public const string NeedToMeetDptAdvisor = "need to meet with dept advisor";

        /// <summary>The need to meet fac advisor</summary>
        public const string NeedToMeetFacAdvisor = "need to meet with faculty advisor";

        /// <summary>The waiting for hold removal</summary>
        public const string WaitingForHoldRemoval = "waiting for hold to be removed";

        /// <summary>The ready to register</summary>
        public const string ReadyToRegister = "ready to register";

        public static string GetApprovedMeetingMessage(DateTime meetingDateTime)
        {
            return "Your meeting on " + meetingDateTime.ToString("M/d/yy") + " at " + meetingDateTime.ToString("hh:mm") + " is approved.";
        }

        public static string GetCanceledMeetingMessage(DateTime meetingDateTime)
        {
            return "Your meeting on " + meetingDateTime.ToString("M/d/yy") + " at " + meetingDateTime.ToString("hh:mm") + " was canceled.";
        }

        public static string GetHoldRemovedMessage(Student student, Advisor advisor)
        {
            return student.FullName + "'s" + " hold was removed by " + advisor.FullName;
        }
    }
}
