using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Handler;
using AirCoon.Game.Models;

namespace AirCoon.Game.Models.Routing
{

    public abstract class Path
        : ISerializable
    {
        public abstract String Code { get; }
        

        protected Money _StandardCost;
        public Money StandardCost
        {
            get
            {
                if (_StandardCost == null)
                {
                    CalculateStandardCost();
                }
                return _StandardCost;
            } // end get
        }// end Get/Set StandardCost

        public Connection Connection;

        public abstract Path(SerializationInfo info, StreamingContext ctxt);
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
        public abstract void CalculateStandardCost();

    } // End class
} // End Namespace
