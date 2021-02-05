
namespace AdvisementManagerDesktopApp.View
{
    partial class AdvisementSessionForm
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
            this.SuspendLayout();
            // 
            // approveBtn
            // 
            this.approveBtn.Location = new System.Drawing.Point(229, 371);
            this.approveBtn.Name = "approveBtn";
            this.approveBtn.Size = new System.Drawing.Size(106, 54);
            this.approveBtn.TabIndex = 1;
            this.approveBtn.Text = "Approve";
            this.approveBtn.UseVisualStyleBackColor = true;
            this.approveBtn.Visible = false;
            this.approveBtn.Click += new System.EventHandler(this.approveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(372, 371);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(106, 54);
            this.cancelBtn.TabIndex = 2;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // studentNameLbl
            // 
            this.studentNameLbl.AutoSize = true;
            this.studentNameLbl.Location = new System.Drawing.Point(161, 113);
            this.studentNameLbl.Name = "studentNameLbl";
            this.studentNameLbl.Size = new System.Drawing.Size(83, 15);
            this.studentNameLbl.TabIndex = 3;
            this.studentNameLbl.Text = "Student Name";
            // 
            // meetingTimeLbl
            // 
            this.meetingTimeLbl.AutoSize = true;
            this.meetingTimeLbl.Location = new System.Drawing.Point(461, 113);
            this.meetingTimeLbl.Name = "meetingTimeLbl";
            this.meetingTimeLbl.Size = new System.Drawing.Size(57, 15);
            this.meetingTimeLbl.TabIndex = 4;
            this.meetingTimeLbl.Text = "DateTime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stage:";
            // 
            // stageLbl
            // 
            this.stageLbl.AutoSize = true;
            this.stageLbl.Location = new System.Drawing.Point(292, 194);
            this.stageLbl.Name = "stageLbl";
            this.stageLbl.Size = new System.Drawing.Size(123, 15);
            this.stageLbl.TabIndex = 6;
            this.stageLbl.Text = "stage placeholder text";
            // 
            // removeHoldBtn
            // 
            this.removeHoldBtn.Location = new System.Drawing.Point(230, 371);
            this.removeHoldBtn.Name = "removeHoldBtn";
            this.removeHoldBtn.Size = new System.Drawing.Size(105, 54);
            this.removeHoldBtn.TabIndex = 7;
            this.removeHoldBtn.Text = "Remove Hold";
            this.removeHoldBtn.UseVisualStyleBackColor = true;
            this.removeHoldBtn.Visible = false;
            this.removeHoldBtn.Click += new System.EventHandler(this.removeHoldBtn_Click);
            // 
            // loggedInLabel
            // 
            this.loggedInLabel.AutoSize = true;
            this.loggedInLabel.Location = new System.Drawing.Point(557, 9);
            this.loggedInLabel.Name = "loggedInLabel";
            this.loggedInLabel.Size = new System.Drawing.Size(66, 15);
            this.loggedInLabel.TabIndex = 8;
            this.loggedInLabel.Text = "Logged in: ";
            // 
            // waitForMeetingTimeLbl
            // 
            this.waitForMeetingTimeLbl.AutoSize = true;
            this.waitForMeetingTimeLbl.ForeColor = System.Drawing.Color.Red;
            this.waitForMeetingTimeLbl.Location = new System.Drawing.Point(230, 338);
            this.waitForMeetingTimeLbl.Name = "waitForMeetingTimeLbl";
            this.waitForMeetingTimeLbl.Size = new System.Drawing.Size(298, 15);
            this.waitForMeetingTimeLbl.TabIndex = 9;
            this.waitForMeetingTimeLbl.Text = "Please wait until the meeting time to approve a student";
            this.waitForMeetingTimeLbl.Visible = false;
            // 
            // AdvisementSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.waitForMeetingTimeLbl);
            this.Controls.Add(this.loggedInLabel);
            this.Controls.Add(this.removeHoldBtn);
            this.Controls.Add(this.stageLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.meetingTimeLbl);
            this.Controls.Add(this.studentNameLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.approveBtn);
            this.Name = "AdvisementSessionForm";
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
    }
}

