using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibraryUnitTesting.Model.Advisor
{
    [TestClass]
    public class ToStringTests
    {
        [TestMethod]
        public void ToStringTest()
        {
            var advisor = new AdvisementManagerSharedLibrary.Models.Advisor
            {
                FirstName = "John",
                LastName = "Johnson",
                Id = 1,
                IsFacultyAdvisor = false,
                Email = "jJohnson@gmail.com"
            };

            Assert.AreEqual("John Johnson", advisor.ToString());
        }
    }
}
