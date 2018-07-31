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

        private Alliance _Alliance_INT;
        protected Alliance _Alliance
        { get { return _Alliance_INT; }
            set
            {
                this._Alliance_INT = value;
                if(this._Alliance_INT != null)
                    value.Members.Add(this.Code, this);
            }
        }
        public Alliance Alliance { get { return _Alliance; } }
        


        
        public void CreateSubClass(String code, String name, List<Airport> hub_airports, Alliance alliance, Money startmoney = null)
        {
            this._Code = code;
            this._Name = Name;
            this._Alliance = alliance;
            foreach (Airport hub_airport in hub_airports)
            {
                Hub hub = new Hub(hub_airport, this);
                this._Hubs.Add(hub.Airport.Iata, hub);
                this._Bases.Add(hub);
            }
            
        }

        public void DeserializeSubClass(String code, String name,
            Dictionary<String, Hub> hubs,
            List<Base> bases,
            Alliance alliance,
            Money cash = null)
        {
            this._Code = code;
            this._Name = Name;
            this._Hubs = hubs;
            this._Bases = bases;
            this._Alliance = alliance;
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
