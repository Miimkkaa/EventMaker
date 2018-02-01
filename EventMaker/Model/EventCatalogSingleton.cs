using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using EventMaker.Persistancy;

namespace EventMaker.Model
{
    class EventCatalogSingleton
    {
        public readonly PersistancyService _getEvents;
        public EventCatalogSingleton _userSingleton;
        public ObservableCollection<Event> Events { get; set; }

        private static EventCatalogSingleton Instance { get; set; }

        public static Event _event;

        public EventCatalogSingleton()
        {
            _getEvents = new PersistancyService();

        }
        //private readonly GetEvents _getCustomer;
        public static EventCatalogSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new EventCatalogSingleton();
            }
            return Instance;
        }

        public void Add(Event newEvent)
        {
            _event = newEvent;
        }

        public async void LoadEventAsync()
        {
            try
            {
                Events = await _getEvents.LoadFromJson();
            }
            catch (Exception e)
            {
                string x = e.ToString();
                MessageDialog msd=new MessageDialog(x,"Error");
                msd.ShowAsync();
            }
        }

        public void Remove(Event eventToBeRemoved)
        {
            _event = eventToBeRemoved;
        }

        public string GetName()
        {
            return _event.Name;
        }

        public string GetType()
        {
            return _event.Type;
        }

        public string GetDescription()
        {
            return _event.Description;
        }

        public DateTime GetDateTime()
        {
            return _event.DateTime;
        }

        public string GetLocation()
        {
            return _event.Location;
        }

    }
}
