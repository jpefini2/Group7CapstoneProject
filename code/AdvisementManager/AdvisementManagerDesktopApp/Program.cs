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

            var advisor2 = new Advisor
            {
                Id = 2,
                FirstName = "Josh",
                LastName = "Michael",
                IsFacultyAdvisor = true,
                Email = "joshMichael@gmail.com"
            };
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AdvisementSessionsForm(advisor2));
        }
    }
}
