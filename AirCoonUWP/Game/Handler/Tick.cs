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
using AirCoon.Game.Handler;


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
    
      readonly Int64 TickCount;
      
      public Int32 HourOfDay {
         get { return Convert.ToInt32(this.TickCount % HoursPerDay);  }
      }
      
      public Int64 TickDay {
        get { return Convert.ToInt64(Math.Floor((Decimal) this.TickCount / HoursPerDay) + 1 );  }
      }

      public Int32 DayOfWeek {
        get { return Convert.ToInt32(TickDay % DaysPerWeek) + 1; }
      }

      public Int32 WeekOfYear {
        get { return Convert.ToInt32(TickDay % WeeksPerYear) + 1; }
      }
      
      public Int32 QuarterOfYear {
        get { return Convert.ToInt32(TickDay % DaysPerQuarter) + 1; }
      }
    
      public Tick(Tick lastTick, Int64 ToFuture = 1) {
        this.TickCount = lastTick.TickCount + ToFuture;
        if(SaveGamePublic.SaveGame.Ticks.ContainsKey(this.TickCount)) {
           TickException e = new TickException("Tick already exisits");
           e.Data.Add("Tick", SaveGamePublic.SaveGame.Ticks[this.TickCount]);
           }
        else
            SaveGamePublic.SaveGame.Ticks.Add(this.TickCount, this);
      } // end Constructor

    } // end Class
    
    
    public class TickException : Exception
    {
        public TickException(string message)
            : base(message)
        {
        }
    } //end Exception

} // end Namespace
