using AdvisementManagerSharedLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerDesktopUnitTests.Model
{
    [TestClass]
    public class NotificationTests
    {
        [TestMethod]
        public void NotificationInitializerTest()
        {
            var notif = new Notification
            {
                Id = 1,
                StudentId = 1,
                AdvisorId = 1,
                NotifMessage = "test student has met with advisor"
            };
            Assert.IsNotNull(notif);

            Assert.AreEqual(notif.Id, 1);
            Assert.AreEqual(notif.StudentId, 1);
            Assert.AreEqual(notif.AdvisorId, 1);
            Assert.AreEqual(notif.NotifMessage, "test student has met with advisor");
        }
    }
}
