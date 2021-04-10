using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Models;
using AdvisementManagerWebAppUnitTesting.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ApplicationDbContext = AdvisementManagerSharedLibrary.Data.ApplicationDbContext;

namespace AdvisementManagerWebAppUnitTesting.Controller.CancelMeetingController
{
    [TestClass]
    public class CancelMeetingTests
    {
        [TestMethod]
        public void CancelMeetingTest()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                          .Options;
            using (var context = new ApplicationDbContext(options))
            {
                context.Advisor.Add(new Advisor {Id = 1, IsFacultyAdvisor = false, UserName = "wakala"});

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

                var controller = new AdvisementManagerWebApp.Controllers.CancelMeetingController(context);
                var result = controller.CancelMeeting(1, 1);


                Assert.IsInstanceOfType(result, typeof(ViewResult));
                context.Database.EnsureDeleted();
            }
        }

    }
}
