using System.Collections.Generic;
using StudentAdvisementManagerWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentAdvisementManagerWebAppUnitTesting.Model.AdvisementSession
{
    [TestClass]
    public class StudentInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var general = new StudentAdvisementManagerWebApp.Models.Advisor();
            var faculty = new StudentAdvisementManagerWebApp.Models.Advisor();
            var hold = new StudentAdvisementManagerWebApp.Models.Hold();
            var session = new StudentAdvisementManagerWebApp.Models.AdvisementSession();
            var student = new StudentAdvisementManagerWebApp.Models.Student {
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
