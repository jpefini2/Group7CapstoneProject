using System.Collections.Generic;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.AdvisementSession
{
    [TestClass]
    public class StudentInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var general = new AdvisementManagerSharedLibrary.Models.Advisor();
            var faculty = new AdvisementManagerSharedLibrary.Models.Advisor();
            var hold = new AdvisementManagerSharedLibrary.Models.Hold();
            var session = new AdvisementManagerSharedLibrary.Models.AdvisementSession();
            var sessions = new List<AdvisementManagerSharedLibrary.Models.AdvisementSession>{session};
            var student = new AdvisementManagerSharedLibrary.Models.Student {
                FirstName = "a",
                LastName = "b",
                Id = 1,
                Email = "ab",
                GeneralAdvisor = general,
                FacultyAdvisor = faculty,
                Hold = hold,
                Meetings = sessions,
                Meeting = session,
                facultyAdvisorId = 1,
                generalAdvisorId = 2,
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
            Assert.AreEqual(student.facultyAdvisorId, 1);
            Assert.AreEqual(student.generalAdvisorId, 2);
            Assert.AreEqual("a b", student.FullName);
        }
    }
}
