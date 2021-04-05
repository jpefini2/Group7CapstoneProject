
namespace AdvisementManagerDesktopApp.View
{
    partial class AdvisementSessionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.studentNameLabel = new System.Windows.Forms.Label();
            this.studentEmailLabel = new System.Windows.Forms.Label();
            this.meetingTimeLabel = new System.Windows.Forms.Label();
            this.holdReasonLabel = new System.Windows.Forms.Label();
            this.pastNotesRichTextBox = new System.Windows.Forms.RichTextBox();
            this.notesTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.approveButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            this.cancelMeetingBtn = new System.Windows.Forms.Button();
            this.notificationPanel = new NotificationPanel.NotificationsPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(262, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Meeting Time :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(262, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hold :";
            // 
            // studentNameLabel
            // 
            this.studentNameLabel.AutoSize = true;
            this.studentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentNameLabel.Location = new System.Drawing.Point(76, 46);
            this.studentNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.studentNameLabel.Name = "studentNameLabel";
            this.studentNameLabel.Size = new System.Drawing.Size(133, 17);
            this.studentNameLabel.TabIndex = 4;
            this.studentNameLabel.Text = "The student\'s name";
            // 
            // studentEmailLabel
            // 
            this.studentEmailLabel.AutoSize = true;
            this.studentEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentEmailLabel.Location = new System.Drawing.Point(76, 82);
            this.studentEmailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.studentEmailLabel.Name = "studentEmailLabel";
            this.studentEmailLabel.Size = new System.Drawing.Size(131, 17);
            this.studentEmailLabel.TabIndex = 5;
            this.studentEmailLabel.Text = "The student\'s email";
            // 
            // meetingTimeLabel
            // 
            this.meetingTimeLabel.AutoSize = true;
            this.meetingTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingTimeLabel.Location = new System.Drawing.Point(356, 46);
            this.meetingTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.meetingTimeLabel.Name = "meetingTimeLabel";
            this.meetingTimeLabel.Size = new System.Drawing.Size(117, 17);
            this.meetingTimeLabel.TabIndex = 6;
            this.meetingTimeLabel.Text = "The meeting time";
            // 
            // holdReasonLabel
            // 
            this.holdReasonLabel.AutoSize = true;
            this.holdReasonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.holdReasonLabel.Location = new System.Drawing.Point(307, 82);
            this.holdReasonLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.holdReasonLabel.Name = "holdReasonLabel";
            this.holdReasonLabel.Size = new System.Drawing.Size(173, 17);
            this.holdReasonLabel.TabIndex = 7;
            this.holdReasonLabel.Text = "The student\'s hold reason";
            // 
            // pastNotesRichTextBox
            // 
            this.pastNotesRichTextBox.Location = new System.Drawing.Point(28, 134);
            this.pastNotesRichTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.pastNotesRichTextBox.Name = "pastNotesRichTextBox";
            this.pastNotesRichTextBox.ReadOnly = true;
            this.pastNotesRichTextBox.Size = new System.Drawing.Size(543, 111);
            this.pastNotesRichTextBox.TabIndex = 8;
            this.pastNotesRichTextBox.Text = "";
            // 
            // notesTextBox
            // 
            this.notesTextBox.Location = new System.Drawing.Point(28, 282);
            this.notesTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(543, 111);
            this.notesTextBox.TabIndex = 9;
            this.notesTextBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Past Notes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 266);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Notes";
            // 
            // approveButton
            // 
            this.approveButton.Location = new System.Drawing.Point(218, 397);
            this.approveButton.Margin = new System.Windows.Forms.Padding(2);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(84, 32);
            this.approveButton.TabIndex = 12;
            this.approveButton.Text = "Approve";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.approveButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(310, 397);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 32);
            this.button1.TabIndex = 13;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(184, 440);
            this.errorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(217, 13);
            this.errorLabel.TabIndex = 14;
            this.errorLabel.Text = "Please wait until the meeting time to approve";
            this.errorLabel.Visible = false;
            // 
            // cancelMeetingBtn
            // 
            this.cancelMeetingBtn.Location = new System.Drawing.Point(488, 397);
            this.cancelMeetingBtn.Name = "cancelMeetingBtn";
            this.cancelMeetingBtn.Size = new System.Drawing.Size(100, 32);
            this.cancelMeetingBtn.TabIndex = 15;
            this.cancelMeetingBtn.Text = "Cancel Meeting";
            this.cancelMeetingBtn.UseVisualStyleBackColor = true;
            this.cancelMeetingBtn.Click += new System.EventHandler(this.cancelMeetingBtn_Click);
            // 
            // notificationPanel
            // 
            this.notificationPanel.Location = new System.Drawing.Point(296, 12);
            this.notificationPanel.Name = "notificationPanel";
            this.notificationPanel.Size = new System.Drawing.Size(292, 30);
            this.notificationPanel.TabIndex = 16;
            // 
            // AdvisementSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 461);
            this.Controls.Add(this.notificationPanel);
            this.Controls.Add(this.cancelMeetingBtn);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.approveButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.pastNotesRichTextBox);
            this.Controls.Add(this.holdReasonLabel);
            this.Controls.Add(this.meetingTimeLabel);
            this.Controls.Add(this.studentEmailLabel);
            this.Controls.Add(this.studentNameLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdvisementSessionForm";
            this.Text = "AdvisementSessionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label studentNameLabel;
        private System.Windows.Forms.Label studentEmailLabel;
        private System.Windows.Forms.Label meetingTimeLabel;
        private System.Windows.Forms.Label holdReasonLabel;
        private System.Windows.Forms.RichTextBox pastNotesRichTextBox;
        private System.Windows.Forms.RichTextBox notesTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button cancelMeetingBtn;
        private NotificationPanel.NotificationsPanel notificationPanel;
    }
}