using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace EventMaker.Common
{
    class FrameNAvigationClass
    {
        //for passing only type
        public void ActivateFrameNavigation(Type type)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(type);
            Window.Current.Content = frame;
            Window.Current.Activate();
        }

        //for passing type and the object
        public void ActivateFrameNavigation(Type type, Object currentEvent)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(type, currentEvent);
            Window.Current.Content = frame;
            Window.Current.Activate();
        }
    }
}
