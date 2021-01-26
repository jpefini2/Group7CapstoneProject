
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
            this.homeBtn = new System.Windows.Forms.Button();
            this.viewBtn = new System.Windows.Forms.Button();
            this.allStudentsListBox = new System.Windows.Forms.ListBox();
            this.studentsWithHoldsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // homeBtn
            // 
            this.homeBtn.Location = new System.Drawing.Point(0, 1);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(115, 53);
            this.homeBtn.TabIndex = 0;
            this.homeBtn.Text = "Home";
            this.homeBtn.UseVisualStyleBackColor = true;
            // 
            // viewBtn
            // 
            this.viewBtn.Location = new System.Drawing.Point(318, 385);
            this.viewBtn.Name = "viewBtn";
            this.viewBtn.Size = new System.Drawing.Size(115, 53);
            this.viewBtn.TabIndex = 1;
            this.viewBtn.Text = "View";
            this.viewBtn.UseVisualStyleBackColor = true;
            // 
            // allStudentsListBox
            // 
            this.allStudentsListBox.FormattingEnabled = true;
            this.allStudentsListBox.ItemHeight = 15;
            this.allStudentsListBox.Location = new System.Drawing.Point(88, 84);
            this.allStudentsListBox.Name = "allStudentsListBox";
            this.allStudentsListBox.Size = new System.Drawing.Size(250, 259);
            this.allStudentsListBox.TabIndex = 2;
            // 
            // studentsWithHoldsListBox
            // 
            this.studentsWithHoldsListBox.FormattingEnabled = true;
            this.studentsWithHoldsListBox.ItemHeight = 15;
            this.studentsWithHoldsListBox.Location = new System.Drawing.Point(435, 84);
            this.studentsWithHoldsListBox.Name = "studentsWithHoldsListBox";
            this.studentsWithHoldsListBox.Size = new System.Drawing.Size(250, 259);
            this.studentsWithHoldsListBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Students";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Students with holds";
            // 
            // AdvisementSessionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.studentsWithHoldsListBox);
            this.Controls.Add(this.allStudentsListBox);
            this.Controls.Add(this.viewBtn);
            this.Controls.Add(this.homeBtn);
            this.Name = "AdvisementSessionsForm";
            this.Text = "Advisment Sessions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button viewBtn;
        private System.Windows.Forms.ListBox allStudentsListBox;
        private System.Windows.Forms.ListBox studentsWithHoldsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}