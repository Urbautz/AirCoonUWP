using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace AirCoon.Game.Models.Geo
{
    [Serializable]
    public class GeoCoordinate
        : ISerializable
    {
        const double PI180 = Math.PI / 180;
        const double Radius = 6371.1;

        readonly Decimal Latitude;

        readonly Decimal Longitude;

        readonly int Altitude;


        public GeoCoordinate(Decimal latitude, Decimal longitude, int altitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Altitude = altitude;
        }


        // Deserializer
        public GeoCoordinate(SerializationInfo info, StreamingContext ctxt)
        {
            this.Latitude= info.GetDecimal("Latitude");
            this.Longitude = info.GetDecimal("Longitude");
            this.Altitude = info.GetInt32("Altitude");
        }

        // Serializer
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Latitude", this.Latitude);
            info.AddValue("Longitude", this.Longitude);
            info.AddValue("Altitude", this.Altitude);
        }


        public static double Radians(double x)
        {
            return x * PI180;
        }

        public double calculate_distance(GeoCoordinate other)
        {
            double lon1 = (double) this.Longitude;
            double lat1 = (double) this.Latitude;

            double lon2 = (double) other.Longitude;
            double lat2 = (double) other.Latitude;

            double dlon = Radians(lon2 - lon1);
            double dlat = Radians(lat2 - lat1);

            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return angle * Radius;
        }

        /*
            public double calculate_distance(GeoCoordinate other)
        {
            double circumference = 40075.16; // Earth's circumference at the equator in km
            double distance = 0.0;
            double latitude1Rad = DegreesToRadians(this.Latitude);
            double latititude2Rad = DegreesToRadians(other.Latitude);
            double longitude1Rad = DegreesToRadians(this.Longitude);
            double longitude2Rad = DegreesToRadians(other.Latitude);
            double logitudeDiff = Math.Abs(longitude1Rad - longitude2Rad);

            if (logitudeDiff > Math.PI)
            {
                logitudeDiff = 2.0 * Math.PI - logitudeDiff;
            }

            double angleCalculation =
                Math.Acos(
                  Math.Sin(latititude2Rad) * Math.Sin(latitude1Rad) +
                  Math.Cos(latititude2Rad) * Math.Cos(latitude1Rad) * Math.Cos(logitudeDiff)
                );

            distance = circumference * angleCalculation / (2.0 * Math.PI);

            return distance;
        }



        private static Double DegreesToRadians(Decimal angle) => 
            (Double)(Math.PI * (Double)angle / 180.0);
            */

    } // end class
} // end Namespace
