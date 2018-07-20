using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Handler;
using AirCoon.Game.Models.Geo;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace AirCoon.Game.Models
{
    [Serializable]
    public class Airport
        : ISerializable, IAmTickable
    {
        public readonly String Iata;
        public readonly String Icao;
        public readonly String Name;

        public readonly Region Region;
        public Country Country
        { get { return Region.Country; } }
        public Continent Continent
        { get { return this.Country.Continent; } }
        public readonly String Municipality;

        public readonly bool Hub;
        public readonly GeoCoordinate Coordinate;
        public Char Size;

        public readonly Int16 RunwayLength;
        public readonly Int16 RunwayCount;
        public readonly Int16 Slots;

        private int _TotalPassengers;
        public int TotalPassengers { get { return _TotalPassengers; } }


        public Airport(String iata, String icao, string name,
                    Region region, bool hub, GeoCoordinate coordinate, String size, String municipality,
                    Int16 runwaylength, Int16 runwaycount, Int16 Slots,
                    int totalpassengers
                    )
        {
            this.Iata = iata;
            this.Icao = icao;
            this.Name = name;

            this.Region = region;
            this.Hub = hub;
            this.Coordinate = coordinate;
            switch (size)
            {
                case "L": Size = 'L'; break;
                case "M": Size = 'M'; break;
                default: Size = 'M'; break;
            }
            this.Municipality = municipality;

            this.RunwayLength = runwaylength;
            this.RunwayCount = runwaycount;
            this.Slots = Slots;
            this._TotalPassengers = totalpassengers;

            if (!SaveGamePublic.SaveGame.Airports.ContainsKey(this.Iata))
            {
                SaveGamePublic.SaveGame.Airports.Add(this.Iata, this);
            }
        } // end constructor

        // Deserializer
        public Airport(SerializationInfo info, StreamingContext ctxt)
        {
            this.Iata = info.GetString("Iata");
            this.Icao = info.GetString("Icao");
            this.Name = info.GetString("Name");

            this.Region = SaveGamePublic.SaveGame.Regions[info.GetString("Region")];
            this.Hub = info.GetBoolean("Hub");
            this.Coordinate = (GeoCoordinate)info.GetValue("Coordinate", typeof(GeoCoordinate));

            this.Size = info.GetChar("Size");

            this.Municipality = info.GetString("Municipality");;

            this.RunwayLength = info.GetInt16("RunwayLength");
            this.RunwayCount = info.GetInt16("RunwayCount");
            this.Slots = info.GetInt16("Slots");
            this._TotalPassengers = info.GetInt32("TotalPassengers");

        } // End Deserializer

        // Serializer
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Iata", this.Iata);
            info.AddValue("Icao", this.Icao);
            info.AddValue("Name", this.Name);
            info.AddValue("Region", this.Region.Code);
            info.AddValue("Hub", this.Hub);
            info.AddValue("Coordinate", this.Coordinate);
            info.AddValue("Size", this.Size);
            info.AddValue("Municipality", this.Municipality);
            info.AddValue("RunwayLength", this.RunwayLength);
            info.AddValue("RunwayCount", this.RunwayCount);
            info.AddValue("Slots", this.Slots);
            info.AddValue("TotalPassengers", this._TotalPassengers);

        } // end serializer
        
        public void MiniTick(Tick CurrentTick, int MiniTick){
        } // End Minitick
        
        public void Tick(Tick CurrentTick){
        } // End Tick

        public void DailyTick(Tick CurrentTick){
        } // End DailyTick

        public void WeeklyTick(Tick CurrentTick){
        } // End WeeklyTick

        public void QuarterlyTick(Tick CurrentTick){
        } // End QuarterlyTick

        public void YearlyTick(Tick CurrentTick){
        } // End YearlyTick

    } // End class
}// ENd namespace

