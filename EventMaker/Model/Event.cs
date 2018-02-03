using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMaker.Model
{
    public class Event
    {
        //instance fields
        private string _name;
        private string _type;
        private string _description;
        private DateTime _dateTime;
        private string _location;

        //properties
        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
        public string Description { get => _description; set => _description = value; }
        public DateTime DateTime { get => _dateTime; set => _dateTime = value; }
        public string Location { get => _location; set => _location = value; }

        //Event constructor
        public Event( string name, string type, string description, DateTime datetime, string location)
        {
            Name = name;
            Type = type;
            Description = description;
            DateTime = datetime;
            Location = location;
        }

        public Event()
        {
            
        }

        //Converting Tostring output information
        public override string ToString()
        {
            return $"{Name} {Type} {Description} {DateTime} {Location}";
        }
    }

}
