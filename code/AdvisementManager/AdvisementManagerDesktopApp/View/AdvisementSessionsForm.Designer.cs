
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
            this.SuspendLayout();
            // 
            // viewBtn
            // 
            this.viewBtn.Location = new System.Drawing.Point(220, 341);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(161, 39);
            this.viewBtn.TabIndex = 1;
            this.viewBtn.Text = "View";
            this.viewBtn.UseVisualStyleBackColor = true;
            this.viewBtn.Click += new System.EventHandler(this.viewBtn_Click);
            // 
            // studentsWithHoldsListBox
            // 
            this.studentsWithHoldsListBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.studentsWithHoldsListBox.FormattingEnabled = true;
            this.studentsWithHoldsListBox.ItemHeight = 21;
            this.studentsWithHoldsListBox.Location = new System.Drawing.Point(12, 100);
            this.studentsWithHoldsListBox.Name = "studentsWithHoldsListBox";
            this.studentsWithHoldsListBox.ScrollAlwaysVisible = true;
            this.studentsWithHoldsListBox.Size = new System.Drawing.Size(590, 214);
            this.studentsWithHoldsListBox.Sorted = true;
            this.studentsWithHoldsListBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(220, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Students With Holds";
            // 
            // AdvisementSessionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 439);
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
    }
}