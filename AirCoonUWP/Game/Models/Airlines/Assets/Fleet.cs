using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Aircoon.Game.Models.Airlines.Assets;
using AirCoon.Game.Handler;
using AirCoon.Game.Models;
using AirCoon.Game.Models.Aircraft;

namespace AirCoon.Game.Models.Airlines.Assets
{
    [Serializable]
    public class Fleet
                : ISerializable, IAmTickable
    {

        private String _Name;
        public String Name { get { return _Name; }  }

        private String _Hub;
        public Hub Hub { get { return this.Airline.Hubs[_Hub]; }  }

        private String _Airline;
        public Airline Airline { get { return SaveGamePublic.SaveGame.AirlinesAll[_Airline]; }  }
        
        public Dictionary<String, Plane> Planes;

        public Fleet(Airline airline, Hub hub, String name = null)
        {
            if(name == null) name = airline.Code + " - " + Hub.Airport.Iata;   
            this._Name = name;
            this._Hub = hub.Airport.Iata;
            this._Airline = airline.Code;
            this.Planes = new Dictionary<String, Plane>();
        }

        public Fleet(SerializationInfo info, StreamingContext context)
        {
            this._Name = info.GetString("Name");
            this._Airline = info.GetString("Airline");
            this._Hub = info.GetString("Hub");
            Planes = (Dictionary<String, Plane>) info.GetValue("Planes", typeof(Dictionary<String, Plane>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this._Name);
            info.AddValue("Airline", this._Airline);
            info.AddValue("Hub", this._Hub);
            info.AddValue("Planes", this.Planes);
        }

        void IAmTickable.DailyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        void IAmTickable.MiniTick(Tick CurrentTick, int MiniTick)
        {
            throw new NotImplementedException();
        }

        void IAmTickable.QuarterlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        void IAmTickable.Tick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        void IAmTickable.WeeklyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        void IAmTickable.YearlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }
    }
}
