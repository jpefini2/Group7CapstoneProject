using AdvisementManagerDesktopApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopUnitTests.Model
{
    [TestClass]
    public class AdvisementSessionTests
    {
        [TestMethod]
        public void AdvisementSessionInitializerTests()
        {
            var student = new Student
            {
                Id = 1,
                FirstName = "test",
                LastName = "student",
                Email = "teststudent@test.com",
                Hold = new Hold(),
                GeneralAdvisor = new Advisor(),
                FacultyAdvisor = new Advisor(),
                Meeting = new AdvisementSession()
            };

            var advisor = new Advisor
            {
                Id = 1,
                FirstName = "test",
                LastName = "advisor",
                Email = "testadvisor@test.com",
                IsFacultyAdvisor = false,
                Students = null
            };

            var hold = new Hold
            {
                Id = 1,
                Reason = "test hold reason",
                Date = new DateTime(),
                IsActive = false
            };

            var advisementSession = new AdvisementSession
            {
                Id = 1,
                Student = student,
                Advisor = advisor,
                AdvisorID = advisor.Id,
                StudentID = student.Id,
                Hold = hold,
                HoldID = hold.Id,
                Date = new DateTime(),
                EndDate = new DateTime(),
                Stage = 1,
                Completed = false,
                Notes = "test notes"
            };
            Assert.AreEqual(advisementSession.Student, student);
            Assert.AreEqual(advisementSession.Stage, 1);
            Assert.AreEqual(advisementSession.Advisor, advisor);
            Assert.AreEqual(advisementSession.Date, new DateTime());
            Assert.AreEqual(advisementSession.EndDate, new DateTime());
            Assert.AreEqual(advisementSession.Completed, false);
            Assert.AreEqual(advisementSession.Id, 1);
        }
    }
}
