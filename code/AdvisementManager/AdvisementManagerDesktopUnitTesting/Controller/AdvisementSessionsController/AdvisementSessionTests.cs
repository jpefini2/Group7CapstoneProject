using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerWebApp.Controllers;
using AdvisementManagerWebApp.DAL;
using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Controller.AdvisementSessionsController
{
    [TestClass]
    public class AdvisementSessionTests
    {
        //TODO finish this one.
        [TestMethod]
        private void AdvisementSessionTest()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            using (var context = new ApplicationDbContext(options))
            {
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

                context.Advisor.Add(new Advisor{Id = 2, UserName = "terichsen" });
                context.AdvisementSession.Add(new AdvisementSession{StudentId = 1});
                context.Login.Add(new User {Username = "terichsen", PasswordHash = "$2a$12$vM8iaJbPvt8z6VHq5AJauOoQiT485WcTerMmUTYH6eVhYIzhSKgrO" });


                var loginVM = new LoginViewModel {
                    Username = "terichsen",
                    Password = "password1"
                };

                context.SaveChanges();
                var accountController = new AccountController(context);

                accountController.Login(loginVM,2);
               

                //context.SaveChanges();
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
