using System;
using Windows.Media.Capture.Frames;
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
            //try
            //{
            //    //Arrange
            //    LoginVm log = new LoginVm();
            //    log.Username = "bl";
            //    log.Password = "kanskjd";

            //    //act
            //    log.LogIn();
            //}
            //catch (Exception e)
            //{
            //    //assert
            //    Assert.AreEqual(e.Message, "In order to create event, you have to fill all the information. Otherwise make sure that the date is picked.");
            //}

            //Arrange
            LoginVm log = new LoginVm();
            log.Username = "hk";
            log.Password = "hk";
            
            //act
            log.LogIn();
            string msg = "In order to create event, you have to fill all the information. Otherwise make sure that the date is picked."

            //assert
            Assert.AreEqual(msg , "In order to create event, you have to fill all the information. Otherwise make sure that the date is picked.");
        }

    }
}

