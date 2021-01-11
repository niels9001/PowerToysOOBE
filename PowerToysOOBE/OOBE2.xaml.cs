﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PowerToysOOBE
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OOBE2 : Page
    {
        public OOBE2()
        {
            this.InitializeComponent();
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            FlipViewControl.SelectedIndex = FlipViewControl.SelectedIndex + 1;
        }

        private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        {
            FlipViewControl.SelectedIndex = FlipViewControl.SelectedIndex - 1;
        }

        private void FlipViewControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NextBtn.IsEnabled = true;
            PreviousBtn.IsEnabled = true;
            if (FlipViewControl.SelectedIndex == 0)
            {
                PreviousBtn.IsEnabled = false;
            }
            
            if (FlipViewControl.SelectedIndex == 3)
            {
                NextBtn.IsEnabled = false;
            }
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FlipViewControl.SelectionChanged += FlipViewControl_SelectionChanged;

            await OpenPageAsWindowAsync(typeof(WhatsNew));
        }




        private async Task<bool> OpenPageAsWindowAsync(Type t)
        {
            CoreApplicationView view = CoreApplication.CreateNewView();
            int id = 0;

            await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var frame = new Frame();
                frame.Navigate(t, null);
                Window.Current.Content = frame;
                Window.Current.Activate();
                view.TitleBar.ExtendViewIntoTitleBar = true;

                ApplicationView appView = ApplicationView.GetForCurrentView();
                appView.TitleBar.BackgroundColor = Colors.Transparent;
                appView.TitleBar.ButtonBackgroundColor = Colors.Transparent;
                appView.TitleBar.ButtonForegroundColor = Colors.Black;
                //appView.TitleBar.ButtonForegroundColor = ((SolidColorBrush)Application.Current.Resources["PrimaryTextColor"]).Color;
                appView.TitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
                appView.TitleBar.InactiveBackgroundColor = Colors.Transparent;
                appView.TitleBar.ForegroundColor = Colors.Black;
                id = ApplicationView.GetForCurrentView().Id;
            });

            return await ApplicationViewSwitcher.TryShowAsStandaloneAsync(id);
        }

    }
}
