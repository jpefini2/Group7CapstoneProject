using System;
using AdvisementManagerWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.AdvisementSession
{
    [TestClass]
    public class HoldInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var date = new DateTime();
            var hold = new AdvisementManagerWebApp.Models.Hold {
                Id = 1,
                Reason = "a",
                Date = date,
                IsActive = false,
                StudentId = 1
            };

            Assert.AreEqual(hold.Date, date);
            Assert.AreEqual(hold.Reason, "a");
            Assert.AreEqual(hold.Id, 1);
            Assert.AreEqual(hold.IsActive, false);
            Assert.AreEqual(hold.StudentId, 1);

        }
    }
}
