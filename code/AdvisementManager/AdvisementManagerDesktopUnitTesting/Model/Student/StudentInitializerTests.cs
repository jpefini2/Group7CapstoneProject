using System.Collections.Generic;
using AdvisementManagerWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.AdvisementSession
{
    [TestClass]
    public class StudentInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var general = new Advisor();
            var faculty = new Advisor();
            var hold = new AdvisementManagerWebApp.Models.Hold();
            var session = new AdvisementManagerWebApp.Models.AdvisementSession();
            var sessions = new List<AdvisementManagerWebApp.Models.AdvisementSession>{session};
            var student = new Student {
                FirstName = "a",
                LastName = "b",
                Id = 1,
                Email = "ab",
                GeneralAdvisor = general,
                FacultyAdvisor = faculty,
                Hold = hold,
                Meetings = sessions,
                Meeting = session
            };

            Assert.AreEqual(student.FirstName, "a");
            Assert.AreEqual(student.LastName, "b");
            Assert.AreEqual(student.Id, 1);
            Assert.AreEqual(student.Email, "ab");
            Assert.AreEqual(student.GeneralAdvisor, general);
            Assert.AreEqual(student.FacultyAdvisor, faculty);
            Assert.AreEqual(student.Hold, hold);
            Assert.AreEqual(student.Meetings, sessions);
            Assert.AreEqual(student.Meeting, session);
            Assert.AreEqual(student.FullName, "a b");
        }
    }
}
