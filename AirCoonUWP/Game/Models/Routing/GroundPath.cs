using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Models;
using AirCoon.Game.Handler;
using AirCoon.Game.Models.Routing;
using System.Runtime.Serialization;

namespace AirCoon.Game.Models.Routing
{
    [Serializable]
    public class GroundPath : Path
    {


        public GroundPath(Connection connection)
        {
            this._ConnectionCode = connection.Code;
            base._Code = Connection.Code + "G";
            if (!SaveGamePublic.SaveGame.Paths.ContainsKey(this.Code))
            {
                SaveGamePublic.SaveGame.Paths.Add(this.Code, this);
                base.Connection.Paths.Add(this.Code, this);
            }
        }
        
        public GroundPath(SerializationInfo info, StreamingContext ctxt)
        {
            base._ConnectionCode = info.GetString("ConnectionCode");
            base._Code = base._ConnectionCode + "G";
            base._StandardCost = (Money)info.GetValue("StandardCost", typeof(Money));
            SaveGamePublic.SaveGame.Paths.Add(this.Code, this);
        }
        
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ConnectionCode", base._ConnectionCode);
            info.AddValue("StandardCost", base._StandardCost);
        }

        

        public override void CalculateStandardCost()
        {
            _StandardCost = new Money((Decimal) Math.Ceiling(this.Connection.Distance) * 5);
        }
    } // End Class
} // End Namespace
