using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EventMaker.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogInPage : Page
    {
        private bool _loginStatus;
        public LogInPage()
        {
            this.InitializeComponent();
        }
        //Logic for login
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text == "Ben" && password.Password == "123")
            {
                _loginStatus = true;
                Frame.Navigate(typeof(EventPage));
            }
            else if (username.Text == "ooo" && password.Password == "ooo")
            {
                _loginStatus = true;
                Frame.Navigate(typeof(EventPage));
            }
            else if (username.Text == "Mimi" && password.Password == "789")
            {
                _loginStatus = true;
                Frame.Navigate(typeof(EventPage));
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
