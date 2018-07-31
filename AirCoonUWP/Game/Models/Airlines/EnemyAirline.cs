using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Aircoon.Game.Models.Airlines;
using AirCoon.Game.Handler;
using AirCoon.Game.Models;

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
         
        private String [] AllowedAircraftTypes;

        private EnemyAirline(String[] data) {
            base._Code = data["Code"];
            base._Name = data["Name"];
            throw new NotImplementedException();
        }

        public EnemyAirline(SerializationInfo info, StreamingContext context) {
            throw new NotImplementedException();
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
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
