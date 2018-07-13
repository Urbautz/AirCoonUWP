using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;
using AirCoon.Game.Models;
using AirCoon.Game.Models.Geo;


namespace AirCoon.Game.Handler
{

    public class Tick {
    
      readonly static int HoursPerDay     = 24;
      readonly static int DaysPerWeek     = 7;
      readonly static int WeeksPerYear    = 52;
      readonly static int QuartersPerYear = 4;
      
      readonly static int DaysPerYear     = DaysPerWeek * WeeksPerYear;
      readonly static int WeeksPerQuarter = WeeksPerYear / QuartersPerYear;
      readonly static int DaysPerQuarter  = DaysPerYear / QuartersPerYear;
    
      readonly Int64 Tick;
      
      public Int HourOfDay {
         get { return Convert.ToInt32(Tick % HoursPerDay);  }
      }
      
      public Int64 TickDay {
        get { return Convert.ToInt64(Math.Floor(Tick / HoursPerDay) + 1 );  }
      }

      public Int DayOfWeek {
        get { return Convert.ToInt32(TickDay % DaysPerWeek) + 1; }
      }

      public Int WeekOfYear {
        get { return Convert.ToInt32(TickDay % WeeksPerYear) + 1; }
      }
      
      public Int QuarterOfYear {
        get { return Convert.ToInt32(TickDay % DaysPerQuarter) + 1; }
      }
    
      public Tick(Tick lastTick, Int64 ToFuture = 1) {
        this.Tick = lastTick + TuFuture;
        if(PublicSaveGame.SG.Ticks.ContainsKey(this.Tick)) {
           TickException e = new TickException("Tick already exisits");
           e.Data.Add("Tick", PublicSaveGame.SG.Ticks[this.Tick]);
           }
        else 
          PublicSaveGame.SG.Ticks.Add(this.Tick, this);
      } // end Constructor

    } // end Class
    
    
    public class SaveGameException : Exception
    {
        public SaveGameException(string message)
            : base(message)
        {
        }
    } //end Exception

} // end Namespace
