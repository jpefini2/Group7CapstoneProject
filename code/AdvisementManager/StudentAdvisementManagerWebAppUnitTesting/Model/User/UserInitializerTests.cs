using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerSharedLibraryUnitTesting.Model.User
{
    [TestClass]
    public class UserInitializerTests
    {
        [TestMethod]
        public void UserInitializerTest()
        {
            var user = new AdvisementManagerSharedLibrary.Models.User
            {
                Username = "jJohnson",
                PasswordHash = "hashedPassword"
            };

            Assert.AreEqual("jJohnson", user.Username);
            Assert.AreEqual("hashedPassword", user.PasswordHash);
        }
    }
}
