﻿using System;
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
using AirCoon.Game.Handler;

// Die Elementvorlage "Inhaltsdialogfeld" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace AirCoonUWP.Game.Controller.SaveGame
{
    public sealed partial class DialogNewGame : ContentDialog
    {
        public DialogNewGame()
        {
            AirCoon.Game.Handler.SaveGame sg = new AirCoon.Game.Handler.SaveGame();
            List<Dictionary<string, string>> aps = sg.GetAvailibleHubNames();
            this.InitializeComponent();

            foreach (Dictionary<string, string> ap in aps )
            {
                ComboBoxItem b = new ComboBoxItem();
                b.Tag = ap["Iata"];
                b.Content = ap["Iata"] + " - " + ap["Name"];
                if (ap["Iata"] == "ATL")
                    b.IsSelected = true;
                Hub.Items.Add(b);
            } // End Foreach
        } // End Constructor

        public DialogNewGame(String name, String code, String Iata, String message)
        {
            AirCoon.Game.Handler.SaveGame sg = new AirCoon.Game.Handler.SaveGame();
            List<Dictionary<string, string>> aps = sg.GetAvailibleHubNames();
            this.InitializeComponent();
            Name.Text = name;
            Code.Text = code;
            Error.Text = message;
            foreach (Dictionary<string, string> ap in aps)
            {
                ComboBoxItem b = new ComboBoxItem();
                b.Tag = ap["Iata"];
                b.Content = ap["Iata"] + " - " + ap["Name"];
                if (ap["Iata"] == Iata)
                    b.IsSelected = true;
                Hub.Items.Add(b);
            } // End Foreach
        } // End Constructor

        /*Create Button*/
        private async void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            ComboBoxItem selected = (ComboBoxItem)Hub.SelectedValue;
            try {


               AirCoon.Game.Handler.SaveGame sg = 
                    new AirCoon.Game.Handler.SaveGame(selected.Tag.ToString(), 
                                                      Code.Text,
                                                      Name.Text
                                                      );

            } catch (SaveGameException e) {
                DialogNewGame dialog = new DialogNewGame(Name.Text, Code.Text, 
                                                    selected.Tag.ToString(),
                                                    e.Message
                                                    );
                this.Hide();
                await dialog.ShowAsync();
            }

            
        }

        /* Cancel Button */
        private async void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
            DialogGameLoad dialog = new DialogGameLoad();
            this.Hide();
            await dialog.ShowAsync();
        }
    } // end class
} // end Namespace
