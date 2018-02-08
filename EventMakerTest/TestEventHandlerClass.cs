using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Convertor;
using EventMaker.Handler;
using EventMaker.Model;
using EventMaker.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventMakerTest
{
    [TestClass]
    class TestEventHandlerClass
    {
        private EventViewModel evm;
        private EventHandlerClass ehc;
        private Event eventt;
        private EventCatalogSingleton ecs;



        [TestInitialize]
        public void BeforeTest()
        {
            evm = new EventViewModel();
            ehc = new EventHandlerClass(evm);
            eventt = new Event("Name", "Type", "Description", DateTime.Parse("2018.02.08 12:00"), "Location");
            ecs = new EventCatalogSingleton();

        }

        [TestMethod()]
        public void CreateEventTest()
        {
            // Arrange

            // Act
            ecs.Events.Add(eventt);

            // Assert
            Assert.AreEqual("Type", eventt.Type);
        }


    }
}
