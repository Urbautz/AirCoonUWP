
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Handler;
using AirCoon.Game.Models.Aircraft;
using AirCoonUWP.Game.Models.Airline;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace AirCoon.Game.Models.Aircraft
{
    [Serializable()]
    public class Plane 
        : ISerializable, IAmTickable
    {
        
        public enum States {
          Ordered,
          InProduction,
          Maintenance,
          Idle,
          Preparation,
          Boarding,
          TaxiToRunway,
          Takeoff,
          InFlight,
          Approach,
          TaxitoTerminal,
          DeBoarding
        }
        
        readonly Aircraft Aircraft;
        private Fleet _Fleet;
        public Fleet Fleet {
          get { return _Fleet; }
          set { this._Fleet = value; }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public void MiniTick(Tick CurrentTick, int MiniTick)
        {
            throw new NotImplementedException();
        }

        public void Tick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void DailyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void WeeklyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void QuarterlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void YearlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }
    } // End Class


} // End Namespace
