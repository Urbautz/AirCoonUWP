
using System;
using System.Collections.Generic;
using System.Collections.Queue;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Handler;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace AirCoon.Game.Models.Aircraft
{
    [Serializable()]
    class Plane 
        : ISerializable, IAmTickable
    {
        
        public static enum States {
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
    
    
    
    
    } // End Class


} // End Namespace
