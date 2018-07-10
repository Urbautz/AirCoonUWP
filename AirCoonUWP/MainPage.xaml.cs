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

        public MainPage()
        {

            InitializeComponent();
            Loaded += PageOnLoaded;
            this.SaveGameDialogAsync();

            SaveGamePublic.OuterFrame = this;
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

        public void SetFrameContent(Page p)
        {
            //OuterFrame.Content = p;
        }

    }



}
