using System;
using AdvisementManagerWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.AdvisementSession
{
    [TestClass]
    public class AdvisementSessionInitializerTests
    {
        [TestMethod] 
        public void InitializerTest()
        {
            var student = new Student();
            var advisor = new Advisor();
            
            var advisementSession = new AdvisementManagerWebApp.Models.AdvisementSession {
                Stage = 1,
                Completed = false,
                Advisor = advisor,
                Date = new DateTime(),
                Id = 1,
                EndDate = new DateTime(),
                Student = student
            };

            Assert.AreEqual(advisementSession.Student, student);
            Assert.AreEqual(advisementSession.Stage, 1);
            Assert.AreEqual(advisementSession.Advisor, advisor);
            Assert.AreEqual(advisementSession.Date, new DateTime());
            Assert.AreEqual(advisementSession.EndDate, new DateTime());
            Assert.AreEqual(advisementSession.Completed, false);
            Assert.AreEqual(advisementSession.Id, 1);
        }
        
    }
}
