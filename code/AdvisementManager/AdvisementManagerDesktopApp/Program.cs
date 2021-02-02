using System;
using System.Windows.Forms;
using AdvisementManagerDesktopApp.Model;
using AdvisementManagerDesktopApp.View;

namespace AdvisementManagerDesktopApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var advisor1 = new Advisor {
                Id = 3,
                FirstName = "Jenny",
                LastName = "Jade",
                IsFacultyAdvisor = false,
                Email = "jennyJade@gmail.com"
            };

            var hold = new Hold
            {
                Id = 2,
                Reason = "Fees not paid",
                Date = DateTime.Now,
                IsActive = true
            };

            var student = new Student
            {
                Id = 2,
                FirstName = "Josh",
                LastName = "Michael",
                Email = "joshMichael@gmail.com",
                GeneralAdvisor = advisor1,
                FacultyAdvisor = advisor1,
                Hold = hold


            };
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
