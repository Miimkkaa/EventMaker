using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Store.Preview.InstallControl;
using Windows.UI.Xaml.Controls;
using EventMaker.Annotations;
using EventMaker.Common;
using EventMaker.Convertor;
using EventMaker.Handler;
using EventMaker.Model;
using EventMaker.View;

namespace EventMaker.ViewModel
{
    public class EventViewModel : INotifyPropertyChanged
    {
        //instance fields
        private string _id;
        private string _description;
        private string _name;
        private string _place;
        private EventCatalogSingleton _userSingleton;
        private EventHandlerClass _eventHandler;
        private DateTimeOffset _date;
        private TimeSpan _time;
        private Event _selectedItem;

        //props
        public Event NewItem { get; set; }

        public RelayCommand CreateEvent { get; set; }
        public RelayCommand DeleteEvent { get; set; }
        public RelayCommand NextPage { get; set; }
        public RelayCommand Reset { get; set; }
        public RelayCommand Sorting { get; set; }

        //public ObservableCollection<Event> SortedEvents { get; set; }

        public ObservableCollection<string> Types { get; set; }

        public string SelectedType { get; set; }

        public Event SelectedEvent
        {
            get => _selectedItem;
            set
            { _selectedItem = value;
                OnPropertyChanged(nameof(SelectedEvent));
            }
            
        }

        public EventCatalogSingleton SingletonEvent
        {
            get => _userSingleton;
            set
            {
                _userSingleton = value;
                OnPropertyChanged(nameof(_userSingleton));
            }
        }
        
        //public RelayCommand ResetEvent { get; set; }
        public RelayCommand UpDateEvent { get; set; }

        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Place
        {
            get { return _place; }
            set
            {
                _place = value;
                OnPropertyChanged(nameof(Place));
            }
        }

        public DateTimeOffset Date1
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date1));
            }
        }

        public TimeSpan Time1
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time1));
            }
        }

        //ctor
        public EventViewModel()
        {
            _userSingleton = EventCatalogSingleton.GetInstance();

            DateTime dt = System.DateTime.Now;
            _date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            _time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            DeleteEvent = new RelayCommand(DoRemove);
            CreateEvent = new RelayCommand(DoAdd);
            Reset = new RelayCommand(DoReset);
            Sorting = new RelayCommand(DoSorting);
            //ResetEvent= new RelayCommand(DoReset);
            
            _eventHandler = new EventHandlerClass(this);
            NewItem = new Event();
            SelectedEvent = new Event();
            NextPage = new RelayCommand(DoNextPage);

            Types = new ObservableCollection<string>(){"Art", "Food", "Games", "Photography", "Dance", "Social Event"};
            //SortedEvents = new ObservableCollection<Event>();
        }

        //method for reset

        //public void DoReset()
        //{
        //    _eventHandler.ResetEvents();
        //}

        public void DoAdd()
        {
            _eventHandler.CreateEvent();
        }

        public void DoRemove()
        {
            _eventHandler.DeleteEvent(SelectedEvent);
        }

        public void DoNextPage()
        {
            _eventHandler.DoNextPage();
        }

        public void DoReset()
        {
            _eventHandler.ResetEvents();
        }

        //public ObservableCollection<Event> SearchEvent(string type)
        //{
        //    foreach (var item in _userSingleton.Events)
        //    {
        //        if (type == item.Type)
        //        {
        //            SortedEvents.Add(item);
        //        }
        //    }
        //    return SortedEvents;
        //}

        public void DoSorting()
        {
            foreach (var item in _userSingleton.Events)
            {
                if (item.Type == SelectedType)
                {
                    _userSingleton.Events.Add(item);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
