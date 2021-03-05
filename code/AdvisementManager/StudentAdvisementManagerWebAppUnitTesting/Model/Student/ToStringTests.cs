using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerSharedLibraryUnitTesting.Model.Student
{
    [TestClass]
    public class ToStringTests
    {
        [TestMethod]
        public void ToStringTest()
        {
            var student = new AdvisementManagerSharedLibrary.Models.Student {
                FirstName = "a",
                LastName = "b"
            };

            Assert.AreEqual("a b", student.ToString());
        }
    }
}
