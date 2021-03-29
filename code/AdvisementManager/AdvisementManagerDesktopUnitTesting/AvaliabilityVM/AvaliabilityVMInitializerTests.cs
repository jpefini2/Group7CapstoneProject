using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdvisementManagerWebAppUnitTesting.AvaliabilityVM
{
    [TestClass]
    public class AvaliabilityVMInitializerTests
    {
        [TestMethod]
        public void InitializerTest()
        {
            var advisor = new Advisor{Id = 1};
            var day = "Monday";
            var startTime = "2:00";
            var endTime = "3:00";
            var timeSlots = new List<SelectListItem>();
            var timeLoop = new DateTime(0);
            timeLoop = timeLoop.Add(new TimeSpan(00, 00, 0));
            const int numberOfIntervals = 48;

            for (var i = 0; i < numberOfIntervals; i++)
            {
                var time = timeLoop.ToString("h:mm tt");
                timeSlots.Add(new SelectListItem { Value = time, Text = time });
                timeLoop = timeLoop.Add(new TimeSpan(0, 30, 0));
            }


            var avaliabilityVM = new AvailabilityVM {
                CurrentUser = advisor,
                Day = day,
                StartTime = startTime,
                EndTime = endTime
            };
            
            Assert.AreEqual(avaliabilityVM.CurrentUser, advisor);
            Assert.AreEqual(avaliabilityVM.AdvisorId, 1);
            Assert.AreEqual(avaliabilityVM.Day, day);
            Assert.AreEqual(avaliabilityVM.StartTime, startTime);
            Assert.AreEqual(avaliabilityVM.EndTime, endTime);
            Assert.IsNotNull(avaliabilityVM.DaysOfWeek);
            Assert.IsNotNull(avaliabilityVM.TimeSlots);
        }
    }
}
