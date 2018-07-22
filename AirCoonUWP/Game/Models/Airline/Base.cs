using AirCoon.Game.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Models.Airline;
using AirCoon.Game.Models;

namespace AirCoon.Game.Models.Airline
{
    [Serializable]
    class Base
      : ISerializable, IAmTickable

    {
        protected Airport _Airport;
        public Airport Airport
        {
            get { return _Airport; }
        }

        public Base(Airport airport)
        {
            this._Airport = airport;
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
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
