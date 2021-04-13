using AdvisementManagerDesktopApp.Controller;
using AdvisementManagerDesktopApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerDesktopUnitTests.Controller
{
    [TestClass]
    public class AdvisementSessionControllerTests
    {
        [TestMethod]
        public void AdvisementSessionControllerTest()
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
            var asc = new AdvisementSessionController();
            Assert.IsNotNull(asc);
        }
    }
}
