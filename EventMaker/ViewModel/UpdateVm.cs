using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Model;

namespace EventMaker.ViewModel
{
    class UpdateVm
    {
        private EventCatalogSingleton _usersinglCatalogSingleton;
        
        public string Name { get; set; }
        public string Type { get; set; }

        public UpdateVm()
        {
            _usersinglCatalogSingleton = EventCatalogSingleton.GetInstance();

            Name = _usersinglCatalogSingleton.GetName();
            Type = _usersinglCatalogSingleton.GetType();
        }
    }
}
