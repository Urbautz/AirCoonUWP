using System;
using System.Collections.Generic;
using System.Collections;
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
        
        readonly int Speed;
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
            this.Name = data["Name"];
            this.Manufacturer = PublicSaveGame.SaveGame.Manufacturers[data["Manufacturer"]];
            this.Family = data["Family"];
            this.Rating = Int.Parse(data["Rating"]);

            this.Speed = Int.Parse(data["Speed"]);
            this.FuelClimb = Int.Parse(data["FuelClimb"]);
            this.FuelTaxi = Int.Parse(data["FuelTaxi"]);
            this.FuelHour = Int.Parse(data["FuelHour"]);

            this.Range = Int.Parse(data["Range"]);
            this.RunwayMinLength = Int.Parse(data["RunwayMinLength"]);

            this.CabinWidth = Int.Parse(data["CabinWidth"]);
            this.CabinLength = Int.Parse(data["CabinLength"]);
            this.MaxSeat = Int.Parse(data["MaxSeat"]);

            this.ListPrice = new Money(Decimal.Parse(data["ListPrice"]));
            this.CostProduction = data["CostProduction"];

            this.WearTakeoff = Int.Parse(data["WearTakeoff"]);
            this.WearFlightHour = Int.Parse(data["WearFlightHour"]);
            this.MaxHealth = Int.Parse(data["MaxHealth"]);
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
