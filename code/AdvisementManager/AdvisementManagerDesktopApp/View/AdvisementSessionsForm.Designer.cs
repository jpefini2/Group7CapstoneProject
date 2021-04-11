
namespace AdvisementManagerDesktopApp.View
{
    partial class AdvisementSessionsForm
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
            this.viewBtn = new System.Windows.Forms.Button();
            this.studentsWithHoldsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.upcomingMeetingsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.viewMeetingButton = new System.Windows.Forms.Button();
            this.updatedAvaliabilityBtn = new System.Windows.Forms.Button();
            this.notificationPanel = new NotificationPanel.NotificationsPanel();
            this.SuspendLayout();
            // 
            // viewBtn
            // 
            this.viewBtn.Location = new System.Drawing.Point(317, 277);
            this.viewBtn.Margin = new System.Windows.Forms.Padding(2);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(138, 34);
            this.viewBtn.TabIndex = 1;
            this.viewBtn.Text = "View";
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewStudentBtn_Click);
            // 
            // studentsWithHoldsListBox
            // 
            this.studentsWithHoldsListBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.studentsWithHoldsListBox.FormattingEnabled = true;
            this.studentsWithHoldsListBox.ItemHeight = 21;
            this.studentsWithHoldsListBox.Location = new System.Drawing.Point(267, 87);
            this.studentsWithHoldsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.studentsWithHoldsListBox.Name = "studentsWithHoldsListBox";
            this.studentsWithHoldsListBox.ScrollAlwaysVisible = true;
            this.studentsWithHoldsListBox.Size = new System.Drawing.Size(250, 172);
            this.studentsWithHoldsListBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(273, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Students With Holds";
            // 
            // upcomingMeetingsListBox
            // 
            this.upcomingMeetingsListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upcomingMeetingsListBox.FormattingEnabled = true;
            this.upcomingMeetingsListBox.HorizontalScrollbar = true;
            this.upcomingMeetingsListBox.ItemHeight = 21;
            this.upcomingMeetingsListBox.Location = new System.Drawing.Point(9, 87);
            this.upcomingMeetingsListBox.Margin = new System.Windows.Forms.Padding(2);
            this.upcomingMeetingsListBox.Name = "upcomingMeetingsListBox";
            this.upcomingMeetingsListBox.Size = new System.Drawing.Size(250, 172);
            this.upcomingMeetingsListBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(9, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Upcoming Meetings";
            // 
            // viewMeetingButton
            // 
            this.viewMeetingButton.Location = new System.Drawing.Point(61, 277);
            this.viewMeetingButton.Margin = new System.Windows.Forms.Padding(2);
            this.viewMeetingButton.Name = "viewMeetingButton";
            this.viewMeetingButton.Size = new System.Drawing.Size(138, 34);
            this.viewMeetingButton.TabIndex = 8;
            this.viewMeetingButton.Text = "View";
            this.viewMeetingButton.UseVisualStyleBackColor = true;
            this.viewMeetingButton.Click += new System.EventHandler(this.viewMeetingButton_Click);
            // 
            // updatedAvaliabilityBtn
            // 
            this.updatedAvaliabilityBtn.Location = new System.Drawing.Point(9, 13);
            this.updatedAvaliabilityBtn.Name = "updatedAvaliabilityBtn";
            this.updatedAvaliabilityBtn.Size = new System.Drawing.Size(121, 30);
            this.updatedAvaliabilityBtn.TabIndex = 9;
            this.updatedAvaliabilityBtn.Text = "Update Avaliability";
            this.updatedAvaliabilityBtn.UseVisualStyleBackColor = true;
            this.updatedAvaliabilityBtn.Click += new System.EventHandler(this.updatedAvailabilityBtn_Click);
            // 
            // notificationPanel
            // 
            this.notificationPanel.Location = new System.Drawing.Point(225, 13);
            this.notificationPanel.Name = "notificationPanel";
            this.notificationPanel.Size = new System.Drawing.Size(292, 30);
            this.notificationPanel.TabIndex = 10;
            // 
            // AdvisementSessionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 337);
            this.Controls.Add(this.notificationPanel);
            this.Controls.Add(this.updatedAvaliabilityBtn);
            this.Controls.Add(this.viewMeetingButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.upcomingMeetingsListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studentsWithHoldsListBox);
            this.Controls.Add(this.viewBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AdvisementSessionsForm";
            this.Text = "Advisment Sessions";
            this.Activated += new System.EventHandler(this.AdvisementSessionsForm_Activated);
            this.Enter += new System.EventHandler(this.AdvisementSessionsForm_Enter);
            this.Leave += new System.EventHandler(this.AdvisementSessionsForm_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button viewBtn;
        private System.Windows.Forms.ListBox studentsWithHoldsListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox upcomingMeetingsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button viewMeetingButton;
        private System.Windows.Forms.Button updatedAvaliabilityBtn;
        private NotificationPanel.NotificationsPanel notificationPanel;
    }
}