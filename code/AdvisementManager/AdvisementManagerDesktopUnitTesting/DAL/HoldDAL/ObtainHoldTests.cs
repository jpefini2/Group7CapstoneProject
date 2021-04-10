using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.DAL.HoldDAL
{
    [TestClass]
    public class ObtainHoldTests
    {
        [TestMethod]
        public void ObtainHoldTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            var hold = new Hold { Id = 1, StudentId = 2};

            using (var context = new ApplicationDbContext(options))
            {
                context.Hold.Add(hold);

                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var holdDal = new AdvisementManagerSharedLibrary.DAL.HoldDAL();
                var expectedHold = holdDal.ObtainHold(2, context);

                Assert.AreEqual(1, expectedHold.Id);
                context.Database.EnsureDeleted();
            }
        }
    }
}
