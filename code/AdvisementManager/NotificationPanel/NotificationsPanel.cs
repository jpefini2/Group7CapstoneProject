using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotificationPanel
{
    public partial class NotificationsPanel: UserControl
    {
        public NotificationsPanel()
        {
            InitializeComponent();
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
    }
}
