using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.Student
{
    [TestClass]
    public class AdvisementStatusMessageTests
    {
        [TestMethod]
        public void AdvisementStatusMessageWithHoldTest()
        {
            var student = new AdvisementManagerSharedLibrary.Models.Student
            {
                Hold = new AdvisementManagerSharedLibrary.Models.Hold { IsActive = true, Reason = "Some reason"}
            };

            Assert.AreEqual("Incomplete - " + student.Hold.Reason, student.AdvisementStatusMessage);
        }

        [TestMethod]
        public void AdvisementStatusMessageWithNoHoldTest()
        {
            var student = new AdvisementManagerSharedLibrary.Models.Student
            {
                Hold = new AdvisementManagerSharedLibrary.Models.Hold { IsActive = false }
            };

            Assert.AreEqual("Complete", student.AdvisementStatusMessage);
        }
    }
}
