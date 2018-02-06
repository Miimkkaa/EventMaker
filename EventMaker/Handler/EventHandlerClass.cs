using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using EventMaker.Common;
using EventMaker.Convertor;
using EventMaker.Model;
using EventMaker.Persistancy;
using EventMaker.View;
using EventMaker.ViewModel;

namespace EventMaker.Handler
{
    class EventHandlerClass
    {
        //instance fields
        private readonly PersistancyService _getEvents;
        private FrameNAvigationClass _frameNAvigation;
        private EventCatalogSingleton _catalog;
        private EventViewModel Evm { get; }

        //props

        public EventHandlerClass(EventViewModel evm)
        {
            _getEvents = new PersistancyService();
            _frameNAvigation = new FrameNAvigationClass();
            _catalog = EventCatalogSingleton.GetInstance();
            Evm = evm;
        }
        
        public async void CreateEvent()
        {
           try
           {
               DateTime date = DataTimeConvertor.DateTimeOffsetAndTimeSetToDateTime(Evm.Date1, Evm.Time1);

                _catalog.Events.Add(new Event(Evm.NewItem.Name, Evm.NewItem.Type, Evm.NewItem.Description, date, Evm.NewItem.Location));
               await _getEvents.SavetoJson(_catalog.Events);
               _frameNAvigation.ActivateFrameNavigation(typeof(EventPage));
            }
           catch (Exception e)
           {
               string ex = e.ToString();
               MessageDialog msg = new MessageDialog(ex, "Error");
               msg.ShowAsync();
           }
        }

        public async void DeleteEvent(Event fordeleting)
        {
            _catalog.Events.Remove(fordeleting);
            await _getEvents.SavetoJson(_catalog.Events);
        }

        public async void UpdateEvent()
        {
            //await _getEvents.SavetoJson(_catalog.Events);
        }

    }
}
