using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Model;

namespace EventMaker.NetLibrary
{
    class ObesrvableCollectionClass
    {
        public  ObservableCollection<Event> Events { get; set; }


        public ObesrvableCollectionClass()
        {
                Events=new ObservableCollection<Event>()
                {
                    new Event("Bullshit","haha","sadas",DateTime.Now, "Lala")

                };
        }


    }
}
