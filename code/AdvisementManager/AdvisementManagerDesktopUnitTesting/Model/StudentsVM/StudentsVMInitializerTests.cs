using System.Collections.Generic;
using AdvisementManagerWebApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.AdvisementSession
{
    [TestClass]
    public class StudentsVMInitializerTests
    {

        [TestMethod]
        public void InitializerTest()
        {
            var student1 = new AdvisementManagerWebApp.Models.Student();
            var student2 = new AdvisementManagerWebApp.Models.Student();

            var students = new List<AdvisementManagerWebApp.Models.Student> {student1, student2};

            var StudentsVM = new StudentsVM() {
                Students = students
            };

            Assert.AreEqual(StudentsVM.Students.Count, 2);
        }

    }
}
