using AdvisementManagerDesktopApp.Controller;
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
            if (!IsEntryValid(usernameTextBox.Text)) return;
            if(!IsEntryValid(passwordTextBox.Text)) return;

            var username = usernameTextBox.Text.Trim();
            var password = passwordTextBox.Text.Trim();

            if (this.loginController.Authenticate(username, password))
            {
                MessageBox.Show(@"Login OK.");
                this.loginController.InitializeLogin(username);
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
