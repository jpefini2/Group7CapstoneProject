using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdvisementManagerDesktopApp.Controller;
using AdvisementManagerDesktopApp.Model;

namespace AdvisementManagerDesktopApp.View
{
    /// <summary>
    ///   The advisement sessions form for approving meetings and removing holds..
    /// </summary>
    public partial class AdvisementSessionsForm : Form
    {
        private readonly Advisor advisor;

        private readonly AdvisementSessionsController sessionController = new();

        private IList<Student> students;
        private IList<AdvisementSession> upcomingMeetings;

        /// <summary>Initializes a new instance of the <see cref="AdvisementSessionsForm" /> class.</summary>
        public AdvisementSessionsForm(Advisor advisor)
        {
            this.InitializeComponent();
            this.advisor = advisor;

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

        private void setUpScreen()
        {
            this.studentsWithHoldsListBox.Items.Clear();
            this.students = this.sessionController.ObtainStudentsWithHolds(this.advisor);

            this.upcomingMeetingsListBox.Items.Clear();
            this.upcomingMeetings = this.sessionController.ObtainUpcomingMeetings(this.advisor);

            foreach (var student in this.students)
            {
                this.studentsWithHoldsListBox.Items.Add(student.FirstName + " " + student.LastName);
            }

            foreach (var meeting in this.upcomingMeetings)
            {
                this.upcomingMeetingsListBox.Items.Add(meeting.Student.FirstName + " " + meeting.Student.LastName + " - " + meeting.Date);
            }
            this.setUpNotifications();
        }

        private void viewStudentBtn_Click(object sender, EventArgs e)
        {
            var selectedStudentIndex = this.studentsWithHoldsListBox.SelectedIndex;
            if (selectedStudentIndex < 0)
            {
                return;
            }
            
            var selectedStudent = this.students[selectedStudentIndex];
            selectedStudent.GeneralAdvisor = this.advisor;
            var studentAdvisementSummaryForm = new StudentAdvisementSummaryForm(selectedStudent, this.advisor);

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

            advisementSessionForm.Show();
        }

        private void AdvisementSessionsForm_Activated(object sender, EventArgs e)
        {
            this.setUpScreen();
        }

        private void updatedAvailabilityBtn_Click(object sender, EventArgs e)
        {
            var availabilityFrom = new UpdateAvailabilityForm(this.advisor);
            availabilityFrom.Show();
        }

    }
}
