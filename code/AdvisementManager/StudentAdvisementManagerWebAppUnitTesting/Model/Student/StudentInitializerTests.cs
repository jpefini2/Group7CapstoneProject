using System.Collections.Generic;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerSharedLibraryUnitTesting.Model.AdvisementSession
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
            var student = new AdvisementManagerSharedLibrary.Models.Student {
                FirstName = "John",
                LastName = "Johnson",
                Id = 1,
                Email = "jJohnson@gmail.com",
                UserName = "jJohnson",
                GeneralAdvisor = general,
                FacultyAdvisor = faculty,
                Hold = hold,
                Meeting = session,
                facultyAdvisorId = 1,
                generalAdvisorId = 2,
            };

            Assert.AreEqual(student.FirstName, "John");
            Assert.AreEqual(student.LastName, "Johnson");
            Assert.AreEqual(student.Id, 1);
            Assert.AreEqual(student.Email, "jJohnson@gmail.com");
            Assert.AreEqual(student.GeneralAdvisor, general);
            Assert.AreEqual(student.FacultyAdvisor, faculty);
            Assert.AreEqual(student.Hold, hold);
            Assert.AreEqual(student.Meeting, session);
            Assert.AreEqual(student.FullName, "John Johnson");
            Assert.AreEqual(student.facultyAdvisorId, 1);
            Assert.AreEqual(student.generalAdvisorId, 2);
            Assert.AreEqual(student.UserName, "jJohnson");
        }
    }
}
