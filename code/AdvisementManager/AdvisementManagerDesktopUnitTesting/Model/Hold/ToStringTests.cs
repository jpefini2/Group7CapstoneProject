using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.Hold
{
    [TestClass]
    public class ToStringTests
    {
        [TestMethod]
        public void ToStringNoHoldTest()
        {
            var date = new DateTime();
            var hold = new AdvisementManagerSharedLibrary.Models.Hold
            {
                Id = 1,
                Reason = "a",
                Date = date,
                IsActive = false,
                StudentId = 1
            };

            Assert.AreEqual("No Hold", hold.ToString());
        }

        [TestMethod]
        public void ToStringWithHoldTest()
        {
            var date = new DateTime();
            var hold = new AdvisementManagerSharedLibrary.Models.Hold
            {
                Id = 1,
                Reason = "a",
                Date = date,
                IsActive = true,
                StudentId = 1
            };

            Assert.AreEqual("Hold: " + hold.Reason, hold.ToString());
        }
    }
}
