
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(349, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Meeting Time :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(349, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Hold :";
            // 
            // studentNameLabel
            // 
            this.studentNameLabel.AutoSize = true;
            this.studentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentNameLabel.Location = new System.Drawing.Point(102, 57);
            this.studentNameLabel.Name = "studentNameLabel";
            this.studentNameLabel.Size = new System.Drawing.Size(156, 20);
            this.studentNameLabel.TabIndex = 4;
            this.studentNameLabel.Text = "The student\'s name";
            // 
            // studentEmailLabel
            // 
            this.studentEmailLabel.AutoSize = true;
            this.studentEmailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentEmailLabel.Location = new System.Drawing.Point(102, 101);
            this.studentEmailLabel.Name = "studentEmailLabel";
            this.studentEmailLabel.Size = new System.Drawing.Size(155, 20);
            this.studentEmailLabel.TabIndex = 5;
            this.studentEmailLabel.Text = "The student\'s email";
            // 
            // meetingTimeLabel
            // 
            this.meetingTimeLabel.AutoSize = true;
            this.meetingTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingTimeLabel.Location = new System.Drawing.Point(475, 57);
            this.meetingTimeLabel.Name = "meetingTimeLabel";
            this.meetingTimeLabel.Size = new System.Drawing.Size(138, 20);
            this.meetingTimeLabel.TabIndex = 6;
            this.meetingTimeLabel.Text = "The meeting time";
            // 
            // holdReasonLabel
            // 
            this.holdReasonLabel.AutoSize = true;
            this.holdReasonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.holdReasonLabel.Location = new System.Drawing.Point(409, 101);
            this.holdReasonLabel.Name = "holdReasonLabel";
            this.holdReasonLabel.Size = new System.Drawing.Size(202, 20);
            this.holdReasonLabel.TabIndex = 7;
            this.holdReasonLabel.Text = "The student\'s hold reason";
            // 
            // pastNotesRichTextBox
            // 
            this.pastNotesRichTextBox.Location = new System.Drawing.Point(37, 165);
            this.pastNotesRichTextBox.Name = "pastNotesRichTextBox";
            this.pastNotesRichTextBox.ReadOnly = true;
            this.pastNotesRichTextBox.Size = new System.Drawing.Size(723, 136);
            this.pastNotesRichTextBox.TabIndex = 8;
            this.pastNotesRichTextBox.Text = "";
            // 
            // notesTextBox
            // 
            this.notesTextBox.Location = new System.Drawing.Point(37, 347);
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(723, 136);
            this.notesTextBox.TabIndex = 9;
            this.notesTextBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Past Notes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 327);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Notes";
            // 
            // approveButton
            // 
            this.approveButton.Location = new System.Drawing.Point(291, 489);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(112, 39);
            this.approveButton.TabIndex = 12;
            this.approveButton.Text = "Approve";
            this.approveButton.UseVisualStyleBackColor = true;
            this.approveButton.Click += new System.EventHandler(this.approveButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(413, 489);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 13;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(245, 541);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(289, 17);
            this.errorLabel.TabIndex = 14;
            this.errorLabel.Text = "Please wait until the meeting time to approve";
            this.errorLabel.Visible = false;
            // 
            // AdvisementSessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 567);
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
    }
}