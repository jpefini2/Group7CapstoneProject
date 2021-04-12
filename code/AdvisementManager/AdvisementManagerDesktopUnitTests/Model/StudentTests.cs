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
    public class StudentTests
    {
        [TestMethod]
        public void StudentInstantiationTest()
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
            Assert.IsNotNull(student);
            Assert.AreEqual(student.FirstName, "test");
            Assert.AreEqual(student.LastName, "student");
            Assert.AreEqual(student.Id, 1);
            Assert.AreEqual(student.Email, "teststudent@test.com");
        }
    }
}
