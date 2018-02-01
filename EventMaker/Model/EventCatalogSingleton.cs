using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker.Model
{
    class EventCatalogSingleton
    {

        //public EventCatalogSingleton 
        public ObservableCollection<Event> Events { get; set; }




        public void Add(Event newEvent)
        {
            
        }

        public void LoadEventAsync()
        {
            
        }

        public void Remove(Event eventToBeRemoved)
        {
            
        }
    }
}
