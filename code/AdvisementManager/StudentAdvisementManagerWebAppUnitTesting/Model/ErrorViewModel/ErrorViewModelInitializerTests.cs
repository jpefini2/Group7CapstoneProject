using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdvisementManagerWebAppUnitTesting.Model.ErrorViewModel
{
    [TestClass]
    public class ErrorViewModelInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var error = new StudentAdvisementManagerWebApp.Models.ErrorViewModel
            {
                RequestId = "a",
            };

            Assert.AreEqual(error.RequestId, "a");
            Assert.AreEqual(error.ShowRequestId, true);
        }
    }
}
