using AirCoon.Game.Handler;
using AirCoon.Game.Models;
using AirCoon.Game.Models.Airlines;
using AirCoon.Game.Models.Airlines.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Aircoon.Game.Models.Airlines.Assets
{
    [Serializable]
    public class Hub
      : Base, ISerializable, IAmTickable
    {

        public Hub(Airport airport, Airline airline)
        {
            base._Airport = airport;
            base._Airline = airline.Iata;
            base._IsHub = true;
        }
        
        public Hub (SerializationInfo info, StreamingContext context) 
        {
            base._Airport = SaveGamePublic.SaveGame.Airports[info.GetString("Airport")];
            base._Airline = info.GetString("Airline");
            base._IsHub = true;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Airport", base.Airport.Iata);
            info.AddValue("Airline", base._Airline);
            info.addValue("IsHub", base.IsHub);
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
