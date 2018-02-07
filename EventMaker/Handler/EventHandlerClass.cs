using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
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
                if (Evm.NewItem.Name == null || Evm.NewItem.Type == null || Evm.NewItem.Description==null || Evm.NewItem.Location==null || Evm.Date1<=DateTime.Now)
                {
                    MessageDialog msg = new MessageDialog("In order to create event, you have to fill the information.");
                    msg.ShowAsync();
                }
                else
                {
                    DateTime date = DataTimeConvertor.DateTimeOffsetAndTimeSetToDateTime(Evm.Date1, Evm.Time1);

                    _catalog.Events.Add(new Event(Evm.NewItem.Name, Evm.NewItem.Type, Evm.NewItem.Description, date,
                        Evm.NewItem.Location));
                    await _getEvents.SavetoJson(_catalog.Events);
                    _frameNAvigation.ActivateFrameNavigation(typeof(EventPage));
                }
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

        public async void UpdateEvent(Event forUpdate)
        {
            foreach (var item in _catalog.Events)
            {
                if (item.Name == Evm.SelectedEvent.Name && item.Type == Evm.SelectedEvent.Type && item.Description == Evm.SelectedEvent.Description && item.DateTime == Evm.SelectedEvent.DateTime && item.Location == Evm.SelectedEvent.Location)
                {
                    _catalog.Events.Remove(Evm.SelectedEvent);
                    DateTime date = DataTimeConvertor.DateTimeOffsetAndTimeSetToDateTime(Evm.Date1, Evm.Time1);
                    _catalog.Events.Add(new Event(Evm.SelectedEvent.Name, Evm.SelectedEvent.Type, Evm.SelectedEvent.Description, date, Evm.SelectedEvent.Location));
                    await _getEvents.SavetoJson(_catalog.Events);
                    _frameNAvigation.ActivateFrameNavigation(typeof(EventPage));
                }
            }
        }


    }
}
