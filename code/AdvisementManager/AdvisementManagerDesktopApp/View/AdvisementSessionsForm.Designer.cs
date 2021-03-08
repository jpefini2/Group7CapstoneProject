
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
            this.SuspendLayout();
            // 
            // viewBtn
            // 
            this.viewBtn.Location = new System.Drawing.Point(423, 341);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(184, 42);
            this.viewBtn.TabIndex = 1;
            this.viewBtn.Text = "View";
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewStudentBtn_Click);
            // 
            // studentsWithHoldsListBox
            // 
            this.studentsWithHoldsListBox.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.studentsWithHoldsListBox.FormattingEnabled = true;
            this.studentsWithHoldsListBox.ItemHeight = 28;
            this.studentsWithHoldsListBox.Location = new System.Drawing.Point(356, 107);
            this.studentsWithHoldsListBox.Name = "studentsWithHoldsListBox";
            this.studentsWithHoldsListBox.ScrollAlwaysVisible = true;
            this.studentsWithHoldsListBox.Size = new System.Drawing.Size(332, 228);
            this.studentsWithHoldsListBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(364, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 28);
            this.label2.TabIndex = 5;
            this.label2.Text = "Students With Holds";
            // 
            // upcomingMeetingsListBox
            // 
            this.upcomingMeetingsListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upcomingMeetingsListBox.FormattingEnabled = true;
            this.upcomingMeetingsListBox.HorizontalScrollbar = true;
            this.upcomingMeetingsListBox.ItemHeight = 28;
            this.upcomingMeetingsListBox.Location = new System.Drawing.Point(12, 107);
            this.upcomingMeetingsListBox.Name = "upcomingMeetingsListBox";
            this.upcomingMeetingsListBox.Size = new System.Drawing.Size(332, 228);
            this.upcomingMeetingsListBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Upcoming Meetings";
            // 
            // viewMeetingButton
            // 
            this.viewMeetingButton.Location = new System.Drawing.Point(81, 341);
            this.viewMeetingButton.Name = "viewMeetingButton";
            this.viewMeetingButton.Size = new System.Drawing.Size(184, 42);
            this.viewMeetingButton.TabIndex = 8;
            this.viewMeetingButton.Text = "View";
            this.viewMeetingButton.UseVisualStyleBackColor = true;
            this.viewMeetingButton.Click += new System.EventHandler(this.viewMeetingButton_Click);
            // 
            // AdvisementSessionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 468);
            this.Controls.Add(this.viewMeetingButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.upcomingMeetingsListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.studentsWithHoldsListBox);
            this.Controls.Add(this.viewBtn);
            this.Name = "AdvisementSessionsForm";
            this.Text = "Advisment Sessions";
            this.Activated += new System.EventHandler(this.AdvisementSessionsForm_Activated);
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
    }
}