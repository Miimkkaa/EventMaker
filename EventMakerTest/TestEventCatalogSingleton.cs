using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Model;
using EventMaker.Persistancy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventMakerTest
{
    [TestClass]
    public class TestEventCatalogSingleton
    {
        [TestMethod]
        public void LoadingMethodTEst()
        {
            //arrange
            EventCatalogSingleton _ecs = new EventCatalogSingleton();
            PersistancyService _getItem = new PersistancyService();
            _getItem.EventsCatalog = new ObservableCollection<Event>();

            //act
            double expected = 12;
            double actual = _getItem.EventsCatalog.Count;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
