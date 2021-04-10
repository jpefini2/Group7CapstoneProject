using System;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationDbContext = AdvisementManagerSharedLibrary.Data.ApplicationDbContext;

namespace AdvisementManagerWebAppUnitTesting.Controller.AdvisementSessionsController
{
    [TestClass]
    public class RemoveHoldTests
    {
        [TestMethod]
        public void RedirectResultTest()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                          .Options;

            //// Create mocked Context by seeding Data as per Schema///

            using (var context = new ApplicationDbContext(options))
            {
                context.Hold.Add(new Hold {
                    Id = 1,
                    Reason = "waiting for hold to be removed",
                    Date = DateTime.Now,
                    IsActive = true,
                    StudentId = 1

                });
                context.Student.Add(new Student
                {
                    Id = 1,
                    facultyAdvisorId = 1,
                    generalAdvisorId = 2,
                    FirstName = "a",
                    LastName = "b"
                });
                context.Advisor.Add(new Advisor
                {
                    Id = 1,
                    FirstName = "a",
                    LastName = "b",
                    UserName = "wakala"
                });
                context.Advisor.Add(new Advisor
                {
                    Id = 2,
                    FirstName = "a",
                    LastName = "b",
                    UserName = "wakala"
                });
                context.SaveChanges();
            }

            // Use a Context instance  with Data to run the test for your Business code 

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new AdvisementManagerWebApp.Controllers.AdvisementSessionsController(context);
                controller.RemoveHold(1, "wakala");

                Assert.AreEqual(false, context.Hold.Find(1).IsActive);
                context.Database.EnsureDeleted(); // Deletes inMemory database so the content doesn't affect unit test that are called after each other.
            }
        }
    }
}
