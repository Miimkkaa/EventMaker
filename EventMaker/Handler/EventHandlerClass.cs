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
        private static Event NewItem;
        private FrameNAvigationClass _frameNAvigation;
        private EventCatalogSingleton _catalog;
        private EventViewModel _evm;

        //props

        public EventHandlerClass()
        {
            _getEvents = new PersistancyService();
            NewItem = new Event();
            _frameNAvigation = new FrameNAvigationClass();
            _catalog = EventCatalogSingleton.GetInstance();
            
            //_evm = new EventViewModel();
        }

        //public void CommandInvokedHandler()
        //{
            
        //} 

       public async void CreateEvent(Event forAdding)
       {
            //here i put your stuff to not forget the way you did this:
           //DateTime date = DataTimeConvertor.DateTimeOffsetAndTimeSetToDateTime(_evm.Date, _evm.Time);
            //

            _catalog.Events.Add(forAdding);
            await _getEvents.SavetoJson(_catalog.Events);
            _frameNAvigation.ActivateFrameNavigation(typeof(EventPage));
        }

        public async void DeleteEvent(Event fordeleting)
        {
            _catalog.Events.Remove(fordeleting);
            //await _getEvents.SavetoJson(_catalog.Events);
        }

        public async void UpdateEvent()
        {
            //await _getEvents.SavetoJson(_catalog.Events);
        }

        //public void SetSelectedEvent(Event ev)
        //{
            //_evm = new EventViewModel();
            //ev = _evm.SelectedEvent;
        //}

    }
}
