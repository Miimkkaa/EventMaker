using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker.Model
{
    class Event
    {
        private string _name;
        private string _type;
        private string _description;
        private DateTime _dateTime;
        private string _location;

        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }

        public Event( string name, string type, string description, string datetime, string location)
        {
            _name = name;
            _type = type;
            _description = description;
            _datetime = datetime;
            _location = location;
        }

        public override string Tostring()
        {
            return $"{Name} {Type} {Description} {DateTime} {Location}";
        }
    }

}
