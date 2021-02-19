﻿using System;
using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.DAL.AdvisementSessionDAL
{
    [TestClass]
    public class ObtainSessionTests
    {
        [TestMethod]
        public void ObtainSessionTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            var session = new AdvisementSession { Id = 1, StudentId = 2, Completed = false, Date = DateTime.Now};

            using (var context = new ApplicationDbContext(options))
            {
                context.AdvisementSession.Add(session);

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var sessionDal = new AdvisementManagerWebApp.DAL.AdvisementSessionDAL();
                var expectedSession = sessionDal.ObtainSession(2, context);

                Assert.AreEqual(1, expectedSession.Id);
                context.Database.EnsureDeleted();
            }
        }

    }
}
