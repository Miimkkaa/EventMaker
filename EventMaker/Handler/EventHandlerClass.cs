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
    public class EventHandlerClass
    {
        //instance fields
        private readonly PersistancyService _getEvents;
        private readonly FrameNAvigationClass _frameNAvigation;
        private readonly EventCatalogSingleton _catalog;

        //props
        public EventViewModel Evm { get; }

        //constructor
        public EventHandlerClass(EventViewModel evm)
        {
            _getEvents = new PersistancyService();
            _frameNAvigation = new FrameNAvigationClass();
            _catalog = EventCatalogSingleton.GetInstance();
            Evm = evm;
        }
        
        //methods
        public async void CreateEvent()
        {
            try
            {
                if (Evm.NewItem.Name == null || Evm.NewItem.Type == null || Evm.NewItem.Description==null || Evm.NewItem.Location==null || Evm.Date1<=DateTime.Now)
                {
                    MessageDialog msg = new MessageDialog("In order to create event, you have to fill all the information. Otherwise make sure that the date is picked.", "Creating failed");
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
            try
            {
                if (fordeleting.Name != null)
                {
                    _catalog.Events.Remove(fordeleting);
                    await _getEvents.SavetoJson(_catalog.Events);
                }
                else
                {
                    MessageDialog msg = new MessageDialog("Object was not selected.", "Error");
                    msg.ShowAsync();
                }
            }
            catch
            {
                MessageDialog msg = new MessageDialog("Object was not selected.", "Error");
                msg.ShowAsync();
            }
        }
        
        public void DoNextPage()
        {
            if(Evm.SelectedEvent.Name != null)
            {
                _catalog.SetEvent(Evm.SelectedEvent);
                _frameNAvigation.ActivateFrameNavigation(typeof(UpdatePage), Evm.SelectedEvent);
            }
            else
            {
                MessageDialog msg = new MessageDialog("Object was not selected.", "Error");
                msg.ShowAsync();
            }
        }

        //method for reseting
        public void ResetEvents()
        {
            _catalog.LoadEventAsync();
        }
    }
}
