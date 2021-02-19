using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.Advisor
{
    [TestClass]
    public class ToStringTests
    {

        [TestMethod]
        public void ToStringTest()
        {
            var advisor = new AdvisementManagerWebApp.Models.Advisor
            {
                FirstName = "a",
                LastName = "b",
                Id = 1,
                IsFacultyAdvisor = false,
                Email = "ad"
            };

            Assert.AreEqual("a b", advisor.ToString());
        }
    }
}
