using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Handler;
using AirCoon.Game.Models;
using AirCoon.Game.Models.Aircraft;

namespace AirCoonUWP.Game.Models.Airline
{
    [Serializable]
    public class Fleet
                : ISerializable, IAmTickable
    {

        private String _Name;
        public String Name
        {
            get { return _Name; }
        }

        private Airline _Airline;
        public Airline Airline
        {
            get { return _Airline; }
        }


        public Fleet()
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
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
