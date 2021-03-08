using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Controller.AdvisementSessionsController
{
    [TestClass]
    public class AdvisementSessionsTests
    {
        [TestMethod]
        public void AdvisementSessionsTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Advisor.Add(new Advisor {Id = 1, UserName = "wakala"});

                context.Hold.Add(new Hold { Id = 1, Reason = string.Empty });
                context.Student.Add(new Student
                {
                    Id = 1,
                    FirstName = "a",
                    LastName = "b",
                    Email = "asas",
                    facultyAdvisorId = 1,
                    generalAdvisorId = 2,
                    Hold = context.Hold.Find(1)
                });

                context.Hold.Add(new Hold { Id = 2, Reason = string.Empty });
                context.Student.Add(new Student
                {
                    Id = 2,
                    Hold = context.Hold.Find(2)
                });

                context.SaveChanges();

            }

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new AdvisementManagerWebApp.Controllers.AdvisementSessionsController(context);
                var studentsWithHolds = controller.AdvisementSessions("wakala");

                Assert.IsNotNull(studentsWithHolds);
                context.Database.EnsureDeleted();
            }
        }
    }
}
