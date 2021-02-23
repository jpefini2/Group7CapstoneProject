using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdvisementManagerWebAppUnitTesting.Model.Student
{
    [TestClass]
    public class CanScheduleMeetingTests
    { 
        [TestMethod]
        public void WithUpcomingMeetingTest()
        {
            var session = new StudentAdvisementManagerWebApp.Models.AdvisementSession { Date = DateTime.Now.AddMinutes(30) };
            var student = new StudentAdvisementManagerWebApp.Models.Student
            {
                FirstName = "John",
                LastName = "Johnson",
                Id = 1,
                Email = "jJohnson@gmail.com",
                Meeting = session,
                facultyAdvisorId = 1,
                generalAdvisorId = 2
            };

            Assert.IsFalse(student.CanScheduleMeeting());
        }

        [TestMethod]
        public void WithNoMeetingAndImproperHoldReason()
        {
            var date = new DateTime();
            var hold = new StudentAdvisementManagerWebApp.Models.Hold
            {
                Id = 1,
                Reason = "No holds",
                Date = date,
                IsActive = true,
                StudentId = 1
            };

            var student = new StudentAdvisementManagerWebApp.Models.Student
            {
                FirstName = "John",
                LastName = "Johnson",
                Id = 1,
                Email = "jJohnson@gmail.com",
                Hold = hold,
                Meeting = null,
                facultyAdvisorId = 1,
                generalAdvisorId = 2
            };

            Assert.IsFalse(student.CanScheduleMeeting());
        }

        [TestMethod]
        public void WithNoMeetingAndPropertHoldReason()
        {
            var date = new DateTime();
            var hold = new StudentAdvisementManagerWebApp.Models.Hold
            {
                Id = 1,
                Reason = "need to meet with dept advisor",
                Date = date,
                IsActive = true,
                StudentId = 1
            };

            var student = new StudentAdvisementManagerWebApp.Models.Student
            {
                FirstName = "John",
                LastName = "Johnson",
                Id = 1,
                Email = "jJohnson@gmail.com",
                Hold = hold,
                Meeting = null,
                facultyAdvisorId = 1,
                generalAdvisorId = 2
            };

            Assert.IsTrue(student.CanScheduleMeeting());
        }
    }
}
