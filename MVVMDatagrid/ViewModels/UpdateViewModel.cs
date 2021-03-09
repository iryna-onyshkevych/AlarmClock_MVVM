using System;
using System.ComponentModel;

namespace MVVMAlarmClock
{
    public class UpdateViewModel : INotifyPropertyChanged
    {
        private int newMinutes { get; set; }
        private int newSeconds { get; set; }
        public int newHours { get; set; }
        public DateTime newDate { get; set; }
        public string newMessage { get; set; }

        public const int maxHours = 23;
        public static int maxMinutes = 59;
        public event PropertyChangedEventHandler PropertyChanged;

        public int NewMinutes
        {
            get { return newMinutes; }
            set
            {
                if (newMinutes != value)
                {
                    newMinutes = value;
                    RaisePropertyChanged("NewMinutes");
                }
            }
        }

        public int NewSeconds
        {
            get { return newSeconds; }
            set
            {
                if (newSeconds != value)
                {
                    newSeconds = value;
                    RaisePropertyChanged("NewSeconds");
                }
            }
        }

        public int NewHours
        {
            get { return newHours; }
            set
            {
                if (newHours != value)
                {
                    newHours = value;
                    RaisePropertyChanged("NewHours");
                }
            }
        }

        public DateTime NewDate
        {
            get { return newDate; }
            set
            {
                if (newDate != value)
                {
                    newDate = value;
                    RaisePropertyChanged("NewDate");
                }
            }
        }

        public string NewMessage
        {
            get { return newMessage; }
            set
            {
                if (newMessage != value)
                {
                    newMessage = value;
                    RaisePropertyChanged("NewMessage");
                }
            }
        }
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
