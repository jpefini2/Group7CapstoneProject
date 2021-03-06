﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ApplicationDbContext = AdvisementManagerSharedLibrary.Data.ApplicationDbContext;

namespace StudentAdvisementManagerWebAppUnitTesting.Controller.CancelMeetingController
{
    [TestClass]
    public class ConfirmCancelTests
    {
        [TestMethod]
        public void ConfirmCancelTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;
            using (var context = new ApplicationDbContext(options))
            {
                context.Advisor.Add(new Advisor { Id = 1, IsFacultyAdvisor = false, UserName = "wakala" });

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
                var tempDataProvider = Mock.Of<ITempDataProvider>();
                TempDataDictionaryFactory tempDataDictionaryFactory = new TempDataDictionaryFactory(tempDataProvider);
                ITempDataDictionary tempData = tempDataDictionaryFactory.GetTempData(new DefaultHttpContext());

                var controller = new StudentAdvisementManagerWebApp.Controllers.CancelMeetingController(context) {TempData = tempData};
                var result = controller.ConfirmCancel( 1);

                Assert.IsNull(context.AdvisementSession.Find(1));
                context.Database.EnsureDeleted();
            }
        }
    }
}
