using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdvisementManagerWebAppUnitTesting.DAL.LoginDAL
{
    [TestClass]
    class LoginDALTests
    {
        [TestMethod]
        public void LoginTest()
        {
            var student = new Student
            {
                Id = 0,
                FirstName = "Craig",
                LastName = "Playstead",
                Email = "cplay@fjasp.net",
                generalAdvisorId = 0,
                facultyAdvisorId = 0
            };

            var advisor = new Advisor
            {
                Id = 0,
                FirstName = "Gina",
                LastName = "Smith",
                Email = "cplay@fjasp.net",
                IsFacultyAdvisor = true,
                UserName = "gsmith"
            };

            Mock<ApplicationDbContext> context = new Mock<ApplicationDbContext>();

            context.Object.Add(student);
            context.Object.Add(advisor);

            var loginDAL = new AdvisementManagerWebApp.DAL.LoginDAL(context.Object);
            bool success = loginDAL.AttemptLogin("gsmith", "password1");
            Assert.IsTrue(success);
        }
    }
}
