using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotificationPanel.Model;

namespace NotificationPanel
{
    /// <summary>The notification panel for manging user notifications</summary>
    public partial class NotificationsPanel: UserControl
    {
        /// <summary>Occurs when [remove all clicked].</summary>
        public event EventHandler<EventArgs> RemoveAllClicked;

        /// <summary>Occurs when [removed button clicked].</summary>
        public event EventHandler<RemovedNotificationEventArgs> RemovedButtonClicked;

        /// <summary>Initializes a new instance of the <see cref="NotificationsPanel" /> class.</summary>
        public NotificationsPanel()
        {
            InitializeComponent();
        }


        /// <summary>Sets up notifications. with the provided list of notifications</summary>
        /// <param name="notifications">The notifications.</param>
        public void SetUpNotifications(List<Notification> notifications)
        {
            this.notificationsListBox.Items.Clear();
            var notificationCounter = 0;
            foreach (var notification in notifications)
            {
                this.notificationsListBox.Items.Add(notification);
                notificationCounter++;
            }

            this.notifcationCountLbl.Text = notificationCounter.ToString();
        }

        private void notificationsButton_Click(object sender, EventArgs e)
        {
            var openSize = new Size(295, 251);
            var closedSize = new Size(295, 30);

            if (this.notificationPanel.Visible == false)
            {
                this.notificationPanel.Visible = true;
                this.Size = openSize;
            }
            else
            {
                this.notificationPanel.Visible = false;
                this.Size = closedSize;
            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            var selectedNotif = (Notification) this.notificationsListBox.SelectedItem;

            this.notificationsListBox.Items.RemoveAt(this.notificationsListBox.SelectedIndex);
            this.notifcationCountLbl.Text = this.notificationsListBox.Items.Count.ToString();

            var removeButtonClicked = new RemovedNotificationEventArgs {Id = selectedNotif.Id};
            this.RemovedButtonClicked?.Invoke(this, removeButtonClicked);
        }

        private void removeAllBtn_Click(object sender, EventArgs e)
        {
            this.notificationsListBox.Items.Clear();
            this.notifcationCountLbl.Text = @"0";

            var removeAllButtonClicked = new EventArgs();
            this.RemoveAllClicked?.Invoke(this, removeAllButtonClicked);
        }
    }

    public class RemovedNotificationEventArgs : EventArgs
    {
        public int Id { get; set; }
    }

    public class RemovedAllNotificationsEventArgs : EventArgs
    {
        public List<int> Ids;
    }
}
