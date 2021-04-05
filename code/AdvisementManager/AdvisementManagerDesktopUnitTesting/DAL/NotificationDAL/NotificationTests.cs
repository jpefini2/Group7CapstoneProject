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
                Email = "student@test.com",
                Message = "This is a test notification"
            };

            var notification2 = new Notification
            {
                Id = 2,
                Email = "student@test.com",
                Message = "This is another test notification"
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
                IList<Notification> expectedNotifications = nfDal.GetNotificationsByEmail("student@test.com", context);
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
                Email = "student@test.com",
                Message = "This is a test notification"
            };

            using (var context = new ApplicationDbContext(options))
            {
                context.Notification.Add(notification1);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext(options))
            {
                var nfDal = new AdvisementManagerSharedLibrary.DAL.NotificationDAL(context);
                Notification expectedNotification = nfDal.GetNotificationById(1, context);
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
                nfDal.AddNotification("student@test.com", "this is a test notification", context);
                Notification expectedNotification = nfDal.GetNotificationById(1, context);
                nfDal.AddNotification("student@test.com", "this is another test notification", context);
                IList<Notification> expectedNotifications = nfDal.GetNotificationsByEmail("student@test.com", context);
                Assert.IsNotNull(expectedNotification);
                Assert.AreEqual(1, expectedNotification.Id);
                Assert.AreEqual(2, expectedNotifications.Count);
                context.Database.EnsureDeleted();
            }
        }
    }
}
