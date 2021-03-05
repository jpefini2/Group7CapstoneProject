using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AdvisementDesktop.Model;

namespace AdvisementManagerDesktopUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var hello = "hello";
            var test = new testModelClass {
                hello = hello
            };

            Assert.AreEqual(hello, hello);
        }
    }
}
