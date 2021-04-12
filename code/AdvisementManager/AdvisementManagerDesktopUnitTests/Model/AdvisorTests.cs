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
    public class AdvisorTests
    {
        [TestMethod]
        public void AdvisorInititalizerTest()
        {
            var advisor = new Advisor
            {
                Id = 1,
                FirstName = "test",
                LastName = "advisor",
                Email = "testadvisor@test.com",
                IsFacultyAdvisor = false,
                Students = null
            };
            Assert.IsNotNull(advisor);
            Assert.AreEqual(advisor.FirstName, "test");
            Assert.AreEqual(advisor.LastName, "advisor");
            Assert.AreEqual(advisor.Id, 1);
            Assert.AreEqual(advisor.IsFacultyAdvisor, false);
            Assert.AreEqual(advisor.Email, "testadvisor@test.com");
        }
    }
}
