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
using Windows.UI.Xaml.Controls;
using EventMaker.Annotations;
using EventMaker.Common;
using EventMaker.Convertor;
using EventMaker.Handler;
using EventMaker.Model;
using EventMaker.View;

namespace EventMaker.ViewModel
{
    class EventViewModel : INotifyPropertyChanged
    {
        //instance fields
        private string _id;
        private string _description;
        private string _name;
        private string _place;
        public EventCatalogSingleton _userSingleton;
        private EventHandlerClass _eventHandler;

        //props
        public DateTimeOffset Date { get; set; }
        public TimeSpan Time { get; set; }

        public Event SelectedEvent { get; set; }
        public Event NewItem { get; set; }

        public EventCatalogSingleton SingletonEvent { get => _userSingleton;
            set { _userSingleton = value; OnPropertyChanged(nameof(_userSingleton)); }}

        public RelayCommand CreateEvent { get; set; }
        public RelayCommand DeleteEvent { get; set; }
        //public RelayCommand SelectEvent { get; set; }

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

        //ctor
        public EventViewModel()
        {
            _userSingleton = EventCatalogSingleton.GetInstance();
            //DateTime dt = System.DateTime.Now;
            //Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            //Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            DeleteEvent = new RelayCommand(DoRemove);
            CreateEvent = new RelayCommand(DoAdd);
            //SelectEvent = new RelayCommand(DoSelect);
            UpDateEvent = new RelayCommand(DoUpdate);

           _eventHandler = new EventHandlerClass();
            NewItem = new Event();
        }

        public void DoAdd()
        {
            DateTime date = DataTimeConvertor.DateTimeOffsetAndTimeSetToDateTime(Date, Time);
            NewItem = new Event(NewItem.Name, NewItem.Type, NewItem.Description, date, NewItem.Location);

            _eventHandler.CreateEvent(NewItem);
            //_userSingleton.Add(NewItem);
        }

        public void DoRemove()
        {
            //_userSingleton.Remove(SelectedEvent);
            //_eventHandler.SetSelectedEvent(SelectedEvent);
            _eventHandler.DeleteEvent(SelectedEvent);

        }

        //public void DoSelect()
        //{
        //    _eventHandler.SetSelectedEvent(SelectedEvent);
        //}

        public void DoUpdate()
        {
            _eventHandler.UpdateEvent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
