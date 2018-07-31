using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Aircoon.Game.Models.Airlines;
using Aircoon.Game.Models.Airlines.Assets;
using AirCoon.Game.Handler;
using AirCoon.Game.Models;
using AirCoon.Game.Models.Airlines.Assets;

namespace AirCoon.Game.Models.Airlines
{
    [Serializable]
    public class PlayerAirline
        : Airline
    {
        static Money startmoney = new Money(10000000000);

        public PlayerAirline(String code, String name, Airport hub)
        {
            List<Airport> hubs = new List<Airport> { hub };
            base.CreateSubClass(code, name, hubs, null, startmoney);
        }

        public PlayerAirline(SerializationInfo info, StreamingContext context)
        {

            base.DeserializeSubClass(
                            info.GetString("Code"),
                            info.GetString("Name"),
                            (Dictionary < String, Hub > ) info.GetValue("Hubs", typeof(Dictionary<String,Hub>) ),
                            (List<Base>) info.GetValue("Bases", typeof(List<Base>) ), 
                            SaveGamePublic.SaveGame.Alliances[info.GetString("Alliance")]
                );
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.SerializeSubClass(info, context);
            
        }

        public override void DailyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public override void MiniTick(Tick CurrentTick, int MiniTick)
        {
            throw new NotImplementedException();
        }

        public override void QuarterlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public override void Tick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public override void WeeklyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public override void YearlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }
    }
}
