using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Models;
using AirCoon.Game.Models.Geo;

namespace AirCoonUWP.Game.Models.Geo
{
    public enum ConnectionType
    {
        Ground,
        Plane
    }

    public class Connection
    {

        public readonly Airport Airport1;
        public readonly Airport Airport2;

        private Double _Distance = -1;
        public Double Distance
        {
            get
            {
                if(_Distance == -1)
                {
                    _Distance = Airport1.Coordinate.calculate_distance(Airport2.Coordinate);
                }
                return _Distance;
            }
        }

        public ConnectionType Type;

        public Connection(Airport airport1, Airport airport2, ConnectionType type)
        {
            if(String.Compare(airport1.Iata,airport2.Iata) < 0) // 1 precedes 2
            {
                this.Airport1 = airport1;
                this.Airport2 = airport2;
            } else
            {
                this.Airport1 = airport2;
                this.Airport2 = airport1;
            }

            this.Type = type;
        }

        

    }
}
