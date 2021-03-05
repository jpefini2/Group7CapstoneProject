using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibraryUnitTesting.Model.ErrorViewModel
{
    [TestClass]
    public class ErrorViewModelInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var error = new AdvisementManagerSharedLibrary.Models.ErrorViewModel
            {
                RequestId = "a",
            };

            Assert.AreEqual(error.RequestId, "a");
            Assert.AreEqual(error.ShowRequestId, true);
        }
    }
}
