using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDatagrid
{
    public class Employee : INotifyPropertyChanged
    {
        #region implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        private int _seconds;

        //use to binding textbox
        public int Seconds
        {
            get { return _seconds; }
            set
            {
                if (_seconds != value)
                {
                    _seconds = value;
                }
            }
        }
        private int _minutes;
        //use to bind textbox
        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (_minutes != value)
                {
                    _minutes = value;
                }
            }
        }
        //private int _employeeName;
        ////use to binding textbox
        //public int EmployeeName
        //{
        //    get { return _employeeName; }
        //    set
        //    {
        //        if (_employeeName != value)
        //        {
        //            _employeeName = value;
        //        }
        //    }
        //}
        private int _hours;
        //use to bind textbox
        public int Hours
        {
            get { return _hours; }
            set
            {
                if (_hours != value)
                {
                    _hours = value;
                }
            }
        }
        private DateTime _date;
        //use to bind textbox
        public DateTime Date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
                }
            }
        }
        private string _message;
        //use to bind textbox
        public string Message
        {
            get { return _message; }
            set
            {
                if (_message != value)
                {
                    _message = value;
                }
            }
        }
        private bool _iscalled;
        //use to bind textbox
        public bool IsCalled
        {
            get { return _iscalled; }
            set
            {
                if (_iscalled != value)
                {
                    _iscalled = value;
                }
            }
        }
    }
}
