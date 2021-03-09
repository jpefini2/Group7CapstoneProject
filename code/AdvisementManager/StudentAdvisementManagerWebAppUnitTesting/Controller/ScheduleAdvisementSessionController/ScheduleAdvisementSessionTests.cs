using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibraryUnitTesting.Controller.ScheduleAdvisementSessionController
{
    [TestClass]
    public class ScheduleAdvisementSessionTests
    {
        [TestMethod]
        public void ScheduleAdvisementWithDepartmentAdvisementHold()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            Hold hold = this.getHold("need to meet with dept advisor");
            Advisor dAdvisor = this.getDeptAdvisor();
            Advisor fAdvisor = this.getFacultyAdvisor();
            Student student = this.getStudent(dAdvisor, fAdvisor, hold);

            using (var context = new ApplicationDbContext(options))
            {
                context.Hold.Add(hold);
                context.Advisor.Add(dAdvisor);
                context.Advisor.Add(fAdvisor);
                context.Student.Add(student);

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new StudentAdvisementManagerWebApp.Controllers.AdvisementSessionController(context);
                var scheduleAdvisement = controller.ScheduleAdvisementSession(student.Id, hold.Reason, dAdvisor.Id, fAdvisor.Id);

                Assert.IsNotNull(scheduleAdvisement);
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void ScheduleAdvisementWithFacultyAdvisementHold()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            Hold hold = this.getHold("need to meet with faculty advisor");
            Advisor dAdvisor = this.getDeptAdvisor();
            Advisor fAdvisor = this.getFacultyAdvisor();
            Student student = this.getStudent(dAdvisor, fAdvisor, hold);

            using (var context = new ApplicationDbContext(options))
            {
                context.Hold.Add(hold);
                context.Advisor.Add(dAdvisor);
                context.Advisor.Add(fAdvisor);
                context.Student.Add(student);

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new StudentAdvisementManagerWebApp.Controllers.AdvisementSessionController(context);
                var scheduleAdvisement = controller.ScheduleAdvisementSession(student.Id, hold.Reason, dAdvisor.Id, fAdvisor.Id);

                Assert.IsNotNull(scheduleAdvisement);
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void ScheduleAdvisementWithOtherAdvisementHold()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            Hold hold = this.getHold("No holds");
            Advisor dAdvisor = this.getDeptAdvisor();
            Advisor fAdvisor = this.getFacultyAdvisor();
            Student student = this.getStudent(dAdvisor, fAdvisor, hold);

            using (var context = new ApplicationDbContext(options))
            {
                context.Hold.Add(hold);
                context.Advisor.Add(dAdvisor);
                context.Advisor.Add(fAdvisor);
                context.Student.Add(student);

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new StudentAdvisementManagerWebApp.Controllers.AdvisementSessionController(context);
                var scheduleAdvisement = controller.ScheduleAdvisementSession(student.Id, hold.Reason, dAdvisor.Id, fAdvisor.Id);

                Assert.IsNotNull(scheduleAdvisement);
                context.Database.EnsureDeleted();
            }
        }

        #region Helpers

        private Student getStudent(Advisor dAdvisor, Advisor fAdvisor, Hold hold)
        {
            return new Student
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

        private Advisor getDeptAdvisor()
        {
            return new Advisor
            {
                Id = 1,
                FirstName = "Department",
                LastName = "Advisor",
                Email = "dAdvisor@gmail.com",
                IsFacultyAdvisor = false
            };
        }

        private Advisor getFacultyAdvisor()
        {
            return new Advisor
            {
                Id = 2,
                FirstName = "Faculty",
                LastName = "Advisor",
                Email = "fAdvisor@gmail.com",
                IsFacultyAdvisor = true
            };
        }

        private Hold getHold(string holdReason)
        {
            return new Hold
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
