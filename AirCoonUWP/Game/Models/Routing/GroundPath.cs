using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Models;
using AirCoon.Game.Handler;
using AirCoon.Game.Models.Routing;

namespace AirCoon.Game.Models.Routing
{
    public class GroundPath : Path
    {

        public override string Code => Connection.Code+"G";


        public GroundPath(Connection connection)
        {
            this.Connection = connection;
            if (!SaveGamePublic.SaveGame.Paths.ContainsKey(this.Code))
            {
                SaveGamePublic.SaveGame.Paths.Add(this.Code, this);
                Connection.Paths.Add(this.Code, this);
            }
        }
        
        public GroundPath(SerializationInfo info, StreamingContext ctxt);
        {
              base.Connection = SaveGamePublic.Savegame.Connections[info.GetString("Connection")];
              base._StandardCost = (Money) info.GetValue("StandardCost", typeof(Money))
        }
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(base.Connection.Code);
            info.AddValue(base._StandardCost);
        };


        public override void CalculateStandardCost()
        {
            _StandardCost = new Money((Decimal) Math.Ceiling(this.Connection.Distance) * 5);
        }
    } // End Class
} // End Namespace
