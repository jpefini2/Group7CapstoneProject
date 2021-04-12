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
    public class AvailabilityTests
    {
        [TestMethod]
        public void AvailabilityInitializerTest()
        {
            var avail = new Availability
            {
                Id = 1,
                DayOfTheWeek = 1,
                StartTime = new TimeSpan(),
                EndTime = new TimeSpan(),
                AdvisorId = 1
            };
            Assert.IsNotNull(avail);

            Assert.AreEqual(avail.Id, 1);
            Assert.AreEqual(avail.DayOfTheWeek, 1);
            Assert.AreEqual(avail.AdvisorId, 1);
        }
    }
}
