using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Inhaltsdialogfeld" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace AirCoonUWP.Game.Controller.SaveGame
{
    public sealed partial class DialogGameLoad : ContentDialog
    {
        public string Result { get; private set; }

        public DialogGameLoad()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private async void NewGame(object sender, RoutedEventArgs e)
        {
            DialogNewGame dialog = new DialogNewGame();
            this.Hide();
            await dialog.ShowAsync();
        }

        
        private void LoadGame(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
    }
}
