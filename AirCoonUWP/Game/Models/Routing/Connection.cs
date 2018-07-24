using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Models;
using AirCoon.Game.Handler;


namespace AirCoon.Game.Models.Routing
{
 [Serializable]
    public class Connection
      : ISerializable
    {

        public readonly Airport Airport1;
        public readonly Airport Airport2;

        public String Code { get { return Airport1.Iata + Airport2.Iata; }        }

        private Double _Distance = -1;
        public Double Distance
        {
            get
            {
                if(_Distance == -1)
                {
                    _Distance = Airport1.Coordinate.CalculateDistance(Airport2.Coordinate);
                }
                return _Distance;
            } // ENd Get Distance
        } // ENd Distance

        public Dictionary<String, Path> Paths = new Dictionary<String, Path>();


        public Connection(Airport airport1, Airport airport2)
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
        } // End Constructor
        
        // Deserialiszer
        public Connection(SerializationInfo info, StreamingContext ctxt)
        {
            this.Airport1 = SaveGamePublic.Savegame.Airports[info.GetString("Aiport1")];
            this.Airport2 = SaveGamePublic.Savegame.Airports[info.GetString("Aiport2")];
        } // End Desieralizer
        
        // Serializer
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.addValue("Airport1", this.Airport1.Iata);
            info.addValue("Airport2", this.Airport2.Iata);

        }} / end Serisalizer

        public Connection Register()
        {
            if(!Airport1.Connections.ContainsKey(Airport2))
                Airport1.Connections.Add(Airport2, this);
            if (!Airport2.Connections.ContainsKey(Airport1))
                Airport2.Connections.Add(Airport1, this);

            if (SaveGamePublic.SaveGame.Connections.ContainsKey(this.Code))
            {
                return SaveGamePublic.SaveGame.Connections[this.Code];
            } else { 
            SaveGamePublic.SaveGame.Connections.Add(this.Code, this);
            return this;
            }
        }

    } // End Class
} // End Namespace
