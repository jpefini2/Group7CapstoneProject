using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdvisementManagerWebAppUnitTesting.Model.AdvisementSession
{
    [TestClass]
    public class AdvisementSessionInitializerTest
    {
        [TestMethod]
        public void InitializerTest()
        {
            var student = new StudentAdvisementManagerWebApp.Models.Student();
            var advisor = new StudentAdvisementManagerWebApp.Models.Advisor();

            var advisementSession = new StudentAdvisementManagerWebApp.Models.AdvisementSession
            {
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
