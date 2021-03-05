using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.AdvisementSessionVM
{
    [TestClass]
    public class AdvisementSessionVMInitializerTests
    {
        [TestMethod]
        public void AdvisementSessionVmInitializerTest()
        {
            var student = new AdvisementManagerSharedLibrary.Models.Student();
            var advisor = new AdvisementManagerSharedLibrary.Models.Advisor();
            var sessionVm = new AdvisementManagerSharedLibrary.Models.AdvisementSessionVM 
            {
                student = student,
                advisor = advisor
            };

            Assert.AreEqual(student, sessionVm.student);
            Assert.AreEqual(advisor, sessionVm.advisor);
        }
    }
}
