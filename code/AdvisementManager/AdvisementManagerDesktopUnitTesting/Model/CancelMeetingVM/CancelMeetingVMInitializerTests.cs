using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.CancelMeetingVM
{
    [TestClass]
    public class CancelMeetingVMInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var advisor = new AdvisementManagerSharedLibrary.Models.Advisor();
            var student = new AdvisementManagerSharedLibrary.Models.Student();
            var meeting = new AdvisementManagerSharedLibrary.Models.AdvisementSession();


            var cancelVM = new AdvisementManagerSharedLibrary.Models.CancelMeetingVM {
                Advisor = advisor,
                Student = student,
                Meeting = meeting
            };

            Assert.AreEqual(cancelVM.Advisor, advisor);
            Assert.AreEqual(cancelVM.Student, student);
            Assert.AreEqual(cancelVM.Meeting, meeting);
        }
    }
}
