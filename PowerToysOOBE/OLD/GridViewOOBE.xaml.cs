using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class GridViewOOBE : Page
    {
        ObservableCollection<Module> Modules;
        public GridViewOOBE()
        {
            this.InitializeComponent();

            Modules = new ObservableCollection<Module>();

            Modules.Add(new Module() { Name = "Color Picker", IsNew = false, NavIndex = 0, Icon = "\uEF3C", Image = "ms-appx:///Assets/Images/ColorPicker.png", FluentIcon = "ms-appx:///Assets/Images/Icons/ColorPicker.png" });
            Modules.Add(new Module() { Name = "FancyZones", IsNew = false, NavIndex = 1, Icon = "\uE737", Image = "ms-appx:///Assets/Images/FancyZones.png", FluentIcon = "ms-appx:///Assets/Images/Icons/FancyZones.png" });
            Modules.Add(new Module() { Name = "ImageResizer", IsNew = false, NavIndex = 2, Icon = "\uEB9F", Image = "ms-appx:///Assets/Images/ImageResizer.png", FluentIcon = "ms-appx:///Assets/Images/Icons/ImageResizer.png" });
            Modules.Add(new Module() { Name = "KBM", IsNew = false, NavIndex = 0, Icon = "\uE765", Image = "ms-appx:///Assets/Images/KBM.png", FluentIcon = "ms-appx:///Assets/Images/Icons/KBM.png" });
            Modules.Add(new Module() { Name = "Run", IsNew = false, NavIndex = 2, Icon = "\uE773", Image = "ms-appx:///Assets/Images/PowerLauncher.png", FluentIcon = "ms-appx:///Assets/Images/Icons/ColorPicker.png" });
            Modules.Add(new Module() { Name = "File explorer add-ons", IsNew = false, NavIndex = 1, Icon = "\uEC50", Image = "ms-appx:///Assets/Images/PowerPreview.png", FluentIcon = "ms-appx:///Assets/Images/Icons/FancyZones.png" });
            Modules.Add(new Module() { Name = "PowerRename", IsNew = false, NavIndex = 2, Icon = "\uE8AC", Image = "ms-appx:///Assets/Images/PowerRename.png", FluentIcon = "ms-appx:///Assets/Images/Icons/PowerRename.png" });
            Modules.Add(new Module() { Name = "Shortcut Guide", IsNew = false, NavIndex = 0, Icon = "\uEDA7", Image = "ms-appx:///Assets/Images/ShortcutGuide.png", FluentIcon = "ms-appx:///Assets/Images/Icons/ImageResizer.png" });
            Modules.Add(new Module() { Name = "Video Conference", IsNew = true, NavIndex = 1, Icon = "\uEC50", Image = "ms-appx:///Assets/Images/VideoConference.png", FluentIcon = "ms-appx:///Assets/Images/Icons/FancyZones.png" });
        }

        private void NextBtn_Click(object sender, RoutedEventArgs e)
        {
            FlipViewControl.SelectedIndex = FlipViewControl.SelectedIndex + 1;
        }

        private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        {
            FlipViewControl.SelectedIndex = FlipViewControl.SelectedIndex - 1;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Module SelectedModule = (Module)ModuleView.SelectedItem;
            FlipViewControl.SelectedIndex = SelectedModule.NavIndex;
        }
    }

}
