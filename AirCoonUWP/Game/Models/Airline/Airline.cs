using AirCoon.Game.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirCoonUWP.Game.Models.Airline
{
    [Serializable]
    abstract class Airline
                : ISerializable, IAmTickable
    {

        private String _Code;
        public String Code
        {
            get { return _Code; }
        }

        private String _Name;
        public String Name
        {
            get { return _Name; }
        }

        public abstract void DailyTick(Tick CurrentTick);
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
        public abstract void MiniTick(Tick CurrentTick, int MiniTick);
        public abstract void QuarterlyTick(Tick CurrentTick);
        public abstract void Tick(Tick CurrentTick);
        public abstract void WeeklyTick(Tick CurrentTick);
        public abstract void YearlyTick(Tick CurrentTick);
    } // End Class
} // End Class
