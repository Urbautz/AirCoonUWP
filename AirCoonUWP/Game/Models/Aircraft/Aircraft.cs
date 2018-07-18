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
    public class Aircraft
        : ISerializable
    {
    
        readonly String Name;
        readonly Manufacturer Manufacturer;
        readonly String Family;
        readonly int Rating;
        
        readonly int PerformanceSpeed;
        readonly int FuelClimb;
        readonly int FuelTaxi;
        readonly int FuelHour;
        
        readonly int Range;
        readonly int RunwayMinLength;
        
        readonly int CabinWidth;
        readonly int CabinLength;
        readonly int MaxSeat;
        
        readonly Money ListPrice;
        readonly int CostProduction;
        
        readonly int WearTakeoff;
        readonly int WearFlightHour;
        readonly int MaxHealth;
        
      
            
        
        public Aircraft(List<String> data) 
        {

        } // End Constructor
        
        // Deserializer
        public Aircraft(SerializationInfo info, StreamingContext ctxt) 
        {
          
        } // End Deserializer
        
        // Serialiszer
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {

        }
 
          
    } // End Class
} // End Namespace
