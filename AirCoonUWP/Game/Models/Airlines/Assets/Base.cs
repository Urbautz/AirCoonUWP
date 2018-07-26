using AirCoon.Game.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Models.Airlines;
using AirCoon.Game.Models;

namespace AirCoon.Game.Models.Airlines.Assets
{
    [Serializable]
    public class Base
      : ISerializable, IAmTickable

    {
        protected Airport _Airport;
        public Airport Airport
        {
            get { return _Airport; }
        }
        
        private bool _IsHub = false;
        public bool IsHub { get { return _IsHub;} }
        
        protected String _Airline;
        public Airline { get { return _Airline; } }

        public Base(Airport airport, Airline airline;)
        {
            this._Airport = airport;
            this._Airline = airline;
        }



        public Base() {
            _IsHub = true;
        }
        
        public Base(SerializationInfo info, StreamingContext context) {
            this._Airport = SaveGamePublic.SaveGame.Airports[info.GetString("Airport")];
            this._Airline = info.GetString("Airline");
            this._IsHub = info.GetBool("IsHub");
            
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Airport", this.Airport.Iata);
            info.AddValue("Airline", this._Airline);
            info.addValue("IsHub", this.IsHub);
        }

        public void DailyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void MiniTick(Tick CurrentTick, int MiniTick)
        {
            throw new NotImplementedException();
        }

        public void QuarterlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void Tick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void WeeklyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void YearlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }


    }
}
