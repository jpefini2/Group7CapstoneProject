using AdvisementManagerSharedLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibraryUnitTesting.Controller.HomeController
{
    [TestClass]
    public class ConstructorTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            using var context = new ApplicationDbContext(options);
            var controller = new StudentAdvisementManagerWebApp.Controllers.HomeController(context);

            Assert.AreEqual(context, controller.context);
            context.Database.EnsureDeleted();
        }
    }
}
