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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AirCoon.Game.Handler
{

    interface IAmTickable {
        void MiniTick(Tick CurrentTick, int MiniTick);
        void Tick(Tick CurrentTick);
        void DailyTick(Tick CurrentTick);
        void WeeklyTick(Tick CurrentTick);
        void QuarterlyTick(Tick CurrentTick);
        void YearlyTick(Tick CurrentTick);
    } // End Interface


    public class  TickHandler : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler Handler = PropertyChanged;
            if (Handler != null)
            {
                Handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private int _TickSpeed = 2;
        public int TickSpeed
        {
            get { return _TickSpeed; }
            set
            {
                _TickSpeed = value;
                this.TickSpeedString = value.ToString();
                //this.OnPropertyChanged("TickSpeed");
            }

        }
        
        private String _TickSpeedString = "Speed: 2";
        public String TickSpeedString
        {
            get { return _TickSpeedString; }
            set
            {
                    _TickSpeedString = "Speed: " + value;
                    this.OnPropertyChanged("TickSpeedString");

            }
        }

        public void IncreaseSpeed()
        {
            if (this._TickSpeed < 4)
            {
                this.TickSpeed = this.TickSpeed + 1;
                
            }
        }
        public void DecreaseSpeed()
        {
            if (this._TickSpeed > 1)
            {
                this.TickSpeed = this.TickSpeed - 1;
            }
        }

        private bool _DoTick = false;
        public bool DoTick = false;

        public TickHandler() { }




    }

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
