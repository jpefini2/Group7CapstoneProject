using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using AdvisementManagerSharedLibrary.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AdvisementManagerWebAppUnitTesting.DAL.LoginDAL
{
    [TestClass]
    public class LoginDALTests
    {
        Student student;
        Advisor advisor;
        User user;

        [TestInitialize]
        public void Setup()
        {
            student = new Student
            {
                Id = 0,
                FirstName = "Craig",
                LastName = "Playstead",
                Email = "cplay@fjasp.net",
                generalAdvisorId = 0,
                facultyAdvisorId = 0
            };

            advisor = new Advisor
            {
                Id = 0,
                FirstName = "Gina",
                LastName = "Smith",
                Email = "cplay@fjasp.net",
                IsFacultyAdvisor = true,
                UserName = "gsmith"
            };

            user = new User
            {
                Username = "gsmith",
                PasswordHash = "$2a$12$X552DMehlH2hKatG8SR8gOqsBt6O20eUZ0vglH0h/ZPr9sSI5z96S"
            };


        }
        [TestMethod]
        public void LoginDALCorrectPasswordTest()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Add(student);
                context.Add(advisor);
                context.Add(user);
                context.SaveChanges();

                string correctpassword = "password1";

                var loginDAL = new AdvisementManagerSharedLibrary.DAL.LoginDAL(context);
                string hash = loginDAL.AttemptLogin("gsmith", correctpassword, LoginType.ADVISOR);
                if (string.IsNullOrEmpty(hash))
                {
                    throw new AssertFailedException();
                }
                Assert.IsTrue(BCrypt.Net.BCrypt.Verify(correctpassword, user.PasswordHash));
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void LoginDALIncorrectPasswordTest()
        {

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Add(student);
                context.Add(advisor);
                context.Add(user);
                context.SaveChanges();

                string wrongpassword = "ThisPasswordIsWrong";

                var loginDAL = new AdvisementManagerSharedLibrary.DAL.LoginDAL(context);
                string hash = loginDAL.AttemptLogin("gsmith", wrongpassword, LoginType.ADVISOR);
                Assert.IsNull(hash);
                Assert.IsFalse(BCrypt.Net.BCrypt.Verify(wrongpassword, user.PasswordHash));
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void LoginDALEmptyPasswordTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Add(student);
                context.Add(advisor);
                context.Add(user);
                context.SaveChanges();

                string inputpassword = "";

                var loginDAL = new AdvisementManagerSharedLibrary.DAL.LoginDAL(context);
                string hash = loginDAL.AttemptLogin("gsmith", inputpassword, LoginType.ADVISOR);
                Assert.IsNull(hash);
                Assert.IsFalse(BCrypt.Net.BCrypt.Verify(inputpassword, user.PasswordHash));
                context.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void LoginDALEmptyUserTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(databaseName: "AdvisementManagement")
                          .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.Add(student);
                context.Add(advisor);
                context.Add(user);
                context.SaveChanges();

                string inputpassword = "password1";

                var loginDAL = new AdvisementManagerSharedLibrary.DAL.LoginDAL(context);
                string hash = loginDAL.AttemptLogin("", inputpassword, LoginType.ADVISOR);
                Assert.IsNull(hash);
                context.Database.EnsureDeleted();
            }
        }
    }
}
