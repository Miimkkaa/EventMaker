using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EventMaker.Common;
using EventMaker.Model;

namespace EventMaker.ViewModel
{
    class EventViewModel
    {
        //instance fields
        private int _id;
        private string _description;
        private string _name;
        private string _place;

        //props
        public DateTimeOffset Date { get; set; }
        public Event SelectedEvent { get; set; }
        public EventCatalogSingleton SingletonEvent { get; set; }
        public TimeSpan Time { get; set; }
        public RelayCommand CreateEvent { get; set; }
        public RelayCommand DeleteEvent{ get; set; }
        public RelayCommand SelectEvent { get; set; }
        
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Place
        {
            get { return _place; }
            set { _place = value; }
        }

        public EventViewModel(int id, string description, string name, string place)
        {
            _id = id;
            _description = description;
            _name = name;
            _place = place;
        }
        

    }
}
