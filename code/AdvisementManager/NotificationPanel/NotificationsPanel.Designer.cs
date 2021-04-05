namespace NotificationPanel
{
    partial class NotificationsPanel
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.notificationPanel = new System.Windows.Forms.Panel();
            this.notificationsListBox = new System.Windows.Forms.ListBox();
            this.removeAllBtn = new System.Windows.Forms.Button();
            this.removeBtn = new System.Windows.Forms.Button();
            this.notificationsButton = new System.Windows.Forms.Button();
            this.notifcationCountLbl = new System.Windows.Forms.Label();
            this.notificationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // notificationPanel
            // 
            this.notificationPanel.Controls.Add(this.notificationsListBox);
            this.notificationPanel.Controls.Add(this.removeAllBtn);
            this.notificationPanel.Controls.Add(this.removeBtn);
            this.notificationPanel.Location = new System.Drawing.Point(7, 32);
            this.notificationPanel.Name = "notificationPanel";
            this.notificationPanel.Size = new System.Drawing.Size(282, 208);
            this.notificationPanel.TabIndex = 19;
            this.notificationPanel.Visible = false;
            // 
            // notificationsListBox
            // 
            this.notificationsListBox.FormattingEnabled = true;
            this.notificationsListBox.Location = new System.Drawing.Point(3, 3);
            this.notificationsListBox.Name = "notificationsListBox";
            this.notificationsListBox.Size = new System.Drawing.Size(202, 160);
            this.notificationsListBox.TabIndex = 15;
            // 
            // removeAllBtn
            // 
            this.removeAllBtn.Location = new System.Drawing.Point(59, 169);
            this.removeAllBtn.Name = "removeAllBtn";
            this.removeAllBtn.Size = new System.Drawing.Size(75, 23);
            this.removeAllBtn.TabIndex = 14;
            this.removeAllBtn.Text = "Remove All";
            this.removeAllBtn.UseVisualStyleBackColor = true;
            // 
            // removeBtn
            // 
            this.removeBtn.Location = new System.Drawing.Point(208, 72);
            this.removeBtn.Name = "removeBtn";
            this.removeBtn.Size = new System.Drawing.Size(68, 24);
            this.removeBtn.TabIndex = 13;
            this.removeBtn.Text = "Remove";
            this.removeBtn.UseVisualStyleBackColor = true;
            // 
            // notificationsButton
            // 
            this.notificationsButton.Location = new System.Drawing.Point(190, 3);
            this.notificationsButton.Name = "notificationsButton";
            this.notificationsButton.Size = new System.Drawing.Size(75, 23);
            this.notificationsButton.TabIndex = 18;
            this.notificationsButton.Text = "Notifications";
            this.notificationsButton.UseVisualStyleBackColor = true;
            this.notificationsButton.Click += new System.EventHandler(this.notificationsButton_Click);
            // 
            // notifcationCountLbl
            // 
            this.notifcationCountLbl.AutoSize = true;
            this.notifcationCountLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notifcationCountLbl.Location = new System.Drawing.Point(271, 3);
            this.notifcationCountLbl.Name = "notifcationCountLbl";
            this.notifcationCountLbl.Size = new System.Drawing.Size(18, 20);
            this.notifcationCountLbl.TabIndex = 17;
            this.notifcationCountLbl.Text = "0";
            // 
            // NotificationsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.notificationPanel);
            this.Controls.Add(this.notificationsButton);
            this.Controls.Add(this.notifcationCountLbl);
            this.Name = "NotificationsPanel";
            this.Size = new System.Drawing.Size(295, 30);
            this.notificationPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel notificationPanel;
        private System.Windows.Forms.ListBox notificationsListBox;
        private System.Windows.Forms.Button removeAllBtn;
        private System.Windows.Forms.Button removeBtn;
        private System.Windows.Forms.Button notificationsButton;
        private System.Windows.Forms.Label notifcationCountLbl;
    }
}
