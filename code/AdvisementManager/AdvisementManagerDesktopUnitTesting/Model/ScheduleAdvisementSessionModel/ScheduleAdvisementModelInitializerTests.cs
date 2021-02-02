using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.ScheduleAdvisementSessionModel
{
    [TestClass]
    public class ScheduleAdvisementModelInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var student = new Student();
            student.Id = 1;
            var advisor = new Advisor();
            advisor.Id = 2;

            ScheduleAdvisementModel model = new ScheduleAdvisementModel()
            {
                Student = student,
                Advisor = advisor,
                Date = DateTime.MaxValue,
                Time = TimeSpan.MaxValue
            };

            Assert.AreEqual(model.Student, student);
            Assert.AreEqual(model.Advisor, advisor);
            Assert.AreEqual(model.Date, DateTime.MaxValue);
            Assert.AreEqual(model.Time, TimeSpan.MaxValue);
            Assert.AreEqual(model.StudentId, 1);
            Assert.AreEqual(model.AdvisorId, 2);
        }
    }
}
