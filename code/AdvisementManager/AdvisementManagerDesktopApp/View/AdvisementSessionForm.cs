using AdvisementManagerDesktopApp.Controller;
using AdvisementManagerDesktopApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvisementManagerDesktopApp.View
{
    public partial class AdvisementSessionForm : Form
    {
        private AdvisementSessionController sessionController = new();

        private AdvisementSession session;
        private Student student;

        public AdvisementSessionForm(AdvisementSession session)
        {
            InitializeComponent();

            this.session = session;
            this.student = session.Student;

            this.populateFields();
        }

        private void populateFields()
        {
            this.studentNameLabel.Text = this.student.FirstName + " " + this.student.LastName;
            this.studentEmailLabel.Text = this.student.Email;
            this.meetingTimeLabel.Text = this.session.Date.ToString();
            this.holdReasonLabel.Text = this.session.Hold.Reason;
            this.notesTextBox.Text = this.session.Notes;

            var pastStudentMeetings = this.sessionController.ObtainStudentSessions(this.student);
            var pastMeetingsNotes = string.Empty;
            foreach (var meeting in pastStudentMeetings)
            {
                pastMeetingsNotes += meeting.Advisor.FirstName + " " + meeting.Advisor.LastName + Environment.NewLine;
                pastMeetingsNotes += meeting.Date + Environment.NewLine;
                pastMeetingsNotes += meeting.Notes + Environment.NewLine + Environment.NewLine;
            }

            this.pastNotesRichTextBox.Text = pastMeetingsNotes;
        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            if (this.checkIfMeetingTimePassed())
            {
                try
                {
                    this.session.Notes = this.notesTextBox.Text;
                    this.sessionController.ApproveMeeting(this.student, this.session.Advisor);
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
            if (this.session.Date > DateTime.Now)
            {
                timePassed = false;
                this.errorLabel.Visible = true;
            }

            return timePassed;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
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
