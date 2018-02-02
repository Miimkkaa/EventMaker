using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker.Model
{
    class Event
    {
        //instance fields
        private string _name;
        private string _type;
        private string _description;
        private DateTime _dateTime;
        private string _location;
        //properties
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }
        //Event constructor
        public Event( string name, string type, string description, DateTime datetime, string location)
        {
            _name = name;
            _type = type;
            _description = description;
            _dateTime = datetime;
            _location = location;
        }
        //Converting Tostring output information
        public override string ToString()
        {
            return $"{Name} {Type} {Description} {DateTime} {Location}";
        }
    }

}
