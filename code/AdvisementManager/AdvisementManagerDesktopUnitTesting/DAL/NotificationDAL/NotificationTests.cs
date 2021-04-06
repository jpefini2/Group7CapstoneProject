using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvisementManagerWebAppUnitTesting.DAL.NotificationDAL
{
    [TestClass]
    public class NotificationTests
    {
        public void GetNotificationsTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            var notification1 = new Notification
            {
                Id = 1,
                AdvisorId = 1,
                StudentId = 1
            };

            var notification2 = new Notification
            {
                Id = 2,
                AdvisorId = 1,
                StudentId = 1
            };

            using (var context = new ApplicationDbContext(options))
            {
                context.Notification.Add(notification1);
                context.Notification.Add(notification2);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var nfDal = new AdvisementManagerSharedLibrary.DAL.NotificationDAL(context);
                IList<Notification> expectedNotifications = nfDal.GetNotificationsByBothID(1, 1, context);
                Assert.AreEqual(2, expectedNotifications.Count);
                context.Database.EnsureDeleted();
            }                
        }

        public void GetSingleNotificationTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            var notification1 = new Notification
            {
                Id = 1,
                AdvisorId = 1,
                StudentId = 1
            };

            using (var context = new ApplicationDbContext(options))
            {
                context.Notification.Add(notification1);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var nfDal = new AdvisementManagerSharedLibrary.DAL.NotificationDAL(context);
                Notification expectedNotification = nfDal.GetNotificationByKeyId(1, context);
                Assert.IsNotNull(expectedNotification);
                Assert.AreEqual(1, expectedNotification.Id);
                context.Database.EnsureDeleted();
            }
        }
        public void AddNotificationTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;


            using (var context = new ApplicationDbContext(options))
            {
                var nfDal = new AdvisementManagerSharedLibrary.DAL.NotificationDAL(context);
                nfDal.AddNotification("test notification", 1, 1, context);
                Notification expectedNotification = nfDal.GetNotificationByKeyId(1, context);
                nfDal.AddNotification("this is another test notification", 1, 1, context);
                IList<Notification> expectedNotifications = nfDal.GetNotificationsByBothID(1, 1, context);
                Assert.IsNotNull(expectedNotification);
                Assert.AreEqual(1, expectedNotification.Id);
                Assert.AreEqual(2, expectedNotifications.Count);
                context.Database.EnsureDeleted();
            }
        }
    }
}
