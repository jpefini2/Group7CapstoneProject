using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AdvisementManagerDesktopApp.Controller;
using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerDesktopApp.Model;
using AdvisementManagerDesktopApp.Resources;
using NotificationPanel;

namespace AdvisementManagerDesktopApp.View
{
    public partial class UpdateAvailabilityForm : Form
    {
        public AdvisementSessionsForm ParentForm { get; set; }
        private bool wasClosedExitedProperly = false;

        private UpdateAvailabilityController updateAvailability = new();
        private Advisor advisor;
        private readonly NotificationController notificationController = new();
        public UpdateAvailabilityForm(Advisor advisor)
        {
            InitializeComponent();
            this.advisor = advisor;
            this.setUpScreen();
            
        }

        private void setUpNotifications()
        {
            NotificationController notificationController = new();
            var notifications = notificationController.GetNotifications(this.advisor.Id);

            var notificationTextData = NotificationController.GetPanelNotifications(notifications);

            this.notificationPanel.SetUpNotifications(notificationTextData);
        }
        private void setUpScreen()
        {
            var timeSlots = this.createTimeSlots();
            this.addTimesToTimeComboBoxes(timeSlots);
            
            var currentAvailability = this.updateAvailability.RetrieveAdvisorCurrentAvailability(this.advisor);
            this.loadAdvisorCurrentAvailability(currentAvailability);
            this.setUpNotifications();
            this.notificationPanel.RemovedButtonClicked += this.RemoveButtonClicked;
            this.notificationPanel.RemoveAllClicked += this.RemoveAllButtonClicked;
        }

        public void RemoveButtonClicked(object sender, RemovedNotificationEventArgs e)
        {
            notificationController.RemoveNotification(e.Id);
        }

        public void RemoveAllButtonClicked(object sender, EventArgs e)
        {
            notificationController.RemoveAllNotifications(this.advisor.Id);
        }

        private void loadAdvisorCurrentAvailability(Dictionary<string, IList<string>> currentAvailability)
        {
            
            foreach (var day in currentAvailability)
            {
                var weekDay = day.Key;
                ListBox currentDayListBox = this.getListBoxForDay(weekDay);

                if (currentDayListBox != null)
                {
                    loadTimeSlotsIntoView(currentDayListBox, day);
                }
            }
        }

        private ListBox getListBoxForDay(string weekDay)
        {
            ListBox listBox = new ListBox();
            switch (weekDay)
            {
                case ConstantManager.Monday:
                    listBox = this.monListBox;
                    break;
                case ConstantManager.Tuesday:
                    listBox = this.tuesListBox;
                    break;
                case ConstantManager.Wednesday:
                    listBox = this.wedListBox;
                    break;
                case ConstantManager.Thursday:
                    listBox = this.thursListBox;
                    break;
                case ConstantManager.Friday:
                    listBox = this.friListBox;
                    break;
            }

            return listBox;
        }

        private static void loadTimeSlotsIntoView(ListBox dayListBox, KeyValuePair<string, IList<string>> day)
        {
            
            foreach (var timeSlot in day.Value)
            {
                dayListBox.Items.Add(timeSlot);
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
                MessageBox.Show(@"Please select a day, start time, and end time.");
                return;
            }

            if (this.isStartTimeBeforeEndTime(startTime.ToString(), endTime.ToString()))
            {
                MessageBox.Show(@"Start time must be before end time");
                return;
            }

            if (this.isTimeSlotOverlapped(day.ToString(), startTime.ToString(), endTime.ToString()))
            {
                MessageBox.Show(@"Time slot must not overlap existing timeslots in the same day.");
                return;
            }

            var timeSlot = startTime + "-" + endTime;
            this.addTime(day.ToString(), timeSlot);
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

        private void removeTime(string controlName, string timeSlot)
        {
            const string monday = "monListBox";
            const string tuesday = "tuesListBox";
            const string wednesday = "wedListBox";
            const string thursday = "thursListBox";
            const string friday = "friListBox";


            switch (controlName)
            {
                case monday:
                    this.monListBox.Items.Remove(timeSlot);
                    break;
                case tuesday:
                    this.tuesListBox.Items.Remove(timeSlot);
                    break;
                case wednesday:
                    this.wedListBox.Items.Remove(timeSlot);
                    break;
                case thursday:
                    this.thursListBox.Items.Remove(timeSlot);
                    break;
                case friday:
                    this.friListBox.Items.Remove(timeSlot);
                    break;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            var meetingCancelResult = MessageBox.Show(@"Items have not been saved are you sure you want to cancel?", @"Cancel Update", MessageBoxButtons.YesNo);
            
            if (meetingCancelResult == DialogResult.Yes)
            {
                this.wasClosedExitedProperly = true;
                this.ParentForm.Show();
                Close();
            }
        }

        private void removeTimeBtn_Click(object sender, EventArgs e)
        {
            var timeSlot = string.Empty;

            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(ListBox))
                {
                    var timeValue = ((ListBox)control).SelectedItem;
                    var controlName = control.Name;
                    timeSlot = extractTimeToRemove(timeValue, timeSlot);
                    this.removeTime(controlName, timeSlot);
                }
            }
        }

        private static string extractTimeToRemove(object timeValue, string timeSlot)
        {
            if (timeValue != null)
            {
                timeSlot = timeValue.ToString();
            }

            return timeSlot;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            var timeSlots = new Dictionary<string, List<string>>();
            this.createTimeDayAndSlot(this.monListBox, timeSlots, "Monday");
            this.createTimeDayAndSlot(this.tuesListBox, timeSlots, "Tuesday");
            this.createTimeDayAndSlot(this.wedListBox, timeSlots, "Wednesday");
            this.createTimeDayAndSlot(this.thursListBox, timeSlots, "Thursday");
            this.createTimeDayAndSlot(this.friListBox, timeSlots, "Friday");


            this.updateAvailability.UpdateAvailability(this.advisor, timeSlots);
            MessageBox.Show(@"Availability Updated");

            this.wasClosedExitedProperly = true;
            this.ParentForm.Show();
            this.Close();
        }

        private void createTimeDayAndSlot(Control control, Dictionary<string, List<string>> timeSlots, string pageName)
        {
            const int empty = 0;
            var timeValue = ((ListBox) control);
            if (timeValue != null && timeValue.Items.Count > empty)
            {
                var times = new List<string>();
                foreach (var time in timeValue.Items)
                {
                    times.Add(time.ToString());
                }

                timeSlots.Add(pageName, times);
            }
        }

        private bool isStartTimeBeforeEndTime(string startTime, string endTime)
        {
            var startTimeSpan = DateTime.ParseExact(startTime, "h:mm tt", null, System.Globalization.DateTimeStyles.None).TimeOfDay;
            var endTimeSpan = DateTime.ParseExact(endTime, "h:mm tt", null, System.Globalization.DateTimeStyles.None).TimeOfDay;

            return TimeSpan.Compare(startTimeSpan, endTimeSpan) >= 0;
        }

        private bool isTimeSlotOverlapped(string day, string startTime, string endTime)
        {
            WeekDay dayEnum = (WeekDay)Enum.Parse(typeof(WeekDay), day, true);
            var startTimeSpan = DateTime.ParseExact(startTime, "h:mm tt", null, System.Globalization.DateTimeStyles.None).TimeOfDay;
            var endTimeSpan = DateTime.ParseExact(endTime, "h:mm tt", null, System.Globalization.DateTimeStyles.None).TimeOfDay;

            ListBox.ObjectCollection sameDayTimeslots = this.getTimeslotsOnDay(dayEnum.ToString());

            foreach (var existingTimeslot in sameDayTimeslots)
            {
                var existingStartAndEndTimes = existingTimeslot.ToString().Split('-');
                var existingStartTimespan = DateTime.ParseExact(existingStartAndEndTimes[0], "h:mm tt", null, System.Globalization.DateTimeStyles.None).TimeOfDay;
                var existingEndTimespan = DateTime.ParseExact(existingStartAndEndTimes[1], "h:mm tt", null, System.Globalization.DateTimeStyles.None).TimeOfDay;

                bool newSlotStartsBeforeExistingEnds = TimeSpan.Compare(startTimeSpan, existingEndTimespan) <= 0;
                bool newSlotStartsAfterOrAtExistingStarts = TimeSpan.Compare(startTimeSpan, existingStartTimespan) >= 0;

                bool newSlotEndsBeforeOrAtExistingEnds = TimeSpan.Compare(endTimeSpan, existingEndTimespan) <= 0;
                bool newSlotEndsAfterExistingStarts = TimeSpan.Compare(endTimeSpan, existingStartTimespan) >= 0;

                if (newSlotStartsBeforeExistingEnds && newSlotStartsAfterOrAtExistingStarts ||
                    newSlotEndsBeforeOrAtExistingEnds && newSlotEndsAfterExistingStarts)
                    return true;
            }

            return false;
        }

        private ListBox.ObjectCollection getTimeslotsOnDay(string day)
        {
            switch (day)
            {
                case ConstantManager.Monday:
                    return this.monListBox.Items;
                case ConstantManager.Tuesday:
                    return this.tuesListBox.Items;
                case ConstantManager.Wednesday:
                    return this.wedListBox.Items;
                case ConstantManager.Thursday:
                    return this.thursListBox.Items;
                case ConstantManager.Friday:
                    return this.friListBox.Items;
            }

            return null;
        }

        private void newItemSelected(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(ListBox) && control != sender)
                {
                    ((ListBox) control).SelectedItem = null;
                }
            }
        }

        private void UpdateAvailabilityForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!wasClosedExitedProperly)
                this.ParentForm.Close();
        }
    }
}
