using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.ErrorViewModel
{
    [TestClass]
    public class ErrorViewModelInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var error = new AdvisementManagerWebApp.Models.ErrorViewModel {
                RequestId = "a",
            };

            Assert.AreEqual(error.RequestId, "a");
            Assert.AreEqual(error.ShowRequestId, true);
        }
    }
}
