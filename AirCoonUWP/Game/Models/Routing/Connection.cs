using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Models;
using AirCoon.Game.Handler;
using System.Runtime.Serialization;

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
            this.Airport1 = SaveGamePublic.SaveGame.Airports[info.GetString("Airport1")];
            this.Airport2 = SaveGamePublic.SaveGame.Airports[info.GetString("Airport2")];
            this.Paths = (Dictionary<String, Path>)info.GetValue("Paths", typeof(Dictionary<String,Path>));

            this.Register();
        } // End Desieralizer
        
        // Serializer
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Airport1", this.Airport1.Iata);
            info.AddValue("Airport2", this.Airport2.Iata);
            info.AddValue("Paths", this.Paths);

        } // end Serisalizer

        public Connection Register()
        {
            if(!Airport1.Connections.ContainsKey(Airport2))
                Airport1.Connections.Add(Airport2, this);
            if (!Airport2.Connections.ContainsKey(Airport1))
                Airport2.Connections.Add(Airport1, this);

            // In case of Loading a savegame, this might still be null.
            if (SaveGamePublic.SaveGame.Connections is null)
                return this;

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
