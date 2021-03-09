using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace MVVMAlarmClock
{
    public class AlarmClockViewModel : INotifyPropertyChanged
    {
        public const int maxHours = 23;
        public static int maxMinutes = 59;
        readonly DispatcherTimer timer = new DispatcherTimer();
        public SoundPlayer sound = new SoundPlayer();
        private string currentTime;
        private int seconds;
        private int minutes;
        private int hours;
        private string message;
        private DateTime date;
        private bool isCalled;
        private RelayCommand saveCommand;
        private RelayCommand musicoffCommand;
        private RelayCommand snoozeCommand;
        private RelayCommand removeCommand;
        private RelayCommand saveListCommand;
        private RelayCommand showListCommand;
        private RelayCommand updateCommand;
        private RelayCommand minutesUpCommand;
        private RelayCommand minutesDownCommand;
        private RelayCommand hoursUpCommand;
        private AlarmClockModel selectedAlarmClock;
        private RelayCommand hoursDownCommand;
        private ObservableCollection<AlarmClockModel> alarmClockCollection;
        public DispatcherTimer _timer;
        public event PropertyChangedEventHandler PropertyChanged;
        public string xmlString = $"{Environment.CurrentDirectory}\\AlarmClockList.xml";
       
        public string CurrentTime
        {
            get
            {
                return this.currentTime;
            }
            set
            {
                if (currentTime == value)
                    return;
                currentTime = value;
                RaisePropertyChanged("CurrentTime");
            }
        }

        public AlarmClockViewModel()
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
            foreach (var al in alarmClockCollection.ToList<AlarmClockModel>())
            {
                if (currentTime.Hour == al.Hours && currentTime.Minute == al.Minutes && currentTime.Date == al.Date && currentTime.Second == al.Seconds)
                {
                    try
                    {
                        if (sound.Stream == null)
                        {
                            sound.Stream = Properties.Resources.basic;
                        }
                        sound.PlayLooping();
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

        public ObservableCollection<AlarmClockModel> AlarmClockCollection
        {
            get
            {
                if (alarmClockCollection == null)
                {
                    alarmClockCollection = new ObservableCollection<AlarmClockModel>();
                }
                return alarmClockCollection;
            }
            set
            {
                if (alarmClockCollection != value)
                {
                    alarmClockCollection = value;
                    RaisePropertyChanged("AlarmClockCollection");
                }
            }
        }

        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      AlarmClockCollection.Add(new AlarmClockModel { Seconds = Seconds , Minutes = Minutes, Hours = Hours, Date = Date, IsCalled = IsCalled, Message = Message });
                  }));
            }
        }

        public RelayCommand MusicOffCommand
        {
            get
            {
                return musicoffCommand ??
                  (musicoffCommand = new RelayCommand(obj =>
                  {
                      sound.Stop();
                  }));
            }
        }
       
        public AlarmClockModel SelectedAlarmClock
        {
            get { return selectedAlarmClock; }
            set
            {
                selectedAlarmClock = value;
                RaisePropertyChanged("SelectedAlarmClock");
            }
        }

        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      AlarmClockModel alarmClock = obj as AlarmClockModel;
                      if (alarmClock != null)
                      {
                          AlarmClockCollection.Remove(alarmClock);
                      }
                  },
                 (obj) => AlarmClockCollection.Count > 0));
            }
        }

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
                          XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<AlarmClockModel>));
                          TextWriter txtWriter = new StreamWriter(xmlString);
                          formatter.Serialize(txtWriter, AlarmClockCollection);
                          txtWriter.Close();
                          MessageBox.Show("List saved!");
                      }
                  },
                 (obj) => AlarmClockCollection.Count > 0));
            }
        }

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
                          XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<AlarmClockModel>));
                          StreamReader reader = new StreamReader(xmlString);
                          AlarmClockCollection = (ObservableCollection<AlarmClockModel>)formatter.Deserialize(reader);
                          reader.Close();
                      }
                  }));
            }
        }

        public RelayCommand SnoozeCommand
        {
            get
            {
                return snoozeCommand ??
                  (snoozeCommand = new RelayCommand(obj =>
                  {
                      SnoozeWindow w = new SnoozeWindow();
                      w.ShowDialog();
                      DateTime currentTime = DateTime.Now;
                      AlarmClockCollection.Add(new AlarmClockModel()
                      {
                          Minutes = currentTime.Minute + ((SnoozeViewModel)w.DataContext).DelayMinutes,
                          Seconds = currentTime.Second + ((SnoozeViewModel)w.DataContext).DelaySeconds,
                          Hours = currentTime.Hour + ((SnoozeViewModel)w.DataContext).DelayHours,
                          Date = currentTime.Date,
                      });
                      sound.Stop();
                      MessageBox.Show("Alarm Clock is snoozed!");
                  },
                 (obj) => AlarmClockCollection.Count > 0));
            }
        }

        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                  (updateCommand = new RelayCommand(obj =>
                  {
                      AlarmClockModel alarmClock = obj as AlarmClockModel;
                      UpdateWindow w = new UpdateWindow();
                      w.ShowDialog();
                      alarmClock.Hours = ((UpdateViewModel)w.DataContext).NewHours;
                      alarmClock.Minutes = ((UpdateViewModel)w.DataContext).NewMinutes;
                      alarmClock.Seconds = ((UpdateViewModel)w.DataContext).NewSeconds;
                      alarmClock.Date = ((UpdateViewModel)w.DataContext).NewDate;
                      alarmClock.Message = ((UpdateViewModel)w.DataContext).NewMessage;
                  },
                 (obj) => AlarmClockCollection.Count > 0));
            }
        }

        public RelayCommand MinutesUpCommand
        {
            get
            {
                return minutesUpCommand ??
                  (minutesUpCommand = new RelayCommand(obj =>
                  {
                      var curMinute = Minutes;
                      curMinute++;
                      if (curMinute > maxMinutes)
                      {
                          curMinute = 0;
                          Minutes = curMinute;
                      }
                      Minutes = curMinute;
                  }));
            }
        }

        public RelayCommand MinutesDownCommand
        {
            get
            {
                return minutesDownCommand ??
                  (minutesDownCommand = new RelayCommand(obj =>
                  {
                      var curHour = Minutes;
                      curHour--;
                      if (curHour < 0)
                      {
                          curHour = maxHours;
                          Minutes = curHour;
                      }
                      Minutes = curHour;
                  }));
            }
        }

        public RelayCommand HoursUpCommand
        {
            get
            {
                return hoursUpCommand ??
                  (hoursUpCommand = new RelayCommand(obj =>
                  {
                      var curHour = Hours;
                      curHour++;
                      if (curHour > maxHours)
                      {
                          curHour = 0;
                          Hours = curHour;
                      }
                      Hours = curHour;
                  }));
            }
        }

        public RelayCommand HoursDownCommand
        {
            get
            {
                return hoursDownCommand ??
                  (hoursDownCommand = new RelayCommand(obj =>
                  {
                      var curHour = Hours;
                      curHour--;
                      if (curHour < 0)
                      {
                          curHour = maxHours;
                          Hours = curHour;
                      }
                      Hours= curHour;
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
