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
using AirCoonUWP.Game;
using AirCoon.Game.Handler;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace AirCoonUWP.Game.Controller.SaveGame
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class LoadScreen : Page
    {
        public LoadScreen()
        {
            this.InitializeComponent();
            List<String> SaveGameNames = AirCoon.Game.Handler.SaveGame.GetAvailibleSavegames();
            SaveGameList.ItemsSource = SaveGameNames;

        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            SaveGamePublic.OuterFrame.Content = new NewGame();
        }
    }
}
