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
    
        public readonly String Name;
        public readonly Manufacturer Manufacturer;
        public readonly String Family;
        public readonly int Rating;

        public readonly int Speed;
        public readonly int FuelClimb;
        public readonly int FuelTaxi;
        public readonly int FuelHour;

        public readonly int Range;
        public readonly int RunwayMinLength;

        public readonly int CabinWidth;
        public readonly int CabinLength;
        public readonly int MaxSeat;

        public readonly Money ListPrice;
        public readonly int CostProduction;

        public readonly int WearTakeoff;
        public readonly int WearFlightHour;
        public readonly int MaxHealth;
        
      
            
        
        public Aircraft(Dictionary<String,String> data) 
        {
            this.Name           = data["Name"];
            this.Manufacturer   = SaveGamePublic.SaveGame.Manufacturers[data["Manufacturer"]];
            this.Family         = data["Family"];
            this.Rating         = Int32.Parse(data["Rating"]);

            this.Speed          = Int32.Parse(data["Speed"]);
            this.FuelClimb      = Int32.Parse(data["FuelClimb"]);
            this.FuelTaxi       = Int32.Parse(data["FuelTaxi"]);
            this.FuelHour       = Int32.Parse(data["FuelHour"]);

            this.Range          = Int32.Parse(data["Range"]);
            RunwayMinLength     = Int32.Parse(data["RunwayMinLength"]);

            this.CabinWidth     = Int32.Parse(data["CabinWidth"]);
            this.CabinLength    = Int32.Parse(data["CabinLength"]);
            this.MaxSeat        = Int32.Parse(data["MaxSeat"]);

            this.ListPrice      = new Money(Decimal.Parse(data["ListPrice"]));
            this.CostProduction = Int32.Parse(data["CostProduction"]);

            this.WearTakeoff    = Int32.Parse(data["WearTakeoff"]);
            this.WearFlightHour = Int32.Parse(data["WearFlightHour"]);
            this.MaxHealth      = Int32.Parse(data["MaxHealth"]);

            SaveGamePublic.SaveGame.Aircrafts.Add(this.Name, this);
        } // End Constructor
        
        // Deserializer
        public Aircraft(SerializationInfo info, StreamingContext ctxt) 
        {
            this.Name           = info.GetString("Name");
            this.Manufacturer   = SaveGamePublic.SaveGame.Manufacturers[info.GetString("Manufacturer")];
            this.Family         = info.GetString("Family");
            this.Rating         = info.GetInt32("Rating");

            this.Speed          = info.GetInt32("Speed");
            this.FuelClimb      = info.GetInt32("FuelClimb");
            this.FuelTaxi       = info.GetInt32("FuelTaxi");
            this.FuelHour       = info.GetInt32("FuelHour");

            this.Range          = info.GetInt32("Range");
            RunwayMinLength     = info.GetInt32("RunwayMinLength");

            this.CabinWidth     = info.GetInt32("CabinWidth");
            this.CabinLength    = info.GetInt32("CabinLength");
            this.MaxSeat        = info.GetInt32("MaxSeat");

            this.ListPrice      = (Money) info.GetValue("ListPrice", typeof(Money));
            this.CostProduction = info.GetInt32("CostProduction");

            this.WearTakeoff    = info.GetInt32("WearTakeoff");
            this.WearFlightHour = info.GetInt32("WearFlightHour");
            this.MaxHealth      = info.GetInt32("MaxHealth");   
        } // End Deserializer

        // Serialiszer
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Name", this.Name);
            info.AddValue("Manufacturer", this.Manufacturer.Name);
            info.AddValue("Family", this.Family);
            info.AddValue("Rating", this.Rating);

            info.AddValue("Speed", this.Speed);
            info.AddValue("FuelClimb", this.FuelClimb);
            info.AddValue("FuelTaxi", this.FuelTaxi);
            info.AddValue("FuelHour", this.FuelHour);

            info.AddValue("Range", this.Range);
            info.AddValue("RunwayMinLength", this.RunwayMinLength);

            info.AddValue("CabinWidth", this.CabinWidth);
            info.AddValue("CabinLength", this.CabinLength);
            info.AddValue("MaxSeat", this.MaxSeat);

            info.AddValue("ListPrice", this.ListPrice);
            info.AddValue("CostProduction", this.CostProduction);

            info.AddValue("WearTakeoff", this.WearTakeoff);
            info.AddValue("WearFlightHour", this.WearFlightHour);
            info.AddValue("MaxHealth", this.MaxHealth);

        }
 
          
    } // End Class
} // End Namespace
