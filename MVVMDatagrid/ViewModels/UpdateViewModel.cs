using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMAlarmClock
{
    public class UpdateViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
       
        


        private int _newMinutes { get; set; }
        public int NewMinutes
        {
            get { return _newMinutes; }
            set
            {
                if (_newMinutes != value)
                {
                    _newMinutes = value;
                    RaisePropertyChanged("NewMinutes");

                }
            }
        }
        private int _newSeconds { get; set; }
        public int NewSeconds
        {
            get { return _newSeconds; }
            set
            {
                if (_newSeconds != value)
                {
                    _newSeconds = value;
                    RaisePropertyChanged("NewSeconds");

                }
            }
        }
        public int _newHours { get; set; }
        public int NewHours
        {
            get { return _newHours; }
            set
            {
                if (_newHours != value)
                {
                    _newHours = value;
                    RaisePropertyChanged("NewHours");

                }
            }
        }
        public DateTime _newDate { get; set; }
        public DateTime NewDate
        {
            get { return _newDate; }
            set
            {
                if (_newDate != value)
                {
                    _newDate = value;
                    RaisePropertyChanged("NewDate");

                }
            }
        }
        public string _newMessage { get; set; }
        public string NewMessage
        {
            get { return _newMessage; }
            set
            {
                if (_newMessage != value)
                {
                    _newMessage = value;
                    RaisePropertyChanged("NewMessage");

                }
            }
        }

        public const int maxHours = 23;
        public static int maxMinutes = 59;
        //private RelayCommand okCommand;
        //public RelayCommand OkCommand
        //{
        //    get
        //    {
        //        return okCommand ??
        //          (okCommand = new RelayCommand(obj =>
        //          {

        //              //DelayHours = DelayHours;
        //              //DelayMinutes = DelayMinutes;
        //              //DelaySeconds = DelaySeconds;
                      
        //              //WindowService service = new WindowService();
        //              //service.CloseWindow();
        //          }));
        //    }
        //}
       

    }
}
