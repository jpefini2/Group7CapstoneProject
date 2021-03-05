using AdvisementManagerSharedLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Controller.AdvisementSessionsController
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
            var controller = new AdvisementManagerWebApp.Controllers.AdvisementSessionsController(context);

            Assert.AreEqual(context, controller.context);
            context.Database.EnsureDeleted();
        }
    }
}
