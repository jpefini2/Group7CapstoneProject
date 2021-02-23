using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentAdvisementManagerWebAppUnitTesting.Model.Student
{
    [TestClass]
    public class AdvisementStatusMessageTests
    {
        [TestMethod]
        public void AdvisementStatusMessageWithHoldTest()
        {
            var student = new StudentAdvisementManagerWebApp.Models.Student
            {
                Hold = new StudentAdvisementManagerWebApp.Models.Hold { IsActive = true, Reason = "Some reason"}
            };

            Assert.AreEqual("Incomplete - " + student.Hold.Reason, student.AdvisementStatusMessage);
        }

        [TestMethod]
        public void AdvisementStatusMessageWithNoHoldTest()
        {
            var student = new StudentAdvisementManagerWebApp.Models.Student
            {
                Hold = new StudentAdvisementManagerWebApp.Models.Hold { IsActive = false }
            };

            Assert.AreEqual("Complete", student.AdvisementStatusMessage);
        }
    }
}
