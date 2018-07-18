using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Handler;

namespace AirCoonUWP.Game.Models.Airline
{
    public class PlayerAirline
        : Airline
    {
        public override void DailyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public override void MiniTick(Tick CurrentTick, int MiniTick)
        {
            throw new NotImplementedException();
        }

        public override void QuarterlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public override void Tick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public override void WeeklyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public override void YearlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }
    }
}
