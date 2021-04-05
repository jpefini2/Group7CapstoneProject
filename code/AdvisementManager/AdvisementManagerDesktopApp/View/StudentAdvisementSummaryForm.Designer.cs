
namespace AdvisementManagerDesktopApp.View
{
    partial class StudentAdvisementSummaryForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.approveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.studentNameLbl = new System.Windows.Forms.Label();
            this.meetingTimeLbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stageLbl = new System.Windows.Forms.Label();
            this.removeHoldBtn = new System.Windows.Forms.Button();
            this.loggedInLabel = new System.Windows.Forms.Label();
            this.waitForMeetingTimeLbl = new System.Windows.Forms.Label();
            this.notesTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.notesLbl = new System.Windows.Forms.Label();
            this.cancelMeetingBtn = new System.Windows.Forms.Button();
            this.notificationPanel = new NotificationPanel.NotificationsPanel();
            this.SuspendLayout();
            // 
            // approveBtn
            // 
            this.approveBtn.Location = new System.Drawing.Point(196, 393);
            this.approveBtn.Name = "approveBtn";
            this.approveBtn.Size = new System.Drawing.Size(91, 47);
            this.approveBtn.TabIndex = 1;
            this.approveBtn.Text = "Approve";
            this.approveBtn.UseVisualStyleBackColor = true;
            this.approveBtn.Visible = false;
            this.approveBtn.Click += new System.EventHandler(this.approveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(319, 393);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(91, 47);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // studentNameLbl
            // 
            this.studentNameLbl.AutoSize = true;
            this.studentNameLbl.Location = new System.Drawing.Point(157, 62);
            this.studentNameLbl.Name = "studentNameLbl";
            this.studentNameLbl.Size = new System.Drawing.Size(75, 13);
            this.studentNameLbl.TabIndex = 3;
            this.studentNameLbl.Text = "Student Name";
            // 
            // meetingTimeLbl
            // 
            this.meetingTimeLbl.AutoSize = true;
            this.meetingTimeLbl.Location = new System.Drawing.Point(412, 62);
            this.meetingTimeLbl.Name = "meetingTimeLbl";
            this.meetingTimeLbl.Size = new System.Drawing.Size(53, 13);
            this.meetingTimeLbl.TabIndex = 4;
            this.meetingTimeLbl.Text = "DateTime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(243, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stage:";
            // 
            // stageLbl
            // 
            this.stageLbl.AutoSize = true;
            this.stageLbl.Location = new System.Drawing.Point(297, 102);
            this.stageLbl.Name = "stageLbl";
            this.stageLbl.Size = new System.Drawing.Size(111, 13);
            this.stageLbl.TabIndex = 6;
            this.stageLbl.Text = "stage placeholder text";
            // 
            // removeHoldBtn
            // 
            this.removeHoldBtn.Location = new System.Drawing.Point(197, 393);
            this.removeHoldBtn.Name = "removeHoldBtn";
            this.removeHoldBtn.Size = new System.Drawing.Size(90, 47);
            this.removeHoldBtn.TabIndex = 7;
            this.removeHoldBtn.Text = "Remove Hold";
            this.removeHoldBtn.UseVisualStyleBackColor = true;
            this.removeHoldBtn.Visible = false;
            this.removeHoldBtn.Click += new System.EventHandler(this.removeHoldBtn_Click);
            // 
            // loggedInLabel
            // 
            this.loggedInLabel.AutoSize = true;
            this.loggedInLabel.Location = new System.Drawing.Point(12, 9);
            this.loggedInLabel.Name = "loggedInLabel";
            this.loggedInLabel.Size = new System.Drawing.Size(60, 13);
            this.loggedInLabel.TabIndex = 8;
            this.loggedInLabel.Text = "Logged in: ";
            // 
            // waitForMeetingTimeLbl
            // 
            this.waitForMeetingTimeLbl.AutoSize = true;
            this.waitForMeetingTimeLbl.ForeColor = System.Drawing.Color.Red;
            this.waitForMeetingTimeLbl.Location = new System.Drawing.Point(197, 364);
            this.waitForMeetingTimeLbl.Name = "waitForMeetingTimeLbl";
            this.waitForMeetingTimeLbl.Size = new System.Drawing.Size(264, 13);
            this.waitForMeetingTimeLbl.TabIndex = 9;
            this.waitForMeetingTimeLbl.Text = "Please wait until the meeting time to approve a student";
            this.waitForMeetingTimeLbl.Visible = false;
            // 
            // notesTxtBox
            // 
            this.notesTxtBox.Location = new System.Drawing.Point(10, 283);
            this.notesTxtBox.Multiline = true;
            this.notesTxtBox.Name = "notesTxtBox";
            this.notesTxtBox.Size = new System.Drawing.Size(666, 79);
            this.notesTxtBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Notes:";
            // 
            // notesLbl
            // 
            this.notesLbl.AutoSize = true;
            this.notesLbl.Location = new System.Drawing.Point(37, 159);
            this.notesLbl.Name = "notesLbl";
            this.notesLbl.Size = new System.Drawing.Size(0, 13);
            this.notesLbl.TabIndex = 12;
            // 
            // cancelMeetingBtn
            // 
            this.cancelMeetingBtn.Location = new System.Drawing.Point(564, 393);
            this.cancelMeetingBtn.Name = "cancelMeetingBtn";
            this.cancelMeetingBtn.Size = new System.Drawing.Size(110, 47);
            this.cancelMeetingBtn.TabIndex = 16;
            this.cancelMeetingBtn.Text = "Cancel Meeting";
            this.cancelMeetingBtn.UseVisualStyleBackColor = true;
            this.cancelMeetingBtn.Visible = false;
            this.cancelMeetingBtn.Click += new System.EventHandler(this.cancelMeetingBtn_Click);
            // 
            // notificationPanel
            // 
            this.notificationPanel.Location = new System.Drawing.Point(384, 9);
            this.notificationPanel.Name = "notificationPanel";
            this.notificationPanel.Size = new System.Drawing.Size(292, 30);
            this.notificationPanel.TabIndex = 17;
            // 
            // StudentAdvisementSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 457);
            this.Controls.Add(this.notificationPanel);
            this.Controls.Add(this.cancelMeetingBtn);
            this.Controls.Add(this.notesLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.notesTxtBox);
            this.Controls.Add(this.waitForMeetingTimeLbl);
            this.Controls.Add(this.loggedInLabel);
            this.Controls.Add(this.removeHoldBtn);
            this.Controls.Add(this.stageLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.meetingTimeLbl);
            this.Controls.Add(this.studentNameLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.approveBtn);
            this.Name = "StudentAdvisementSummaryForm";
            this.Text = "Advisement Session";
            this.Load += new System.EventHandler(this.AdvisementSessionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button approveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label studentNameLbl;
        private System.Windows.Forms.Label meetingTimeLbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label stageLbl;
        private System.Windows.Forms.Button removeHoldBtn;
        private System.Windows.Forms.Label loggedInLabel;
        private System.Windows.Forms.Label waitForMeetingTimeLbl;
        private System.Windows.Forms.TextBox notesTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label notesLbl;
        private System.Windows.Forms.Button cancelMeetingBtn;
        private NotificationPanel.NotificationsPanel notificationPanel;
    }
}

