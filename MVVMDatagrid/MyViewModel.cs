using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace MVVMDatagrid
{
    public class MyViewModel : INotifyPropertyChanged
    {
        #region implement INotifyPropertyChanged
        readonly DispatcherTimer timer = new DispatcherTimer();
        //private DispatcherTimer timer;
        public SoundPlayer sound = new SoundPlayer();
        public event PropertyChangedEventHandler PropertyChanged;
        public string xmlString = $"{Environment.CurrentDirectory}\\AlarmClockList.xml";

        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
        private string _currentTime;

        public DispatcherTimer _timer;

        public string CurrentTime
        {
            get
            {
                return this._currentTime;
            }
            set
            {
                if (_currentTime == value)
                    return;
                _currentTime = value;
                RaisePropertyChanged("CurrentTime");
            }
        }

        public MyViewModel()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer1_Tick;
            timer.Start();
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (sender, args) =>
            {
                CurrentTime = DateTime.Now.ToLongTimeString();
            };
            _timer.Start();
        }
        public void Timer1_Tick(object sender, EventArgs e)
        {

            DateTime currentTime = DateTime.Now;
            foreach (var al in _employeeCollection.ToList<Employee>())
            {

                if (currentTime.Hour == al.Hours && currentTime.Minute == al.Minutes && currentTime.Date == al.Date && currentTime.Second == al.Seconds)
                {

                    try
                    {
                        sound.Stream = Properties.Resources.basic;
                        //if (sound.Stream == null)
                        //{
                        //    sound.Stream = Properties.Resources.basic;
                        //}
                        //sound.SoundLocation = @"C:\Users\irini\OneDrive\Робочий стіл\MVVMAlarm\AlarmClock\bin\Debug\sounds.basic2.wav";
                        sound.PlayLooping();
                        //dataGrid.Items.Refresh();
                        MessageBox.Show(al.Message);

                    }
                    catch
                    {
                        MessageBox.Show("finished!");
                    }
                    al.IsCalled = true;
                }
            }
        }
        private int _seconds;
        //use to bind textbox
        public int Seconds
        {
            get { return _seconds; }
            set
            {
                if (_seconds != value)
                {
                    _seconds = value;
                    RaisePropertyChanged("Seconds");
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
                    RaisePropertyChanged("Minutes");
                }
            }
        }
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
                    RaisePropertyChanged("Hours");
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
                    RaisePropertyChanged("Date");
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
                    RaisePropertyChanged("Message");
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
                    RaisePropertyChanged("IsCalled");
                }
            }
        }

        private ObservableCollection<Employee> _employeeCollection;
        //use to bind datagrid
        public ObservableCollection<Employee> EmployeeCollection
        {
            get
            {
                if (_employeeCollection == null)
                {
                    _employeeCollection = new ObservableCollection<Employee>();
                }

                return _employeeCollection;
            }
            set
            {
                if (_employeeCollection != value)
                {
                    _employeeCollection = value;
                    RaisePropertyChanged("EmployeeCollection");
                }
            }
        }
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      EmployeeCollection.Add(new Employee { Seconds = Seconds, Minutes = Minutes, Hours = Hours, Date = Date, IsCalled = IsCalled, Message = Message });

                      //Phone phone = new Phone();
                      //Phones.Insert(0, phone);
                      //SelectedPhone = phone;
                  }));
            }
        }
        private RelayCommand musicoffCommand;
        public RelayCommand MusicOffCommand
        {
            get
            {
                return musicoffCommand ??
                  (musicoffCommand = new RelayCommand(obj =>
                  {
                      sound.Stop();
                      //EmployeeCollection.Add(new Employee { Seconds = Seconds, Minutes = Minutes, Hours = Hours, Date = Date, IsCalled = IsCalled, Message = Message });

                      //Phone phone = new Phone();
                      //Phones.Insert(0, phone);
                      //SelectedPhone = phone;
                  }));
            }
        }
        //public RelayCommand SaveCommand
        //{
        //    get
        //    {
        //        return new RelayCommand(() =>
        //        {
        //            if (Seconds != null)
        //            {
        //                //clockTimer.Interval = TimeSpan.FromSeconds(1);
        //                //CreateNewTimer();
        //                EmployeeCollection.Add(new Employee { Seconds = Seconds, Minutes = Minutes, Hours = Hours, Date = Date, IsCalled = IsCalled, Message = Message });
        //            }
        //        });
        //    }
        private Employee selectedPhone;
        public Employee SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                RaisePropertyChanged("SelectedPhone");
            }
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Employee phone = obj as Employee;
                      if (phone != null)
                      {
                          EmployeeCollection.Remove(phone);
                      }
                  },
                 (obj) => EmployeeCollection.Count > 0));
            }
        }
        private RelayCommand saveListCommand;
        public RelayCommand SaveListCommand
        {
            get
            {
                return saveListCommand ??
                  (saveListCommand = new RelayCommand(obj =>
                  {
                      bool fileExist = File.Exists(xmlString);
                      if (!fileExist)
                      {
                          File.CreateText(xmlString).Dispose();
                      }
                      if (!String.IsNullOrEmpty(xmlString))
                      {

                          XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Employee>));
                          //TextWriter tw = new StreamWriter("alarmClocks.xml");
                          TextWriter txtWriter = new StreamWriter(xmlString);

                          formatter.Serialize(txtWriter, EmployeeCollection);
                          txtWriter.Close();
                          MessageBox.Show("List saved!");
                      }
                  },
                 (obj) => EmployeeCollection.Count > 0));
            }
        }
        private RelayCommand showListCommand;
        public RelayCommand ShowListCommand
        {
            get
            {
                return showListCommand ??
                  (showListCommand = new RelayCommand(obj =>
                  {
                      bool fileExist = File.Exists(xmlString);
                      if (!fileExist)
                      {
                          File.CreateText(xmlString).Dispose();
                      }
                      if (!String.IsNullOrEmpty(xmlString))
                      {
                          XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<Employee>));

                          //string xmlString = "alarmClocks.xml";
                          StreamReader reader = new StreamReader(xmlString);
                          EmployeeCollection = (ObservableCollection<Employee>)formatter.Deserialize(reader);
                          reader.Close();
                          //dataGrid.ItemsSource = alarmclock;
                      }
                  }));
               
            }
        }
        private RelayCommand snoozeCommand;
        public RelayCommand SnoozeCommand
        {
            get
            {
                return snoozeCommand ??
                  (snoozeCommand = new RelayCommand(obj =>
                  {
                      SnoozeWindow w = new SnoozeWindow();
                      w.ShowDialog();
                      //WindowService service = new WindowService();
                      //service.CreateWindow();
                      MessageBox.Show(((SnoozeViewModel)w.DataContext).DelayHours.ToString());
                      DateTime currentTime = DateTime.Now;
                      EmployeeCollection.Add(new Employee()
                      {
                          Minutes = currentTime.Minute + ((SnoozeViewModel)w.DataContext).DelayMinutes,
                          Seconds = currentTime.Second + ((SnoozeViewModel)w.DataContext).DelaySeconds,
                          Hours = currentTime.Hour + ((SnoozeViewModel)w.DataContext).DelayHours,
                          Date = currentTime.Date,
                      });
                      sound.Stop();
                      MessageBox.Show("Alarm Clock is snoozed!");
                  },
                 (obj) => EmployeeCollection.Count > 0));
            }
        }
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                  (updateCommand = new RelayCommand(obj =>
                  {
                      Employee phone = obj as Employee;

                      UpdateWindow w = new UpdateWindow();
                      w.ShowDialog();
                      //WindowService service = new WindowService();
                      //service.CreateWindow();
                      MessageBox.Show(((UpdateViewModel)w.DataContext).NewHours.ToString());

                      phone.Hours = ((UpdateViewModel)w.DataContext).NewHours;
                      phone.Minutes = ((UpdateViewModel)w.DataContext).NewMinutes;
                      phone.Seconds = ((UpdateViewModel)w.DataContext).NewSeconds;
                      phone.Date = ((UpdateViewModel)w.DataContext).NewDate;
                      phone.Message = ((UpdateViewModel)w.DataContext).NewMessage;


                  },
                 (obj) => EmployeeCollection.Count > 0));
            }
        }
    }

}
