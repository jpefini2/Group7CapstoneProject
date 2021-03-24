
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
            this.availabilityTabControl = new System.Windows.Forms.TabControl();
            this.mondayTab = new System.Windows.Forms.TabPage();
            this.monListBox = new System.Windows.Forms.ListBox();
            this.tuesdayTab = new System.Windows.Forms.TabPage();
            this.tuesListBox = new System.Windows.Forms.ListBox();
            this.wednesdayTab = new System.Windows.Forms.TabPage();
            this.wedListBox = new System.Windows.Forms.ListBox();
            this.thursdayTab = new System.Windows.Forms.TabPage();
            this.thursListBox = new System.Windows.Forms.ListBox();
            this.fridayTab = new System.Windows.Forms.TabPage();
            this.friListBox = new System.Windows.Forms.ListBox();
            this.updateBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addTimeBtn = new System.Windows.Forms.Button();
            this.removeTimeBtn = new System.Windows.Forms.Button();
            this.availabilityTabControl.SuspendLayout();
            this.mondayTab.SuspendLayout();
            this.tuesdayTab.SuspendLayout();
            this.wednesdayTab.SuspendLayout();
            this.thursdayTab.SuspendLayout();
            this.fridayTab.SuspendLayout();
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
            // availabilityTabControl
            // 
            this.availabilityTabControl.Controls.Add(this.mondayTab);
            this.availabilityTabControl.Controls.Add(this.tuesdayTab);
            this.availabilityTabControl.Controls.Add(this.wednesdayTab);
            this.availabilityTabControl.Controls.Add(this.thursdayTab);
            this.availabilityTabControl.Controls.Add(this.fridayTab);
            this.availabilityTabControl.Location = new System.Drawing.Point(145, 167);
            this.availabilityTabControl.Name = "availabilityTabControl";
            this.availabilityTabControl.SelectedIndex = 0;
            this.availabilityTabControl.Size = new System.Drawing.Size(312, 256);
            this.availabilityTabControl.TabIndex = 6;
            // 
            // mondayTab
            // 
            this.mondayTab.Controls.Add(this.monListBox);
            this.mondayTab.Location = new System.Drawing.Point(4, 22);
            this.mondayTab.Name = "mondayTab";
            this.mondayTab.Padding = new System.Windows.Forms.Padding(3);
            this.mondayTab.Size = new System.Drawing.Size(304, 230);
            this.mondayTab.TabIndex = 0;
            this.mondayTab.Text = "Monday";
            this.mondayTab.UseVisualStyleBackColor = true;
            // 
            // monListBox
            // 
            this.monListBox.FormattingEnabled = true;
            this.monListBox.Location = new System.Drawing.Point(6, 6);
            this.monListBox.Name = "monListBox";
            this.monListBox.Size = new System.Drawing.Size(292, 212);
            this.monListBox.TabIndex = 0;
            // 
            // tuesdayTab
            // 
            this.tuesdayTab.Controls.Add(this.tuesListBox);
            this.tuesdayTab.Location = new System.Drawing.Point(4, 22);
            this.tuesdayTab.Name = "tuesdayTab";
            this.tuesdayTab.Padding = new System.Windows.Forms.Padding(3);
            this.tuesdayTab.Size = new System.Drawing.Size(304, 230);
            this.tuesdayTab.TabIndex = 1;
            this.tuesdayTab.Text = "Tuesday";
            this.tuesdayTab.UseVisualStyleBackColor = true;
            // 
            // tuesListBox
            // 
            this.tuesListBox.FormattingEnabled = true;
            this.tuesListBox.Location = new System.Drawing.Point(6, 6);
            this.tuesListBox.Name = "tuesListBox";
            this.tuesListBox.Size = new System.Drawing.Size(292, 212);
            this.tuesListBox.TabIndex = 1;
            // 
            // wednesdayTab
            // 
            this.wednesdayTab.Controls.Add(this.wedListBox);
            this.wednesdayTab.Location = new System.Drawing.Point(4, 22);
            this.wednesdayTab.Name = "wednesdayTab";
            this.wednesdayTab.Padding = new System.Windows.Forms.Padding(3);
            this.wednesdayTab.Size = new System.Drawing.Size(304, 230);
            this.wednesdayTab.TabIndex = 2;
            this.wednesdayTab.Text = "Wednesday";
            this.wednesdayTab.UseVisualStyleBackColor = true;
            // 
            // wedListBox
            // 
            this.wedListBox.FormattingEnabled = true;
            this.wedListBox.Location = new System.Drawing.Point(6, 6);
            this.wedListBox.Name = "wedListBox";
            this.wedListBox.Size = new System.Drawing.Size(292, 212);
            this.wedListBox.TabIndex = 1;
            // 
            // thursdayTab
            // 
            this.thursdayTab.Controls.Add(this.thursListBox);
            this.thursdayTab.Location = new System.Drawing.Point(4, 22);
            this.thursdayTab.Name = "thursdayTab";
            this.thursdayTab.Padding = new System.Windows.Forms.Padding(3);
            this.thursdayTab.Size = new System.Drawing.Size(304, 230);
            this.thursdayTab.TabIndex = 3;
            this.thursdayTab.Text = "Thursday";
            this.thursdayTab.UseVisualStyleBackColor = true;
            // 
            // thursListBox
            // 
            this.thursListBox.FormattingEnabled = true;
            this.thursListBox.Location = new System.Drawing.Point(6, 6);
            this.thursListBox.Name = "thursListBox";
            this.thursListBox.Size = new System.Drawing.Size(292, 212);
            this.thursListBox.TabIndex = 1;
            // 
            // fridayTab
            // 
            this.fridayTab.Controls.Add(this.friListBox);
            this.fridayTab.Location = new System.Drawing.Point(4, 22);
            this.fridayTab.Name = "fridayTab";
            this.fridayTab.Padding = new System.Windows.Forms.Padding(3);
            this.fridayTab.Size = new System.Drawing.Size(304, 230);
            this.fridayTab.TabIndex = 4;
            this.fridayTab.Text = "Friday";
            this.fridayTab.UseVisualStyleBackColor = true;
            // 
            // friListBox
            // 
            this.friListBox.FormattingEnabled = true;
            this.friListBox.Location = new System.Drawing.Point(6, 6);
            this.friListBox.Name = "friListBox";
            this.friListBox.Size = new System.Drawing.Size(292, 212);
            this.friListBox.TabIndex = 1;
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(173, 518);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(108, 23);
            this.updateBtn.TabIndex = 7;
            this.updateBtn.Text = "Update Availability";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(349, 518);
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
            this.removeTimeBtn.Location = new System.Drawing.Point(463, 277);
            this.removeTimeBtn.Name = "removeTimeBtn";
            this.removeTimeBtn.Size = new System.Drawing.Size(95, 23);
            this.removeTimeBtn.TabIndex = 10;
            this.removeTimeBtn.Text = "Remove Time";
            this.removeTimeBtn.UseVisualStyleBackColor = true;
            this.removeTimeBtn.Click += new System.EventHandler(this.removeTimeBtn_Click);
            // 
            // UpdateAvailabilityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 593);
            this.Controls.Add(this.removeTimeBtn);
            this.Controls.Add(this.addTimeBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.availabilityTabControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endTimeComboBox);
            this.Controls.Add(this.startTimeComboBox);
            this.Controls.Add(this.dayComboBox);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(705, 632);
            this.Name = "UpdateAvailabilityForm";
            this.Text = "UpdateAvailabilityForm";
            this.availabilityTabControl.ResumeLayout(false);
            this.mondayTab.ResumeLayout(false);
            this.tuesdayTab.ResumeLayout(false);
            this.wednesdayTab.ResumeLayout(false);
            this.thursdayTab.ResumeLayout(false);
            this.fridayTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dayComboBox;
        private System.Windows.Forms.ComboBox startTimeComboBox;
        private System.Windows.Forms.ComboBox endTimeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl availabilityTabControl;
        private System.Windows.Forms.TabPage mondayTab;
        private System.Windows.Forms.TabPage tuesdayTab;
        private System.Windows.Forms.TabPage wednesdayTab;
        private System.Windows.Forms.TabPage thursdayTab;
        private System.Windows.Forms.TabPage fridayTab;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ListBox monListBox;
        private System.Windows.Forms.ListBox tuesListBox;
        private System.Windows.Forms.ListBox wedListBox;
        private System.Windows.Forms.ListBox thursListBox;
        private System.Windows.Forms.ListBox friListBox;
        private System.Windows.Forms.Button addTimeBtn;
        private System.Windows.Forms.Button removeTimeBtn;
    }
}