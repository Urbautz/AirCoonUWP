using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Aircoon.Game.Models.Airlines;
using AirCoon.Game.Handler;
using AirCoon.Game.Models;
using AirCoon.Game.Models.Aircraft;

namespace AirCoon.Game.Models.Airlines
{

    public class EnemyAirline
        : Airline
    {
    
        private int _ActionPoints;
        private readonly int _ActionPointsGain;
         
        private int _QuoteIntercontiPlanned;
        private int _QuoteInternatPlanned;
        private int _QuoteNationalPlanned;
        private int _QualityLevelPlanned;
         
        private List<String> AllowedAircraftTypes;

        private EnemyAirline(Dictionary<String,String> data) {
            base.CreateSubClass 
            (
                data["Code"], 
                data["Name"],
                new List<Airport> { SaveGamePublic.SaveGame.Airports[data["Mainhub"]] }, 
                SaveGamePublic.SaveGame.Alliances[data["Alliance"]],
                new Money(decimal.Parse(data["Money"]))
            );
            this._ActionPointsGain = int.Parse(data["ActionPoints"]);
            this._ActionPoints = _ActionPointsGain * 100;

            String[] quotes = DataCsvLoader.SubData(data["Quote"]);
                if(quotes.Length != 3)  
                    throw new SaveGameException("Quotes not correct: "+ this.Code + ", " + data["Quote"]);
                this._QuoteIntercontiPlanned = int.Parse(quotes[0]);
                this._QuoteInternatPlanned = int.Parse(quotes[1]);
                this._QuoteNationalPlanned = int.Parse(quotes[2]);
            
            this._QualityLevelPlanned = int.Parse(data["QualityLevel"]);

            String[] types = DataCsvLoader.SubData(data["AircraftModels"]);
           
                foreach(String type in types) 
                {
                    bool found = false;
                    foreach(KeyValuePair<String,Aircraft.Aircraft> ac in SaveGamePublic.SaveGame.Aircrafts) 
                    {
                        if(ac.Value.Family == type) {
                            found = true;
                            break;
                        } // end if                    
                    } // end Foreach Aircraft
                    if (found) {
                        this.AllowedAircraftTypes.Add(type);
                    } else {
                      throw new SaveGameException("Aircraft-Type not found: "+ this.Code + ", " + type);  
                    }
                } // end looping trough Models
            
            
        } // End Constructor

        
        public EnemyAirline(SerializationInfo info, StreamingContext context)
        {
            base.DeserializeSubClass(info, context);
            this._ActionPoints               = info.GetInt32("ActionPoints");
            this._ActionPointsGain          = info.GetInt32("ActionPointsGain");
            this._QuoteIntercontiPlanned    = info.GetInt32("QuoteIntercontiPlanned");
            this._QuoteInternatPlanned      = info.GetInt32("QuoteInternatPlanned");
            this._QuoteNationalPlanned      = info.GetInt32("QuoteNationalPlanned");
            this._QualityLevelPlanned       = info.GetInt32("QualityLevelPlanned");
         
            AllowedAircraftTypes =  (List<String>) info.GetValue("AllowedAircraftTypes", typeof(List<String>) );
        } // END Deserializer

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.SerializeSubClass(info, context);
            throw new NotImplementedException();
        }


        public override void DailyTick(Tick CurrentTick)
        {
            this._ActionPoints += this._ActionPointsGain;
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
