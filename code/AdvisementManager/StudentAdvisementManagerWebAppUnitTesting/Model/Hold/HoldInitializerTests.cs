using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibraryUnitTesting.Model.Hold
{
    [TestClass]
    public class HoldInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var date = new DateTime();
            var hold = new AdvisementManagerSharedLibrary.Models.Hold
            {
                Id = 1,
                Reason = "No hold",
                Date = date,
                IsActive = false,
                StudentId = 1
            };

            Assert.AreEqual(hold.Date, date);
            Assert.AreEqual(hold.Reason, "No hold");
            Assert.AreEqual(hold.Id, 1);
            Assert.AreEqual(hold.IsActive, false);
            Assert.AreEqual(hold.StudentId, 1);

        }
    }
}
