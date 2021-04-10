using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using AdvisementManagerWebApp;
using AdvisementManagerWebApp.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Net.Http.Headers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NSubstitute;
using RestSharp;
using Xunit;

namespace AdvisementManagerWebAppUnitTesting.Controller.AdvisementSessionsController
{
    [TestClass]
    public class AdvisementSessionTests : IClassFixture<WebApplicationFactory<Startup>>
    {

        [TestMethod]
        public void AdvisementSessionTest()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                          .Options;
            using (var context = new ApplicationDbContext(options))
            {
                context.Hold.Add(new Hold { Id = 1, Reason = "Meet advisor", StudentId = 1, IsActive = false, Date = DateTime.Now});
                var student = new Student {
                    Id = 1,
                    FirstName = "a",
                    LastName = "b",
                    Email = "asas",
                    facultyAdvisorId = 1,
                    generalAdvisorId = 2,
                    Hold = context.Hold.Find(1)
                };

                context.Student.Add(student);

                context.Advisor.Add(new Advisor { Id = 2, UserName = "terichsen" });
                context.Advisor.Add(new Advisor {Id = 1});
                context.AdvisementSession.Add(new AdvisementSession {Id = 1, AdvisorId = 1, Student = student, StudentId = 1});

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var controller = new AdvisementManagerWebApp.Controllers.AdvisementSessionsController(context);
                var session = controller.AdvisementSession(1);

                Assert.IsNotNull(session);
                context.Database.EnsureDeleted();
            }
        }
    }

}
