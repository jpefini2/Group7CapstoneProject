using System;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.AdvisementSession
{
    [TestClass]
    public class AdvisementSessionInitializerTests
    {
        [TestMethod] 
        public void InitializerTest()
        {
            var student = new AdvisementManagerSharedLibrary.Models.Student();
            var advisor = new AdvisementManagerSharedLibrary.Models.Advisor();
            
            var advisementSession = new AdvisementManagerSharedLibrary.Models.AdvisementSession {
                Stage = 1,
                Completed = false,
                Advisor = advisor,
                Date = new DateTime(),
                Id = 1,
                EndDate = new DateTime(),
                Student = student,
                StudentId = 1,
                AdvisorId = 1,

            };

            Assert.AreEqual(advisementSession.Student, student);
            Assert.AreEqual(advisementSession.Stage, 1);
            Assert.AreEqual(advisementSession.Advisor, advisor);
            Assert.AreEqual(advisementSession.Date, new DateTime());
            Assert.AreEqual(advisementSession.EndDate, new DateTime());
            Assert.AreEqual(advisementSession.Completed, false);
            Assert.AreEqual(advisementSession.Id, 1);
            Assert.AreEqual(advisementSession.StudentId, 1);
            Assert.AreEqual(advisementSession.AdvisorId, 1);
        }
        
    }
}
