using System.Collections.Generic;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.AdvisementSession
{
    [TestClass]
    public class StudentsVMInitializerTests
    {

        [TestMethod]
        public void InitializerTest()
        {
            var student1 = new AdvisementManagerSharedLibrary.Models.Student();
            var student2 = new AdvisementManagerSharedLibrary.Models.Student();

            var students = new List<AdvisementManagerSharedLibrary.Models.Student> {student1, student2};

            var StudentsVM = new AdvisorHomeVM() {
                StudentsWithHolds = students
            };

            Assert.AreEqual(StudentsVM.StudentsWithHolds.Count, 2);
        }

    }
}
