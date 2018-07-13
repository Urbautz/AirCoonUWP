using System;
using System.Numerics;
using System.Collections.Generic;
using System.Collections.Specialized;
using Windows.ApplicationModel.Core;
using Windows.System;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Data;
using System.Linq;

using AirCoon.Game.Handler;
using AirCoonUWP.Game.Controller.AirlineDetails;
using AirCoonUWP.Game.Controller.Alliance;
using AirCoonUWP.Game.Controller.Bases;
using AirCoonUWP.Game.Controller.Finance;
using AirCoonUWP.Game.Controller.Fleet;
using AirCoonUWP.Game.Controller.FlightPlan;
using AirCoonUWP.Game.Controller.Marketing;
using AirCoonUWP.Game.Controller.SaveGame;
using AirCoonUWP.Game.Controller.Staff;
using AirCoonUWP.Game.Controller.World;
using AirCoonUWP.Game.Controller.Settings;


// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace AirCoonUWP
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page //, INotifyPropertyChanged
    {

        private Compositor _compositor;
        private SpriteVisual _hostSprite;
        private readonly IList<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("World", typeof(PageWorld)),
            ("AirlineDetails", typeof(PageAirlineDetails)),
            ("Alliance", typeof(PageAlliance)),

            ("Bases", typeof(PageBases)),
            ("Fleet", typeof(PageFleet)),
            ("FlightPlan", typeof(PageFlightPlan)),


            ("Finance", typeof(PageFinance)),
            ("Staff", typeof(PageStaff)),
            ("Marketing", typeof(PageMarketing))

        };
        private String _CurrentPageName = "Welcome";
        

        public MainPage()
        {

            InitializeComponent();
            Loaded += PageOnLoaded;
            this.SaveGameDialogAsync();
            SaveGamePublic.OuterFrame = this;
            this.NavViewNavigate("World", "Welcome");
        } // en constructor

        public async void SaveGameDialogAsync()
        {
            DialogGameLoad dialog = new DialogGameLoad();
            await dialog.ShowAsync();
        } // end SaveGameDialogAsync

        private static void PageOnLoaded(object sender, RoutedEventArgs e)
        {
            ApplyTransparencyToTitlebar();
        } // end PageOnLoaded

        private static void ApplyTransparencyToTitlebar()
        {
            var formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
        } // end AppTransparencyxToTitlebar

        private void ApplyAcrylicAccent(Panel panel)
        {
            _compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
            _hostSprite = _compositor.CreateSpriteVisual();
            _hostSprite.Size = new Vector2((float)panel.ActualWidth, (float)panel.ActualHeight);

            ElementCompositionPreview.SetElementChildVisual(panel, _hostSprite);
            _hostSprite.Brush = _compositor.CreateHostBackdropBrush();
        } // end AppArylAccent

        private void PageSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_hostSprite != null)
                _hostSprite.Size = e.NewSize.ToVector2();
        } // End Page_SieChanged
        
        private void NavViewLoaded(object sender, RoutedEventArgs e)
        {
            //ContentFrame.Navigated += On_Navigated;

            // NavView doesn't load any page by default: you need to specify it
            //NavView_Navigate("home");

            // Add keyboard accelerators for backwards navigation
            var goBack = new KeyboardAccelerator { Key = VirtualKey.GoBack };
            goBack.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(goBack);

            // ALT routes here
            var altLeft = new KeyboardAccelerator
            {
                Key = VirtualKey.Left,
                Modifiers = VirtualKeyModifiers.Menu
            };
            altLeft.Invoked += BackInvoked;
            this.KeyboardAccelerators.Add(altLeft);
        } // end NavViewLoaded

        private void NavViewBackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            OnBackRequested();
        }

        private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            OnBackRequested();
            args.Handled = true;
        }

        private bool OnBackRequested()
        {
            if (!ContentFrame.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed
            if (NavView.IsPaneOpen &&
                (NavView.DisplayMode == NavigationViewDisplayMode.Compact ||
                NavView.DisplayMode == NavigationViewDisplayMode.Minimal))
                return false;

            ContentFrame.GoBack();
            return true;
        }

        private void Navigate(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                ContentFrame.Navigate(typeof(PageSettings));
            }
            else
            {
                // Getting the Tag from Content (args.InvokedItem is the content of NavigationViewItem)
                String navItemTag = 
                    NavView.MenuItems
                      .OfType<NavigationViewItem>()
                      .First(i => args.InvokedItem.Equals(i.Content))
                      .Tag.ToString();
                NavViewNavigate(navItemTag, args.InvokedItem.ToString());
            }
        } // End Navigate

        public void NavViewNavigate(string navItemTag, string navItemName)
        {
            var item = _pages.First(p => p.Tag.Equals(navItemTag));
            ContentFrame.Navigate(item.Page);
            this._CurrentPageName = navItemName;
        }

        private void MoreClick(object sender, RoutedEventArgs e)
        {
            // TODO: Implement
        }


        public void SetFrameContent(Page p)
        {
            //OuterFrame.Content = p;
        } // End SetFrameContent

    } // End Class



} // End Namepsace
