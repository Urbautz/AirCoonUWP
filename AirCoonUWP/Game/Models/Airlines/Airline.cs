using Aircoon.Game.Models.Airlines;
using Aircoon.Game.Models.Airlines.Assets;
using AirCoon.Game.Handler;
using AirCoon.Game.Models.Airlines.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirCoon.Game.Models.Airlines
{
    [Serializable]
    public abstract class Airline
                : ISerializable, IAmTickable
    {

        protected String _Code;
        public String Code
        {
            get { return _Code; }
        }

        protected String _Name;
        public String Name
        {
            get { return _Name; }
        }

        protected Dictionary<String, Hub> _Hubs = new Dictionary<String, Hub>();
        public Dictionary<String, Hub> Hubs { get { return _Hubs; } }

        protected List<Base> _Bases = new List<Base>();
        public List<Base> Bases { get { return _Bases; } }

        public void Construct(String code, String name, Airport hub_airport)
        {
            this._Code = code;
            this._Name = Name;
            Hub hub = new Hub(hub_airport);
            this._Hubs.Add(hub.Airport.Iata, hub);
            this._Bases.Add(hub); 
        }


        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);

        public abstract void DailyTick(Tick CurrentTick);
        public abstract void MiniTick(Tick CurrentTick, int MiniTick);
        public abstract void QuarterlyTick(Tick CurrentTick);
        public abstract void Tick(Tick CurrentTick);
        public abstract void WeeklyTick(Tick CurrentTick);
        public abstract void YearlyTick(Tick CurrentTick);
    } // End Class
} // End Class
