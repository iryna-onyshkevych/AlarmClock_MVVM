using System.ComponentModel;

namespace MVVMAlarmClock
{
    public class SnoozeViewModel : INotifyPropertyChanged
    {
        private int delaySeconds { get; set; }
        private int delayMinutes { get; set; }
        private int delayHours { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public int DelayMinutes
        {
            get { return delayMinutes; }
            set
            {
                if (delayMinutes != value)
                {
                    delayMinutes = value;
                    RaisePropertyChanged("DelayMinutes");
                }
            }
        }

        public int DelayHours
        {
            get { return delayHours; }
            set
            {
                if (delayHours != value)
                {
                    delayHours = value;
                    RaisePropertyChanged("DelayHours");
                }
            }
        }

        public int DelaySeconds
        {
            get { return delaySeconds; }
            set
            {
                if (delaySeconds != value)
                {
                    delaySeconds = value;
                    RaisePropertyChanged("DelaySeconds");
                }
            }
        }
       
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
        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
