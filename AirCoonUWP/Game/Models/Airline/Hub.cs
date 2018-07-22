using AirCoon.Game.Handler;
using AirCoon.Game.Models;
using AirCoon.Game.Models.Airline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aircoon.Game.Models.Airline
{
    [Serializable]
    class Hub
      : Base, ISerializable, IAmTickable
    {

        public Hub(Airport airport)
        {
            _Airport = airport;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public new void DailyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }



        public new void MiniTick(Tick CurrentTick, int MiniTick)
        {
            throw new NotImplementedException();
        }

        public new void QuarterlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public new void Tick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public new void WeeklyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public new void YearlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }
    }
}
