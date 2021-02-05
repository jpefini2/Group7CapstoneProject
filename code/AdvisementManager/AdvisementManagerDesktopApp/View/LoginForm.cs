using AdvisementManagerDesktopApp.Controller;
using AdvisementManagerDesktopApp.Model;
using System;
using System.Windows.Forms;

namespace AdvisementManagerDesktopApp.View
{
    public partial class LoginForm : Form
    {
        private readonly LoginController loginController = new();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButtonClicked(object sender, EventArgs e)
        {
            var hold = new Hold
            {
                Id = 2,
                Reason = "Fees not paid",
                Date = DateTime.Now,
                IsActive = true
            };
          
            if (!IsEntryValid(usernameTextBox.Text)) return;
            if(!IsEntryValid(passwordTextBox.Text)) return;

            var username = usernameTextBox.Text.Trim();
            var password = passwordTextBox.Text.Trim();

            if (this.loginController.Authenticate(username, password))
            {
                MessageBox.Show(@"Login OK.");
                Advisor advisor = this.loginController.InitializeLogin(username);
                var student = new Student
                {
                    Id = 2,
                    FirstName = "Josh",
                    LastName = "Michael",
                    Email = "joshMichael@gmail.com",
                    GeneralAdvisor = advisor,
                    FacultyAdvisor = advisor,
                    Hold = hold
                };
                //var form = new AdvisementSessionForm(student, advisor);
                var form = new AdvisementSessionsForm(advisor);
                form.Show();
            } else
            {
                MessageBox.Show(@"Wrong username or password.");
            }
        }

        private bool IsEntryValid(string entry)
        {
            if (string.IsNullOrEmpty(entry.Trim()))
            {
                MessageBox.Show(@"Please ensure all fields are filled out.", "Error");
                return false;
            }
            return true;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
