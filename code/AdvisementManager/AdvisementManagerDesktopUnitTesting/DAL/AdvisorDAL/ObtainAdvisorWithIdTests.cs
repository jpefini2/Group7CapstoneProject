using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.DAL.AdvisorDAL
{
    [TestClass]
    public class ObtainAdvisorWithIdTests
    {
        [TestMethod]
        public void ObtainAdvisorWithIdTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            var advisor = new Advisor {Id = 1};

            using (var context = new ApplicationDbContext(options))
            {
                context.Advisor.Add(advisor);

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var advisorDal = new AdvisementManagerWebApp.DAL.AdvisorDAL();
                var expectedAdvisor = advisorDal.ObtainAdvisorWithId(1, context);

                Assert.AreEqual(1, expectedAdvisor.Id);
                context.Database.EnsureDeleted();
            }
        }
    }
}
