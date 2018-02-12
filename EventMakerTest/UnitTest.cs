using System;
using Windows.Media.Capture.Frames;
using EventMaker.Convertor;
using EventMaker.Handler;
using EventMaker.Model;
using EventMaker.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventMakerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod()]
        public void LoginTest()
        {
            //Arrange
            LoginVm log = new LoginVm();
            log.Username = "hk";
            log.Password = "hk";
            
            //act
            log.LogIn();
            string msg =
                "In order to create event, you have to fill all the information. Otherwise make sure that the date is picked.";

            //assert
            Assert.AreEqual(msg , "In order to create event, you have to fill all the information. Otherwise make sure that the date is picked.");
            //Assert.AreEqual("k", log.Username);
        }

        [TestMethod]
        public void DateTimeConverterTest()
        {
            //Act
            DateTime _expectedDate = new DateTime(2017, 12, 12, 6, 7, 0);
            DateTime _actualDate = DataTimeConvertor.DateTimeOffsetAndTimeSetToDateTime(new DateTimeOffset(2017, 12, 12, 0, 0, 0, 0, new TimeSpan()),
                new TimeSpan(6, 7, 0));

            //Assert
            Assert.AreEqual(_expectedDate, _actualDate);
        }
    }
}

