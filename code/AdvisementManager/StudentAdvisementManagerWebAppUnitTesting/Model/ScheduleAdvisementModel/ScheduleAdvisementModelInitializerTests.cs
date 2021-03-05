using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdvisementManagerSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibraryUnitTesting.Model.ScheduleAdvisementModel
{
    [TestClass]
    public class ScheduleAdvisementModelInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var hold = this.getHold("No holds");
            var dAdvisor = this.getDeptAdvisor();
            var fAdvisor = this.getFacultyAdvisor();
            var student = this.getStudent(dAdvisor, fAdvisor, hold);

            var date = DateTime.Now;
            var time = TimeSpan.Zero;

            var model = new AdvisementManagerSharedLibrary.Models.ScheduleAdvisementModel
            {
                Student = student,
                Advisor = dAdvisor,
                Date = date,
                Time = time
            };
            model.SetAvailableSessionTimesListItems(dAdvisor);

            Assert.AreEqual(model.Student, student);
            Assert.AreEqual(model.Advisor, dAdvisor);
            Assert.AreEqual(model.StudentId, student.Id);
            Assert.AreEqual(model.AdvisorId, dAdvisor.Id);
            Assert.AreEqual(model.Date, date);
            Assert.AreEqual(model.Time, time);
            Assert.IsTrue(model.AvailableSessionTimes.Count > 0);
        }


        #region Helpers

        private AdvisementManagerSharedLibrary.Models.Student getStudent(AdvisementManagerSharedLibrary.Models.Advisor dAdvisor,
                AdvisementManagerSharedLibrary.Models.Advisor fAdvisor, AdvisementManagerSharedLibrary.Models.Hold hold)
        {
            return new AdvisementManagerSharedLibrary.Models.Student
            {
                Id = 1,
                FirstName = "John",
                LastName = "Johnson",
                Email = "jJohnson@gmail.com",
                generalAdvisorId = 1,
                facultyAdvisorId = 2,
                GeneralAdvisor = dAdvisor,
                FacultyAdvisor = fAdvisor,
                Hold = hold
            };
        }

        private AdvisementManagerSharedLibrary.Models.Advisor getDeptAdvisor()
        {
            return new AdvisementManagerSharedLibrary.Models.Advisor
            {
                Id = 1,
                FirstName = "Department",
                LastName = "Advisor",
                Email = "dAdvisor@gmail.com",
                IsFacultyAdvisor = false
            };
        }

        private AdvisementManagerSharedLibrary.Models.Advisor getFacultyAdvisor()
        {
            return new AdvisementManagerSharedLibrary.Models.Advisor
            {
                Id = 2,
                FirstName = "Faculty",
                LastName = "Advisor",
                Email = "fAdvisor@gmail.com",
                IsFacultyAdvisor = true
            };
        }

        private AdvisementManagerSharedLibrary.Models.Hold getHold(string holdReason)
        {
            return new AdvisementManagerSharedLibrary.Models.Hold
            {
                Id = 1,
                Reason = holdReason,
                Date = DateTime.Now,
                IsActive = true,
                StudentId = 1,
            };
        }

        #endregion
    }
}
