using System;
using System.Numerics;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;
using AirCoon.Game.Handler;
using AirCoonUWP.Game.Controller.SaveGame;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace AirCoonUWP
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private Compositor _compositor;
        private SpriteVisual _hostSprite;
        private readonly IList<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("World", typeof(OverView)),
            ("AirlineDetails", typeof(AirlineDetails)),
            ("Alliance", typeof(Alliance)),
            
            ("Bases", typeof(Bases)),
            ("Fleet", typeof(Fleet)),
            ("FlightPlan", typeof(FlightPlan)),

            
            ("Finance", typeof(Finance)),
            ("Personel", typeof(Personel)),
            ("Marketing", typeof(Marketing))
            
        };
        

        public MainPage()
        {

            InitializeComponent();
            Loaded += PageOnLoaded;
            this.SaveGameDialogAsync();
            SaveGamePublic.OuterFrame = this;
            this.NavViewNavigate("World");
        }

        public async void SaveGameDialogAsync()
        {
            DialogGameLoad dialog = new DialogGameLoad();
            await dialog.ShowAsync();
        }

        private static void PageOnLoaded(object sender, RoutedEventArgs e)
        {
            ApplyTransparencyToTitlebar();
        }

        private static void ApplyTransparencyToTitlebar()
        {
            var formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
        }

        private void ApplyAcrylicAccent(Panel panel)
        {
            _compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;
            _hostSprite = _compositor.CreateSpriteVisual();
            _hostSprite.Size = new Vector2((float)panel.ActualWidth, (float)panel.ActualHeight);

            ElementCompositionPreview.SetElementChildVisual(panel, _hostSprite);
            _hostSprite.Brush = _compositor.CreateHostBackdropBrush();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (_hostSprite != null)
                _hostSprite.Size = e.NewSize.ToVector2();
        }
        
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

        private void Navigate(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                ContentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                // Getting the Tag from Content (args.InvokedItem is the content of NavigationViewItem)
                String navItemTag = NavView.MenuItems
                      .OfType<NavigationViewItem>()
                      .First(i => args.InvokedItem.Equals(i.Content))
                      .Tag.ToString();
                NavViewNavigate(navItemTag);
            }
        } // End Navigate

        public void NavViewNavigate(string navItemTag)
        {
            var item = _pages.First(p => p.Tag.Equals(navItemTag));
            ContentFrame.Navigate(item.Page);
        }


        public void SetFrameContent(Page p)
        {
            //OuterFrame.Content = p;
        } // End SetFrameContent

    } // End Class



} // End Namepsace
