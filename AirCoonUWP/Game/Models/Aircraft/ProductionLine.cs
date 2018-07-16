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
    public class ProductionLine
        : ISerializable, IAmTickable
    {
        readonly int Capacity;
        private int _Progress;
        public int Progress {
            get { return _Progress;}
        }
        private Plane AircaftWIP = null;

        private Plane _AircraftNext = null;
        public Aircraft AircraftNext {
          get { return _AircraftNext; }
        }
            
        
        public ProductionLine(int capacity) {
           this.Capacity = capacity;
        } // end Constructor
        
        public ProductionLIne(SerializationInfo info, StreamingContext ctxt) {
          this.Name = info.GetString("Name');
          blablah missing
        } // End Deserializer
    
        public bool SetNextAircraft(Aircraft ac) {
             if(this.AircraftWIP == null) {
                  this.AircraftWIP = ac;
                  return true;
             } 
             if(this.AircraftNext == null) {
                  this.AircraftNext = ac;
                  return true;
             }
             return false;
        }
    } // End Class
} // End Namespace
