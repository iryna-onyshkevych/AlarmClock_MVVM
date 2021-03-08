using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMAlarmClock
{
    public class SnoozeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string xmlString = $"{Environment.CurrentDirectory}\\AlarmClockList.xml";

        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        private int _delayMinutes { get; set; }

        //use to binding textbox
        public int DelayMinutes
        {
            get { return _delayMinutes; }
            set
            {
                if (_delayMinutes != value)
                {
                    _delayMinutes = value;
                    RaisePropertyChanged("DelayMinutes");
                }
            }
        }
        private int _delayHours { get; set; }

        public int DelayHours
        {
            get { return _delayHours; }
            set
            {
                if (_delayHours != value)
                {
                    _delayHours = value;
                    RaisePropertyChanged("DelayHours");

                }
            }
        }
        private int _delaySeconds { get; set; }

        public int DelaySeconds
        {
            get { return _delaySeconds; }
            set
            {
                if (_delaySeconds != value)
                {
                    _delaySeconds = value;
                    RaisePropertyChanged("DelaySeconds");

                }
            }
        }
        //SnoozeModel snooze = new SnoozeModel();
        //public int ggminutes;
        private RelayCommand okCommand;
        public RelayCommand OkCommand
        {
            get
            {
                return okCommand ??
                  (okCommand = new RelayCommand(obj =>
                  {
                      //DelayHours = DelayHours;
                      //DelayMinutes = DelayMinutes;
                      //DelaySeconds = DelaySeconds;
                      //this.
                      //w.DataContext = this;
                      //w.Close();
                      //WindowService service = new WindowService();
                      //service.CloseWindow();
                  }));
            }
        }
    }
}
