using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.AdvisementSessionVM
{
    [TestClass]
    public class AdvisementSessionVMInitializerTests
    {
        [TestMethod]
        public void AdvisementSessionVmInitializerTest()
        {
            var student = new AdvisementManagerWebApp.Models.Student();
            var advisor = new AdvisementManagerWebApp.Models.Advisor();
            var sessionVm = new AdvisementManagerWebApp.Models.AdvisementSessionVM 
            {
                student = student,
                advisor = advisor
            };

            Assert.AreEqual(student, sessionVm.student);
            Assert.AreEqual(advisor, sessionVm.advisor);
        }
    }
}
