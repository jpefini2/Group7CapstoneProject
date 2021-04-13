using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerDesktopApp.Model;

namespace AdvisementManagerDesktopApp.Resources
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

        /// <summary>The friday string</summary>
        public const string Friday = "Friday";

        /// <summary>The thursday string</summary>
        public const string Thursday = "Thursday";

        /// <summary>The wednesday string</summary>
        public const string Wednesday = "Wednesday";

        /// <summary>The tuesday string</summary>
        public const string Tuesday = "Tuesday";

        /// <summary>The monday string</summary>
        public const string Monday = "Monday";

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
