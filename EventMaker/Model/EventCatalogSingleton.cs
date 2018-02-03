using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using EventMaker.Common;
using EventMaker.NetLibrary;
using EventMaker.Persistancy;
using EventMaker.View;

namespace EventMaker.Model
{
    class EventCatalogSingleton
    {
        //instance fields
        private readonly PersistancyService _getEvents;
        private static Event _event;
        private FrameNAvigationClass _frameNAvigation;

        //props
        public ObservableCollection<Event> Events { get; set; }
        private static EventCatalogSingleton Instance { get; set; }


        public EventCatalogSingleton()
        {
            _getEvents = new PersistancyService();
            Events = new ObservableCollection<Event>()
            {
                new Event("Bullshit","haha","sadas",DateTime.Now, "Lala"),
                new Event("name", "type", "des", DateTime.Now, "lo")
            };
            LoadEventAsync();
            _frameNAvigation = new FrameNAvigationClass();
        }
        
        public static EventCatalogSingleton GetInstance()
        {
            if (Instance == null)
            {
                Instance = new EventCatalogSingleton();
            }
            return Instance;
        }

        //Exeption Handling
        public async void LoadEventAsync()
        {
            try
            {
                try
                {
                    await _getEvents.LoadFromJson();
                }
                catch 
                {
                    if (_getEvents.EventsCatalog == null)
                    {
                        await _getEvents.SavetoJson(Events);
                    }
                }
            }
            catch (Exception e)
            {
                string x = e.ToString();
                MessageDialog msd=new MessageDialog(x,"Error");
                msd.ShowAsync();
            }
        }

        //Methods
        public async void Remove(Event eventToBeRemoved)
        {
            _event = eventToBeRemoved;
            Events.Remove(eventToBeRemoved);
            await _getEvents.SavetoJson(Events);
        }

        public async void Add(Event newEvent)
        {
            _event = newEvent;
            Events.Add(newEvent);
            //await _getEvents.SavetoJson(Events);
            _frameNAvigation.ActivateFrameNavigation(typeof(EventPage));
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
