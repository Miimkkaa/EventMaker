using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Printing3D;
using Windows.UI.Popups;
using EventMaker.Annotations;
using EventMaker.Common;
using EventMaker.Convertor;
using EventMaker.Model;
using EventMaker.Persistancy;
using EventMaker.View;

namespace EventMaker.ViewModel
{
    public class UpdateVm : INotifyPropertyChanged
    {
        //instance fields
        private string _type;
        private string _description;
        private string _name;
        private string _location;
        private DateTime _dateTime;
        private DateTimeOffset _date;
        private TimeSpan _time;
        private ObservableCollection<Event> _events;
        private EventCatalogSingleton _usersinglCatalogSingleton;
        private readonly PersistancyService _getEvent;
        private FrameNAvigationClass _frameNAvigation;

        //props
        public RelayCommand Update { get; set; }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
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

        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public ObservableCollection<Event> Events
        {
            get => _events;
            set
            {
                _events = value;
                OnPropertyChanged(nameof(Events));
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

        public DateTime DateTime1
        {
            get => _dateTime;
            set
            {
                _dateTime = value;
                OnPropertyChanged(nameof(DateTime));
            }
        }

        public UpdateVm()
        {
            _usersinglCatalogSingleton = EventCatalogSingleton.GetInstance();
            _getEvent = new PersistancyService();
            _frameNAvigation = new FrameNAvigationClass();

            Name = _usersinglCatalogSingleton.GetName();
            Type = _usersinglCatalogSingleton.GetType();
            Description = _usersinglCatalogSingleton.GetDescription();
            Location = _usersinglCatalogSingleton.GetLocation();
            DateTime1 = _usersinglCatalogSingleton.GetDateTime();

            Update = new RelayCommand(UpDateEvent);

            DateTime dt = System.DateTime.Now;
            _date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0, new TimeSpan());
            _time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
        }

        
        //DateTime date = DataTimeConvertor.DateTimeOffsetAndTimeSetToDateTime(Date1, Time1);

        public async void UpDateEvent()
        {

            foreach (var item in _usersinglCatalogSingleton.Events)
            {
                if (item.Name == _usersinglCatalogSingleton.GetName())
                {
                    item.Name = Name;
                    item.Type = Type;
                    item.Description = Description;
                    item.Location = Location;
                    item.DateTime = DateTime1;

                    if (Name != null && Type != null && Description != null && Location != null && Date1 <= DateTime.Now)
                    {
                        await _getEvent.SavetoJson(_usersinglCatalogSingleton.Events);
                        _frameNAvigation.ActivateFrameNavigation(typeof(EventPage));
                    }
                    else
                    {
                        MessageDialog msg = new MessageDialog("In order to update event, you have to fill all the information. And make sure that the date is picked.", "Updating failed");
                        msg.ShowAsync();
                    }
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
