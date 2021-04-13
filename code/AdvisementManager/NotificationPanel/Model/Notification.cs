using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPanel.Model
{
    public class Notification
    {
        public int Id { get; set; }
        
        public string NotifMessage { get; set; }

        public override string ToString()
        {
            return this.NotifMessage;
        }
    }
}
