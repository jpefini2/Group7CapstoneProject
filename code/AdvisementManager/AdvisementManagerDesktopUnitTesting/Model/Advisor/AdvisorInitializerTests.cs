using AdvisementManagerWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.AdvisementSession
{
    [TestClass]
    public class AdvisorInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var advisor = new AdvisementManagerWebApp.Models.Advisor {
                FirstName = "a",
                LastName = "b",
                Id = 1,
                IsFacultyAdvisor = false,
                Email = "ad",
                UserName = "someName"
            };


            Assert.AreEqual(advisor.FirstName, "a");
            Assert.AreEqual(advisor.LastName, "b");
            Assert.AreEqual(advisor.Id, 1);
            Assert.AreEqual(advisor.IsFacultyAdvisor, false);
            Assert.AreEqual(advisor.Email, "ad");
            Assert.AreEqual(advisor.FullName, "a b");
            Assert.AreEqual("a b", advisor.FullName);
            Assert.AreEqual("someName", advisor.UserName);
        }
    }
}
