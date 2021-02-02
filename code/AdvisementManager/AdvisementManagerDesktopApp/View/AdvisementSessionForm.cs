using System;
using System.Globalization;
using System.Windows.Forms;
using AdvisementManagerDesktopApp.Controller;
using AdvisementManagerDesktopApp.Model;
using Microsoft.Data.SqlClient;

namespace AdvisementManagerDesktopApp.View
{
    /// <summary>
    ///   The advisement session form
    /// </summary>
    public partial class AdvisementSessionForm : Form
    {
        private readonly AdvisementSessionController sessionController = new();

        private readonly Advisor advisor;

        private readonly Student student;

        /// <summary>Initializes a new instance of the <see cref="AdvisementSessionForm" /> class.</summary>
        public AdvisementSessionForm(Student student, Advisor advisor)
        {
            this.InitializeComponent();
            this.student = student;
            this.advisor = advisor;
            this.checkForMeeting();
            this.setUpScreen();

            this.checkHolds();
        }


        private void checkForMeeting()
        {
            try
            {
                this.student.Meeting = this.sessionController.CheckForMeeting(this.student);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setUpScreen()
        {
            if (this.student.Meeting == null || this.student.Meeting.Date == DateTime.MinValue)
            {
                this.meetingTimeLbl.Text = @"No meetings scheduled";
            }
            else
            {
                this.meetingTimeLbl.Text = this.student.Meeting.Date.ToString(CultureInfo.InvariantCulture);
            }
            this.studentNameLbl.Text = this.student.FirstName + @" " + this.student.LastName;
            this.stageLbl.Text = this.student.Hold.Reason;
            this.loggedInLabel.Text = "Logged in: " + this.advisor.FirstName + " " + this.advisor.LastName;
            
        }

        private void checkHolds()
        {
            if (this.advisor.IsFacultyAdvisor)
            {
                this.toggleHoldButton(false);
            }
            else
            {
                this.toggleHoldButton(true);
            }

            if (!this.student.Hold.Reason.Equals("Student has met with faculty advisor hold pending removal."))
            {
                this.toggleHoldButton(false);
            }
        }

        private void toggleHoldButton(bool shouldShow)
        {
            this.removeHoldBtn.Visible = shouldShow;
            this.removeHoldBtn.Enabled = shouldShow;
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {

            try
            {
                this.sessionController.ApproveMeeting(this.student, this.advisor);
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void removeHoldBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.student.Hold.IsActive = false;
                this.student.Hold.Reason = "No holds";
                this.sessionController.RemoveHold(this.student);
                this.setUpScreen();
                MessageBox.Show(@"Hold Removed");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AdvisementSessionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
