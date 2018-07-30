using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Handler;
using AirCoon.Game.Models;

namespace AirCoon.Game.Models.Routing
{

    public abstract class Path
        : ISerializable
    {

        protected String _Code;
        public String Code { get { return _Code; } }

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

        protected String _ConnectionCode;

        public Connection Connection
        {
            get { return SaveGamePublic.SaveGame.Connections[_ConnectionCode]; }
        }

        //public abstract Path(SerializationInfo info, StreamingContext ctxt);
        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);
        public abstract void CalculateStandardCost();

        public void Register()
        {

        }

    } // End class
} // End Namespace
