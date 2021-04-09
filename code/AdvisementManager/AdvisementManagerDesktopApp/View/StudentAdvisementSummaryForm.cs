using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AdvisementManagerDesktopApp.Controller;
using AdvisementManagerDesktopApp.Model;
using AdvisementManagerDesktopApp.Resources;
using Microsoft.Data.SqlClient;

namespace AdvisementManagerDesktopApp.View
{
    /// <summary>
    ///   The advisement session form for viewing and selecting students with holds
    /// </summary>
    public partial class StudentAdvisementSummaryForm : Form
    {
        private readonly AdvisementSessionController sessionController = new();

        private readonly Advisor advisor;

        private readonly Student student;

        /// <summary>Initializes a new instance of the <see cref="StudentAdvisementSummaryForm" /> class.</summary>
        public StudentAdvisementSummaryForm(Student student, Advisor advisor)
        {
            this.InitializeComponent();
            this.student = student;
            this.advisor = advisor;
            this.checkForMeeting();
            this.setUpScreen();
            this.notificationPanel.RemoveAllClicked += this.RemoveButtonClicked;
            this.notificationPanel.RemoveAllClicked += this.RemoveAllButtonClicked;
        }

        public void RemoveButtonClicked(object sender, EventArgs e)
        {

        }

        public void RemoveAllButtonClicked(object sender, EventArgs e)
        {

        }

        private void setUpNotifications()
        {
            NotificationController notificationController = new();
            var notifications = notificationController.GetNotifications(this.advisor.Id);
            this.notificationPanel.SetUpNotifications(notifications);
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
            this.checkStageAndAdvisor();
            this.updateMeetingTimeLabel();
            var sessions = this.sessionController.ObtainStudentSessions(this.student);

            this.setUpNotes(sessions);

            if (this.student.Hold.Reason.Equals(ConstantManager.WaitingForHoldRemoval) || this.student.Hold.Reason.Equals(ConstantManager.ReadyToRegister))
            {
                this.notesTxtBox.Visible = false;
            }

            this.studentNameLbl.Text = this.student.FirstName + @" " + this.student.LastName;
            this.stageLbl.Text = this.student.Hold.Reason;
            this.loggedInLabel.Text = "Logged in: " + this.advisor.FirstName + " " + this.advisor.LastName;
            this.setUpNotifications();
        }

        private void setUpNotes(IList<AdvisementSession> sessions)
        {
            const int hasASession = 1;
            if (sessions.Count >= hasASession)
            {
                foreach (var session in sessions)
                {
                    this.notesLbl.Text += @"Advisor: " + session.Advisor.FirstName + @" " + session.Advisor.LastName +
                                         Environment.NewLine;
                    this.notesLbl.Text += @"Date: " + session.Date + Environment.NewLine;
                    this.notesLbl.Text += @"Notes from session: " + session.Notes + Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                this.notesLbl.Text = @"None";
            }
        }

        private void updateMeetingTimeLabel()
        {
            if (this.student.Meeting == null || this.student.Meeting.Date == DateTime.MinValue)
            {
                this.meetingTimeLbl.Text = @"No meetings scheduled";
                this.approveBtn.Visible = false;
            }
            else
            {
                this.meetingTimeLbl.Text = this.student.Meeting.Date.ToString(CultureInfo.InvariantCulture);
            }
        }

        private void checkStageAndAdvisor()
        {
            var holdReason = this.student.Hold.Reason.Trim();
            var advisorType = this.advisor.IsFacultyAdvisor;

            if (advisorType && holdReason.Equals(ConstantManager.NeedToMeetFacAdvisor) 
                || !advisorType && holdReason.Equals(ConstantManager.NeedToMeetDptAdvisor))
            {
                this.approveBtn.Visible = true;
                this.cancelMeetingBtn.Visible = true;
            } 
            else if (!advisorType && holdReason.Equals(ConstantManager.WaitingForHoldRemoval))
            {
                this.removeHoldBtn.Visible = true;
            }
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            if(this.checkIfMeetingTimePassed())
            {
                try
                {
                    this.student.Meeting.Notes = this.notesTxtBox.Text;
                    this.sessionController.ApproveMeeting(this.student, this.advisor);
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private bool checkIfMeetingTimePassed()
        {
            var timePassed = true;
            if (this.student.Meeting.Date > DateTime.Now)
            {
                timePassed = false;
                this.waitForMeetingTimeLbl.Visible = true;
            }

            return timePassed;
        }

        private void removeHoldBtn_Click(object sender, EventArgs e)
        {
            try
            {
                this.sessionController.RemoveHold(this.student);
                this.Close();
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

        private void cancelMeetingBtn_Click(object sender, EventArgs e)
        {
            var meetingCancelResult = MessageBox.Show(@"Are you sure you want to cancel the meeting?", @"Cancel Meeting", MessageBoxButtons.YesNo);

            if (meetingCancelResult == DialogResult.Yes)
            {
                MessageBox.Show(@"Meeting Canceled!");
                Close();
            }
        }
    }
}
