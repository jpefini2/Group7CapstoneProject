
namespace AdvisementManagerDesktopApp.View
{
    partial class UpdateAvailabilityForm
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
            this.dayComboBox = new System.Windows.Forms.ComboBox();
            this.startTimeComboBox = new System.Windows.Forms.ComboBox();
            this.endTimeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.monListBox = new System.Windows.Forms.ListBox();
            this.tuesListBox = new System.Windows.Forms.ListBox();
            this.wedListBox = new System.Windows.Forms.ListBox();
            this.thursListBox = new System.Windows.Forms.ListBox();
            this.friListBox = new System.Windows.Forms.ListBox();
            this.updateBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addTimeBtn = new System.Windows.Forms.Button();
            this.removeTimeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(200, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Update Availability";
            // 
            // dayComboBox
            // 
            this.dayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dayComboBox.FormattingEnabled = true;
            this.dayComboBox.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday"});
            this.dayComboBox.Location = new System.Drawing.Point(68, 104);
            this.dayComboBox.Name = "dayComboBox";
            this.dayComboBox.Size = new System.Drawing.Size(121, 21);
            this.dayComboBox.TabIndex = 1;
            // 
            // startTimeComboBox
            // 
            this.startTimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.startTimeComboBox.FormattingEnabled = true;
            this.startTimeComboBox.Location = new System.Drawing.Point(236, 104);
            this.startTimeComboBox.Name = "startTimeComboBox";
            this.startTimeComboBox.Size = new System.Drawing.Size(121, 21);
            this.startTimeComboBox.TabIndex = 2;
            // 
            // endTimeComboBox
            // 
            this.endTimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.endTimeComboBox.FormattingEnabled = true;
            this.endTimeComboBox.Location = new System.Drawing.Point(412, 104);
            this.endTimeComboBox.Name = "endTimeComboBox";
            this.endTimeComboBox.Size = new System.Drawing.Size(121, 21);
            this.endTimeComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // monListBox
            // 
            this.monListBox.FormattingEnabled = true;
            this.monListBox.Location = new System.Drawing.Point(65, 194);
            this.monListBox.Name = "monListBox";
            this.monListBox.Size = new System.Drawing.Size(175, 147);
            this.monListBox.TabIndex = 0;
            this.monListBox.Enter += new System.EventHandler(this.newItemSelected);
            // 
            // tuesListBox
            // 
            this.tuesListBox.FormattingEnabled = true;
            this.tuesListBox.Location = new System.Drawing.Point(338, 194);
            this.tuesListBox.Name = "tuesListBox";
            this.tuesListBox.Size = new System.Drawing.Size(172, 147);
            this.tuesListBox.TabIndex = 1;
            this.tuesListBox.Enter += new System.EventHandler(this.newItemSelected);
            // 
            // wedListBox
            // 
            this.wedListBox.FormattingEnabled = true;
            this.wedListBox.Location = new System.Drawing.Point(626, 194);
            this.wedListBox.Name = "wedListBox";
            this.wedListBox.Size = new System.Drawing.Size(172, 147);
            this.wedListBox.TabIndex = 1;
            this.wedListBox.Enter += new System.EventHandler(this.newItemSelected);
            // 
            // thursListBox
            // 
            this.thursListBox.FormattingEnabled = true;
            this.thursListBox.Location = new System.Drawing.Point(68, 475);
            this.thursListBox.Name = "thursListBox";
            this.thursListBox.Size = new System.Drawing.Size(175, 147);
            this.thursListBox.TabIndex = 1;
            this.thursListBox.Enter += new System.EventHandler(this.newItemSelected);
            // 
            // friListBox
            // 
            this.friListBox.FormattingEnabled = true;
            this.friListBox.Location = new System.Drawing.Point(338, 475);
            this.friListBox.Name = "friListBox";
            this.friListBox.Size = new System.Drawing.Size(165, 147);
            this.friListBox.TabIndex = 1;
            this.friListBox.Enter += new System.EventHandler(this.newItemSelected);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(349, 676);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(108, 23);
            this.updateBtn.TabIndex = 7;
            this.updateBtn.Text = "Update Availability";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(475, 676);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(108, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addTimeBtn
            // 
            this.addTimeBtn.Location = new System.Drawing.Point(572, 104);
            this.addTimeBtn.Name = "addTimeBtn";
            this.addTimeBtn.Size = new System.Drawing.Size(75, 23);
            this.addTimeBtn.TabIndex = 9;
            this.addTimeBtn.Text = "Add Time";
            this.addTimeBtn.UseVisualStyleBackColor = true;
            this.addTimeBtn.Click += new System.EventHandler(this.addTimeBtn_Click);
            // 
            // removeTimeBtn
            // 
            this.removeTimeBtn.Location = new System.Drawing.Point(626, 531);
            this.removeTimeBtn.Name = "removeTimeBtn";
            this.removeTimeBtn.Size = new System.Drawing.Size(95, 23);
            this.removeTimeBtn.TabIndex = 10;
            this.removeTimeBtn.Text = "Remove Time";
            this.removeTimeBtn.UseVisualStyleBackColor = true;
            this.removeTimeBtn.Click += new System.EventHandler(this.removeTimeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Monday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(335, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tuesday";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(623, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Wednesday";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Thusday";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 433);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Friday";
            // 
            // UpdateAvailabilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 718);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.friListBox);
            this.Controls.Add(this.thursListBox);
            this.Controls.Add(this.wedListBox);
            this.Controls.Add(this.tuesListBox);
            this.Controls.Add(this.monListBox);
            this.Controls.Add(this.removeTimeBtn);
            this.Controls.Add(this.addTimeBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endTimeComboBox);
            this.Controls.Add(this.startTimeComboBox);
            this.Controls.Add(this.dayComboBox);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(705, 632);
            this.Name = "UpdateAvailabilityForm";
            this.Text = "UpdateAvailabilityForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dayComboBox;
        private System.Windows.Forms.ComboBox startTimeComboBox;
        private System.Windows.Forms.ComboBox endTimeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ListBox monListBox;
        private System.Windows.Forms.ListBox tuesListBox;
        private System.Windows.Forms.ListBox wedListBox;
        private System.Windows.Forms.ListBox thursListBox;
        private System.Windows.Forms.ListBox friListBox;
        private System.Windows.Forms.Button addTimeBtn;
        private System.Windows.Forms.Button removeTimeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}