using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using AdvisementManagerDesktopApp.Controller;
using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerDesktopApp.Model;
using AdvisementManagerDesktopApp.Resources;
using NotificationPanel;
using NotificationPanel.Model;

namespace AdvisementManagerDesktopApp.View
{
    /// <summary>
    ///   The advisement sessions form for approving meetings and removing holds..
    /// </summary>
    public partial class AdvisementSessionsForm : Form
    {
        public LoginForm ParentForm { get; set; }
        private bool wasClosedExitedProperly = false;

        private readonly Advisor advisor;

        private readonly AdvisementSessionsController sessionController = new();

        private readonly NotificationController notificationController = new();

        private IList<Student> students;
        private IList<AdvisementSession> upcomingMeetings;

        /// <summary>Initializes a new instance of the <see cref="AdvisementSessionsForm" /> class.</summary>
        public AdvisementSessionsForm(Advisor advisor)
        {
            this.InitializeComponent();
            this.advisor = advisor;

            this.setUpScreen();

            this.notificationPanel.RemovedButtonClicked += this.RemoveButtonClicked;
            this.notificationPanel.RemoveAllClicked += this.RemoveAllButtonClicked;
        }

        public void RemoveButtonClicked(object sender, RemovedNotificationEventArgs e)
        {
            notificationController.RemoveNotification(e.Id);
        }

        public void RemoveAllButtonClicked(object sender, EventArgs e)
        {
            notificationController.RemoveAllNotifications(this.advisor.Id);
        }

        private void setUpNotifications()
        {
            NotificationController notificationController = new();
            var notifications = notificationController.GetNotifications(this.advisor.Id);

            var panelNotifications = NotificationController.GetPanelNotifications(notifications);
            
            this.notificationPanel.SetUpNotifications(panelNotifications);
        }

        public void setUpScreen()
        {
            this.studentsListBox.Items.Clear();
            this.students = this.sessionController.ObtainStudents(this.advisor);

            this.upcomingMeetingsListBox.Items.Clear();
            this.upcomingMeetings = this.sessionController.ObtainUpcomingMeetings(this.advisor);

            foreach (var student in this.students)
            {
                string advisementStatus = "Complete";

                if (student.Hold.Reason != ConstantManager.ReadyToRegister)
                    advisementStatus = "Incomplete";

                this.studentsListBox.Items.Add(student.FirstName + " " + student.LastName + " : " + advisementStatus);
            }

            foreach (var meeting in this.upcomingMeetings)
            {
                this.upcomingMeetingsListBox.Items.Add(meeting.Student.FirstName + " " + meeting.Student.LastName + " - " + meeting.Date);
            }
            
            this.setUpNotifications();
        }

        private void viewStudentBtn_Click(object sender, EventArgs e)
        {
            var selectedStudentIndex = this.studentsListBox.SelectedIndex;
            if (selectedStudentIndex < 0)
            {
                return;
            }
            
            var selectedStudent = this.students[selectedStudentIndex];
            selectedStudent.GeneralAdvisor = this.advisor;
            var studentAdvisementSummaryForm = new StudentAdvisementSummaryForm(selectedStudent, this.advisor);
            studentAdvisementSummaryForm.ParentForm = this;

            this.Hide();
            studentAdvisementSummaryForm.Show();
        }

        private void viewMeetingButton_Click(object sender, EventArgs e)
        {
            var selectedMeetingIndex = this.upcomingMeetingsListBox.SelectedIndex;
            if (selectedMeetingIndex < 0)
            {
                return;
            }

            var selectedMeeting = this.upcomingMeetings[selectedMeetingIndex];
            var advisementSessionForm = new AdvisementSessionForm(selectedMeeting, this.advisor);
            advisementSessionForm.ParentForm = this;

            this.Hide();
            advisementSessionForm.Show();
        }

        private void AdvisementSessionsForm_Activated(object sender, EventArgs e)
        {
            this.setUpScreen();
        }

        private void updatedAvailabilityBtn_Click(object sender, EventArgs e)
        {
            var availabilityFrom = new UpdateAvailabilityForm(this.advisor);
            availabilityFrom.ParentForm = this;

            this.Hide();
            availabilityFrom.Show();
        }

        private void AdvisementSessionsForm_Leave(object sender, EventArgs e)
        {
            this.setUpScreen();
        }
        
        private void AdvisementSessionsForm_Enter(object sender, EventArgs e)
        {
            this.setUpScreen();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.wasClosedExitedProperly = true;

            this.ParentForm.Show();
            this.Close();
        }

        private void AdvisementSessionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!wasClosedExitedProperly)
                this.ParentForm.Close();
        }
    }
}
