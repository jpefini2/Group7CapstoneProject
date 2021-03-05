using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.ErrorViewModel
{
    [TestClass]
    public class ErrorViewModelInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var error = new AdvisementManagerSharedLibrary.Models.ErrorViewModel {
                RequestId = "a",
            };

            Assert.AreEqual(error.RequestId, "a");
            Assert.AreEqual(error.ShowRequestId, true);
        }
    }
}
