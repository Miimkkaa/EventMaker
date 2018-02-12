using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using EventMaker.Model;
using EventMaker.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace EventMaker.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventPage : Page
    {
        private EventViewModel evm;
        private EventCatalogSingleton _userSingleton;

        public EventPage()
        {
            this.InitializeComponent();
            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            evm = new EventViewModel();
            _userSingleton = EventCatalogSingleton.GetInstance();
        }

        private EventCatalogSingleton _singleton = EventCatalogSingleton.GetInstance();
     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CreateEventPage));
        }
        
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //sorting logic,it delets the items leaving only item with selected type acording to combobox

            //try
            //{
            //    var myCollection = _singleton.Events;
            //    var selectedType = sortBox.SelectionBoxItem.ToString();
            //    foreach (var getEvents in myCollection.ToList())
            //    {
            //        if (getEvents.Type != selectedType)
            //        {
            //            myCollection.Remove(getEvents);
            //        }
            //    }
            //}
            //catch (Exception exception)
            //{
            //    var dialig = new MessageDialog("You have to pick a type before you can use the combo Box");
            //    await dialig.ShowAsync();
            //}
        }
       
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {

            //so this is reset code

            //try
            //{
            //    var myCollection = _singleton.Events;
            //    var selectedType = sortBox.SelectionBoxItem.ToString();
            //    foreach (var getEvents in myCollection.ToList())
            //    {
            //        if (getEvents.Type != selectedType)
            //        {
            //            _singleton.Events.Add(getEvents);
            //        }
            //    }
            //}
            //catch (Exception exception)
            //{
            //    var dialig = new MessageDialog("You have to pick a type before you can use the combo Box");
            //    await dialig.ShowAsync();
            //}

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LogInPage));
        }
    }
}
