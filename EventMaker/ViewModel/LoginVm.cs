using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using EventMaker.Common;
using EventMaker.View;

namespace EventMaker.ViewModel
{
    public class LoginVm
    {
        //instance fields
        private bool _loginStatus;
        private FrameNAvigationClass _frameNAvigation;

        //props
        public RelayCommand DoLogIn { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginVm()
        {
            DoLogIn = new RelayCommand(LogIn);
            _frameNAvigation = new FrameNAvigationClass();
        }

        public async void LogIn()
        {
            if (Username == "Ben" && Password == "123")
            {
                _loginStatus = true;
                _frameNAvigation.ActivateFrameNavigation(typeof(EventPage));
            }
            else if (Username == "ooo" && Password == "ooo")
            {
                _loginStatus = true;
                _frameNAvigation.ActivateFrameNavigation(typeof(EventPage));
            }
            else if (Username == "Mimi" && Password == "789")
            {
                _loginStatus = true;
                _frameNAvigation.ActivateFrameNavigation(typeof(EventPage));
            }
            else
            {
                _loginStatus = false;
                MessageDialog msg = new MessageDialog("Wrong username or password,please try again.");
                await msg.ShowAsync();
            }
        }
    }
}
