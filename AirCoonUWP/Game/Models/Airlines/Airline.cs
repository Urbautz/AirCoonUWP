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

        protected List<Hub> _Hub = new List<Hub>();
        public List<Hub> Hub { get { return _Hub; } }

        protected List<Base> _Base = new List<Base>();
        public List<Base> Base { get { return _Base; } }

        public void Construct(String code, String name, Airport hub_airport)
        {
            this._Code = code;
            this._Name = Name;
            Hub hub = new Hub(hub_airport);
            this._Hub.Add(hub);
            this._Base.Add(hub); 
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
