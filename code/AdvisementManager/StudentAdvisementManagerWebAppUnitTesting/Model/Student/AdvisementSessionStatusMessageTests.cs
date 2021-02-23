using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentAdvisementManagerWebAppUnitTesting.Model.Student
{
    [TestClass]
    public class AdvisementSessionStatusMessageTests
    {
        [TestMethod]
        public void AdvisementSessionStatusMessageWithMeetingNotPassedTest()
        {
            var session = new StudentAdvisementManagerWebApp.Models.AdvisementSession{Date = DateTime.Now.AddMinutes(30)};
            var student = new StudentAdvisementManagerWebApp.Models.Student
            {
                FirstName = "a",
                LastName = "b",
                Id = 1,
                Email = "ab",
                Meeting = session,
                facultyAdvisorId = 1,
                generalAdvisorId = 2
            };

            var hasMeeting = student.AdvisementSessionStatusMessage;

            Assert.AreEqual("Meeting at " + student.Meeting.Date, hasMeeting);
        }

        [TestMethod]
        public void AdvisementSessionStatusMessageWithNoMeetingScheduledTest()
        {
            var student = new StudentAdvisementManagerWebApp.Models.Student
            {
                FirstName = "a",
                LastName = "b",
                Id = 1,
                Email = "ab",
                Meeting = null,
                facultyAdvisorId = 1,
                generalAdvisorId = 2
            };

            var hasMeeting = student.AdvisementSessionStatusMessage;

            Assert.AreEqual("No meeting scheduled.", hasMeeting);
        }

        [TestMethod]
        public void AdvisementSessionStatusMessageWithMeetingPassedAndCompleted()
        {
            var session = new StudentAdvisementManagerWebApp.Models.AdvisementSession { Date = DateTime.Now, Completed = true };
            var student = new StudentAdvisementManagerWebApp.Models.Student
            {
                FirstName = "a",
                LastName = "b",
                Id = 1,
                Email = "ab",
                Meeting = session,
                facultyAdvisorId = 1,
                generalAdvisorId = 2
            };

            var hasMeeting = student.AdvisementSessionStatusMessage;

            Assert.AreEqual("No meeting scheduled.", hasMeeting);
        }

        [TestMethod]
        public void AdvisementSessionStatusMessageWithMeetingPassedAndNotCompleted()
        {
            var session = new StudentAdvisementManagerWebApp.Models.AdvisementSession { Date = DateTime.Now, Completed = false };
            var student = new StudentAdvisementManagerWebApp.Models.Student
            {
                FirstName = "a",
                LastName = "b",
                Id = 1,
                Email = "ab",
                Meeting = session,
                facultyAdvisorId = 1,
                generalAdvisorId = 2
            };

            var hasMeeting = student.AdvisementSessionStatusMessage;

            Assert.AreEqual("Meeting awaiting approval.", hasMeeting);
        }
    }
}
