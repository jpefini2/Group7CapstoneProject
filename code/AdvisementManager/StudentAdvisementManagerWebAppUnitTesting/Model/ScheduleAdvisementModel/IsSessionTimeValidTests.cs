﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentAdvisementManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdvisementManagerWebAppUnitTesting.Model.ScheduleAdvisementModel
{
    [TestClass]
    public class IsSessionTimeValidTests
    {
        [TestMethod]
        public void TestIsSessionTimeValid()
        {
            var hold = this.getHold("No holds");
            var dAdvisor = this.getDeptAdvisor();
            var fAdvisor = this.getFacultyAdvisor();
            var student = this.getStudent(dAdvisor, fAdvisor, hold);

            var date = DateTime.Now;
            var time = TimeSpan.FromSeconds(100);

            var model = new StudentAdvisementManagerWebApp.Models.ScheduleAdvisementModel
            {
                Student = student,
                Advisor = dAdvisor,
                Date = date,
                Time = time
            };

            Assert.IsFalse(model.IsSessionTimeValid);
        }


        #region Helpers

        private StudentAdvisementManagerWebApp.Models.Student getStudent(StudentAdvisementManagerWebApp.Models.Advisor dAdvisor,
                StudentAdvisementManagerWebApp.Models.Advisor fAdvisor, StudentAdvisementManagerWebApp.Models.Hold hold)
        {
            return new StudentAdvisementManagerWebApp.Models.Student
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

        private StudentAdvisementManagerWebApp.Models.Advisor getDeptAdvisor()
        {
            return new StudentAdvisementManagerWebApp.Models.Advisor
            {
                Id = 1,
                FirstName = "Department",
                LastName = "Advisor",
                Email = "dAdvisor@gmail.com",
                IsFacultyAdvisor = false
            };
        }

        private StudentAdvisementManagerWebApp.Models.Advisor getFacultyAdvisor()
        {
            return new StudentAdvisementManagerWebApp.Models.Advisor
            {
                Id = 2,
                FirstName = "Faculty",
                LastName = "Advisor",
                Email = "fAdvisor@gmail.com",
                IsFacultyAdvisor = true
            };
        }

        private StudentAdvisementManagerWebApp.Models.Hold getHold(string holdReason)
        {
            return new StudentAdvisementManagerWebApp.Models.Hold
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
