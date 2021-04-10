using System;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdvisementManagerWebAppUnitTesting.Controller.AdvisementSessionsController
{
    [TestClass]
    public class ApproveMeetingTests
    {
        [TestMethod]
        public void ApproveMeetingAsGeneralAdvisorTest()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                          .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Advisor.Add(new Advisor {Id = 1, IsFacultyAdvisor = false, UserName = "wakala" });

                context.Hold.Add(new Hold {Id = 1, Reason = string.Empty});

                context.AdvisementSession.Add(new AdvisementSession {Id = 1, Date = DateTime.Now, Completed = false});
                context.Student.Add(new Student {
                    Id = 1,
                    Meeting = context.AdvisementSession.Find(1),
                    Hold = context.Hold.Find(1)
                });

                context.SaveChanges();

            }

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new AdvisementManagerWebApp.Controllers.AdvisementSessionsController(context);
                controller.ApproveMeeting(1, DateTime.Now, 1, 1, "notes", "wakala");

                Assert.AreEqual(true, context.AdvisementSession.Find(1).Completed);
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void ApproveMeetingAsFacultyAdvisorTest()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                          .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Advisor.Add(new Advisor { Id = 1, IsFacultyAdvisor = true });

                context.Hold.Add(new Hold { Id = 1, Reason = string.Empty });

                context.AdvisementSession.Add(new AdvisementSession { Id = 1, Date = DateTime.Now, Completed = false });
                context.Student.Add(new Student
                {
                    Id = 1,
                    Meeting = context.AdvisementSession.Find(1),
                    Hold = context.Hold.Find(1)
                });

                context.SaveChanges();

            }

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new AdvisementManagerWebApp.Controllers.AdvisementSessionsController(context);
                controller.ApproveMeeting(1, DateTime.Now, 1, 1, "notes", "wakala");

                Assert.AreEqual(true, context.AdvisementSession.Find(1).Completed);
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void ApproveMeetingBeforeMeetingTimeTest()
        {
            //create In Memory Database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                          .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Advisor.Add(new Advisor { Id = 1, IsFacultyAdvisor = false, UserName = "wakala" });

                context.Hold.Add(new Hold { Id = 1, Reason = string.Empty });

                context.AdvisementSession.Add(new AdvisementSession { Id = 1, Date = DateTime.MaxValue, Completed = false });
                context.Student.Add(new Student
                {
                    Id = 1,
                    Meeting = context.AdvisementSession.Find(1),
                    Hold = context.Hold.Find(1)
                });

                context.SaveChanges();

            }

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new AdvisementManagerWebApp.Controllers.AdvisementSessionsController(context);
                var mockTempData = new Mock<ITempDataDictionary>();
                controller.TempData = mockTempData.Object;

                var result = controller.ApproveMeeting(1, DateTime.MaxValue, 1, 1, "notes", "wakala");

                Assert.IsNull(result.RouteValues["AdvisementSessions"]);
                context.Database.EnsureDeleted();
            }
        }
    }
}
