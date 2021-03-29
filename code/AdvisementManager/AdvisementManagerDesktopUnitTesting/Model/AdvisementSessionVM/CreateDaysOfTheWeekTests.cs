using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.Model.AdvisementSessionVM
{
    [TestClass]
    public class CreateDaysOfTheWeekTests
    {
        [TestMethod]
        public void CreateDaysTests()
        {
            var VM = new AvailabilityVM();

            var days = VM.DaysOfWeek;
            var daysToCompare = AvailabilityVM.CreateDaysOfWeek();

            var counter = 0;
            foreach (var day in days)
            {
                Assert.AreEqual(day.Text, daysToCompare[counter].Text);
                counter++;
            }
        }
    }
}
