using AdvisementManagerDesktopApp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AdvisementManagerDesktopUnitTests.Model
{
    [TestClass]
    public class HoldTests
    {
        [TestMethod]
        public void HoldInitializerTest()
        {
            var hold = new Hold
            {
                Id = 1,
                Reason = "test hold reason",
                Date = new DateTime(),
                IsActive = false
            };
            Assert.IsNotNull(hold);
            Assert.AreEqual(hold.Id, 1);
            Assert.AreEqual(hold.Reason, "test hold reason");
            Assert.AreEqual(hold.IsActive, false);
        }
    }
}
