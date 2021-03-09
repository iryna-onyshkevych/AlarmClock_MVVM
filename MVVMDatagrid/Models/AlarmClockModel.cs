using System;
using System.ComponentModel;

namespace MVVMAlarmClock
{
    public class AlarmClockModel : INotifyPropertyChanged
    {
        private int seconds;
        private int hours;
        private int minutes;
        private DateTime date;
        private string message;
        private bool isCalled;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
       
        public int Hours
        {
            get { return hours; }
            set
            {
                if (hours != value)
                {
                    hours = value;
                    RaisePropertyChanged("Hours");
                }
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (minutes != value)
                {
                    minutes = value;
                    RaisePropertyChanged("Minutes");
                }
            }
        }

        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (seconds != value)
                {
                    seconds = value;
                    RaisePropertyChanged("Seconds");
                }
            }
        }

        public DateTime Date
        {
            get { return date; }
            set
            {
                if (date != value)
                {
                    date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    RaisePropertyChanged("Message");
                }
            }
        }

        public bool IsCalled
        {
            get { return isCalled; }
            set
            {
                if (isCalled != value)
                {
                    isCalled = value;
                    RaisePropertyChanged("IsCalled");
                }
            }
        }
    }
}
