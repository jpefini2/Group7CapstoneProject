using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.Student
{
    [TestClass]
    public class AdvisementSessionStatusMessageTests
    {
        [TestMethod]
        public void AdvisementSessionStatusMessageWithMeetingScheduledTest()
        {
            var session = new AdvisementManagerSharedLibrary.Models.AdvisementSession{Date = DateTime.Now};
            var sessions = new List<AdvisementManagerSharedLibrary.Models.AdvisementSession> { session };
            var student = new AdvisementManagerSharedLibrary.Models.Student
            {
                FirstName = "a",
                LastName = "b",
                Id = 1,
                Email = "ab",
                Meetings = sessions,
                Meeting = session,
                facultyAdvisorId = 1,
                generalAdvisorId = 2
            };

            var hasMeeting = student.AdvisementSessionStatusMessage;

            Assert.AreEqual("Meeting at " + student.Meeting.Date, student.AdvisementSessionStatusMessage);
        }

        [TestMethod]
        public void AdvisementSessionStatusMessageWithNoMeetingScheduledTest()
        {
            var student = new AdvisementManagerSharedLibrary.Models.Student
            {
                FirstName = "a",
                LastName = "b",
                Id = 1,
                Email = "ab",
                Meetings = null,
                Meeting = null,
                facultyAdvisorId = 1,
                generalAdvisorId = 2
            };

            var hasMeeting = student.AdvisementSessionStatusMessage;

            Assert.AreEqual("No meeting scheduled", student.AdvisementSessionStatusMessage);
        }
    }
}
