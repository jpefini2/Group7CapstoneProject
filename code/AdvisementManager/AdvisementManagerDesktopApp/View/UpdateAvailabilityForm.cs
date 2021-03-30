using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdvisementManagerDesktopApp.Controller;
using AdvisementManagerDesktopApp.Model;
using AdvisementManagerDesktopApp.Resources;

namespace AdvisementManagerDesktopApp.View
{
    public partial class UpdateAvailabilityForm : Form
    {
        private UpdateAvailabilityController updateAvailability = new UpdateAvailabilityController();
        private Advisor advisor;

        public UpdateAvailabilityForm(Advisor advisor)
        {
            InitializeComponent();
            this.advisor = advisor;
            this.setUpScreen();
        }

        private void setUpScreen()
        {
            var timeSlots = this.createTimeSlots();
            this.addTimesToTimeComboBoxes(timeSlots);
            
            var currentAvailability = this.updateAvailability.RetrieveAdvisorCurrentAvailability(this.advisor);
            this.loadAdvisorCurrentAvailability(currentAvailability);
        }

        private void loadAdvisorCurrentAvailability(Dictionary<string, IList<string>> currentAvailability)
        {
            foreach (var day in currentAvailability)
            {
                var tabPageControls = this.availabilityTabControl.Controls.OfType<TabPage>().
                                           FirstOrDefault(tab => tab.Text.Equals(day.Key))
                                           ?.Controls;
                if (tabPageControls != null)
                {
                    loadTimeSlotsIntoView(tabPageControls, day);
                }
            }
        }

        private static void loadTimeSlotsIntoView(Control.ControlCollection tabPageControls, KeyValuePair<string, IList<string>> day)
        {
            foreach (Control tabControl in tabPageControls)
            {
                if (tabControl.GetType() == typeof(ListBox))
                {
                    foreach (var timeSlot in day.Value)
                    {
                        ((ListBox) tabControl).Items.Add(timeSlot);
                    }
                }
            }
        }

        private void addTimesToTimeComboBoxes(IList<string> timeSlots)
        {
            foreach (var time in timeSlots)
            {
                this.startTimeComboBox.Items.Add(time);
                this.endTimeComboBox.Items.Add(time);
            }
        }

        private IList<string> createTimeSlots()
        {
            var timeSlots = new List<string>();
            var timeLoop = new DateTime(0); 
            timeLoop = timeLoop.Add(new TimeSpan(00, 00, 0)); 
            const int numberOfIntervals = 48;
            
            for (var i = 0; i < numberOfIntervals; i++) 
            { 
                var time = timeLoop.ToString("h:mm tt"); 
                timeSlots.Add(time); 
                timeLoop = timeLoop.Add(new TimeSpan(0, 30, 0));
            }

            return timeSlots;
        }

        private void addTimeBtn_Click(object sender, EventArgs e)
        {
            var day = this.dayComboBox.SelectedItem;
            var startTime = this.startTimeComboBox.SelectedItem;
            var endTime = this.endTimeComboBox.SelectedItem;
            if (startTime == null || endTime == null || day == null)
            {
                MessageBox.Show(@"Please select a day, start time and end time");
            }
            else
            {
                var timeSlot = startTime + "-" + endTime;
                this.addTime(day.ToString(), timeSlot);
            }
        }

        private void addTime(string day, string timeSlot)
        {
            switch (day)
            {
                case ConstantManager.Monday:
                    this.monListBox.Items.Add(timeSlot);
                    break;
                case ConstantManager.Tuesday:
                    this.tuesListBox.Items.Add(timeSlot);
                    break;
                case ConstantManager.Wednesday:
                    this.wedListBox.Items.Add(timeSlot);
                    break;
                case ConstantManager.Thursday:
                    this.thursListBox.Items.Add(timeSlot);
                    break;
                case ConstantManager.Friday:
                    this.friListBox.Items.Add(timeSlot);
                    break;
            }
        }

        private void removeTime(string tabDay, string timeSlot)
        {
            switch (tabDay)
            {
                case ConstantManager.Monday:
                    this.monListBox.Items.Remove(timeSlot);
                    break;
                case ConstantManager.Tuesday:
                    this.tuesListBox.Items.Remove(timeSlot);
                    break;
                case ConstantManager.Wednesday:
                    this.wedListBox.Items.Remove(timeSlot);
                    break;
                case ConstantManager.Thursday:
                    this.thursListBox.Items.Remove(timeSlot);
                    break;
                case ConstantManager.Friday:
                    this.friListBox.Items.Remove(timeSlot);
                    break;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            var meetingCancelResult = MessageBox.Show(@"Items have not been saved are you sure you want to cancel?", @"Cancel Update", MessageBoxButtons.YesNo);

            if (meetingCancelResult == DialogResult.Yes)
            {
                Close();
            }
        }

        private void removeTimeBtn_Click(object sender, EventArgs e)
        {
            var selectedTab = this.availabilityTabControl.SelectedIndex;
            var tabDay = this.availabilityTabControl.TabPages[selectedTab].Text;
            var timeSlot = string.Empty;
            foreach (Control control in this.availabilityTabControl.SelectedTab.Controls)
            {
                var timeValue = ((ListBox)control).SelectedItem;
                if (control.GetType() == typeof(ListBox))
                {
                    timeSlot = extractTimeToRemove(timeValue, timeSlot);
                }
            }

            this.removeTime(tabDay, timeSlot);
        }

        private static string extractTimeToRemove(object timeValue, string timeSlot)
        {
            if (timeValue == null)
            {
                MessageBox.Show(@"No Time selected to remove.");
            }
            else
            {
                timeSlot = timeValue.ToString();
            }

            return timeSlot;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            var timeSlots = new Dictionary<string, List<string>>();
            foreach (TabPage page in this.availabilityTabControl.TabPages)
            {
                var pageName = page.Text;

                foreach (Control control in page.Controls)
                {
                    this.createTimeDayAndSlot(control, timeSlots, pageName);
                }

            }


            this.updateAvailability.UpdateAvailability(this.advisor, timeSlots);
            MessageBox.Show(@"Availability Updated");
            this.Close();
        }

        private void createTimeDayAndSlot(Control control, Dictionary<string, List<string>> timeSlots, string pageName)
        {
            var timeValue = ((ListBox) control);
            if (timeValue != null)
            {
                var times = new List<string>();
                foreach (var time in timeValue.Items)
                {
                    times.Add(time.ToString());
                }

                timeSlots.Add(pageName, times);
            }
        }
    }
}
