using AdvisementManagerWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvisementManagerWebApp.Temp
{
    public class TestUtilities
    {
        /// <summary>
        /// Temporary method for testing without login functionality
        /// </summary>
        /// <returns>A test student</returns>
        public static Student GetTestStudent()
        {
            Advisor generalAdvisor = new Advisor()
            {
                Id = 1,
                FirstName = "Wilman",
                LastName = "Kala",
                IsFacultyAdvisor = false,
                Email = "wkala@askj.net"
            };

            Advisor facultyAdvisor = new Advisor()
            {
                Id = 2,
                FirstName = "Tom",
                LastName = "Erichsen",
                IsFacultyAdvisor = true,
                Email = "terichsen@askj.net"
            };

            Hold testHold = new Hold()
            {
                Id = 1,
                Reason = "Student must meet with general advisor",
                Date = Convert.ToDateTime("05/05/2005"),
                IsActive = true
            };

            Student testStudent = new Student()
            {
                Id = 2,
                FirstName = "Hank",
                LastName = "Hill",
                Email = "hhill@my.askj.net",
                GeneralAdvisor = generalAdvisor,
                FacultyAdvisor = facultyAdvisor,
                Hold = testHold
            };

            return testStudent;
        }
    }
}
