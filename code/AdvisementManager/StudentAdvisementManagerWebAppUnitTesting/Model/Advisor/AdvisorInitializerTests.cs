using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdvisementManagerWebAppUnitTesting.Model.Advisor
{
    [TestClass]
    public class AdvisorInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var advisor = new StudentAdvisementManagerWebApp.Models.Advisor
            {
                FirstName = "John",
                LastName = "Johnson",
                Id = 1,
                IsFacultyAdvisor = false,
                Email = "jJohnson@gmail.com"
            };


            Assert.AreEqual(advisor.FirstName, "John");
            Assert.AreEqual(advisor.LastName, "Johnson");
            Assert.AreEqual(advisor.Id, 1);
            Assert.AreEqual(advisor.IsFacultyAdvisor, false);
            Assert.AreEqual(advisor.Email, "jJohnson@gmail.com");
            Assert.AreEqual(advisor.FullName, "John Johnson");
        }
    }
}
