using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentAdvisementManagerWebApp.Data;
using StudentAdvisementManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdvisementManagerWebAppUnitTesting.DAL.StudentDal
{
    [TestClass]
    public class ObtainStudentWithIdTests
    {
        [TestMethod]
        public void ObtainStudentWithIdTest()
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
                var studentDal = new StudentAdvisementManagerWebApp.DAL.StudentDal();
                var returnStudent = studentDal.ObtainStudentWithId(1, context);

                Assert.AreEqual(student.FullName, returnStudent.FullName);
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void ObtainStudentWithUsernameTest()
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
                var studentDal = new StudentAdvisementManagerWebApp.DAL.StudentDal();
                var returnStudent = studentDal.ObtainStudentWithUsername("jJohnson", context);

                Assert.AreEqual(student.FullName, returnStudent.FullName);
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
                UserName = "jJohnson",
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
