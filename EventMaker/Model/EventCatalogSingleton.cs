using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Pwm;
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
                    new Event("Eminem","Concert","For people of all ages who want to have a great time and experience unforgettable moment with their friends and enjoy Eminem’s music.", DateTime.Parse("2018.07.04 12:00"), "Roskilde, Denmark (Roskilde festival)"),
                    new Event("Made in Space", "Social event", "Do you want to see the planets from a different point of view and meet people with the same interest in the immense Space as you? Come at the Planetarium and Copenhagen and learn more about what surrounds us.", DateTime.Parse("2018.09.08 14:00"), "Copenhagen, Denmark (Planetarium),"),
                    new Event("Cooking with Gordon Ramsay", "Food", "This event is for all the people who want to meet one of the best chef’s in the world and learn a few cooking tricks from the master himself.", DateTime.Parse("2018.03.25 13:00"), "Copenhagen, Denmark (Gordon Ramsay’s restaurant)"),
                    new Event("Chocolate festival", "Social event", "For all chocolate lovers out there who want to spend a day full of deliciousness without regrets in the company of the finest chocolate from around the world.", DateTime.Parse("2018.08.08 09:00"), "Copenhagen, Denmark (Tivoli gardens)"),
                    new Event("The hidden place exhibition", "Art", "If you are captivated by modern art and breathtaking pieces, this is the event for you. Join us and support Aline Verganos for her first solo exhibition.”", DateTime.Parse("2018.02.24 14:00"), "Copenhagen, Denmark (Limited works)"),
                    new Event("Workshop", "Social event", "Do you want to meet new people and learn some interesting crafts? Meet us at the Culture center in Roskilde and have fun.", DateTime.Parse("2018.02.17 15:00"), "Roskilde, Denmark (Culture center)"),
                    new Event("Paint bar", "Social event", "If you are both alcohol and art lover, you will love everything about this event. Come have a drink while you are showing us your hidden talents. Looking forward to meet you there.", DateTime.Parse("2018.03.09 21:00"), "Copenhagen, Denmark (Café Vivaldi)"),
                    new Event("Salsa dance class", "Dance", "If you want to learn to move like a goddess and feel the heat of Cuba going through your veins, this is the dance class for you.", DateTime.Parse("2018.03.11 17:00"), "Copenhagen, Denmark (Salsa club)"),
                    new Event("Picture this", "Photography", "If you are interested in photography or you want to enjoy other people’s perspective of the world in pictures, you can visit us at KADK and get inspired for free.", DateTime.Parse("2018.05.04 18:00"), "Copenhagen, Denmark (KADK)"),
                    new Event("Gaming", "Games", "For all the gamers out there who want to share strategies and tricks for their favorite games, this is the place where you can meet your fellow gamer friends.", DateTime.Parse("2018.03.23 10:00"), "Roskilde, Denmark (Culture center)"),
            };
            LoadEventAsync();
            _frameNAvigation = new FrameNAvigationClass();

                    
        }
        public ObservableCollection<Event> GetEventList()
        {
            return Events;

        }

        public void ResetEventList()
        {
            GetEventList();

        }

        public void SetEventList(ObservableCollection<Event> eventList)
        {
            Events = eventList;

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
                Events = await _getEvents.LoadFromJson();
            }
            catch (Exception e)
            {
                await _getEvents.SavetoJson(Events);

                string x = e.ToString();
                MessageDialog msd = new MessageDialog(x, "Error");
                msd.ShowAsync();
            }
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
            return _event.DateTime.Date + _event.DateTime.TimeOfDay;
        }

        public string GetLocation()
        {
            return _event.Location;
        }

    }
}
