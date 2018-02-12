using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.Capture.Frames;
using Windows.UI.Popups;
using EventMaker.Convertor;
using EventMaker.Handler;
using EventMaker.Model;
using EventMaker.Persistancy;
using EventMaker.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventMakerTest
{
    [TestClass]
    public class TestEventHandlerClass
    {
        private EventViewModel evm;
        private EventHandlerClass ehc;
        private Event eventt;
        private EventCatalogSingleton ecs;
        private PersistancyService getItem;
        private DataTimeConvertor dateTimeCon;

        [TestInitialize]
        public void BeforeTest()
        {
            //Arrange
            evm = new EventViewModel();
            ehc = new EventHandlerClass(evm);
            eventt = new Event("Name", "Type", "Description", DateTime.Parse("2018.02.08 12:00"), "Location");
            ecs = new EventCatalogSingleton();
            getItem = new PersistancyService();
            getItem.EventsCatalog = new ObservableCollection<Event>();
            dateTimeCon = new DataTimeConvertor();
        }

        [TestMethod]
        public void CreateEventTest()
        {
            // Act
            ecs.Events.Add(eventt);
            double actual = ecs.Events.Count;
            double expected = 11;
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExceptionTest()
        {
            //act
            ehc.Evm.NewItem.Location = null;
            ehc.CreateEvent();
            double actual = ecs.Events.Count;
            double expected = 10;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CreateNullObjectTest()
        {
            //act
            ecs.Events.Remove(eventt);
            double actual = ecs.Events.Count;
            double expected = 10;

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}
