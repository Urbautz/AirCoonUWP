using AirCoon.Game.Models.Airlines;
using AirCoon.Game.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace AirCoon.Game.Models.Airlines
{
    [Serializable]
    public class Alliance
        : ISerializable
    {

        public readonly String Name;
        public String Code { get { return Name; } }

        private Dictionary<String, Airline> _Members = new Dictionary<string, Airline>();
        public Dictionary<String, Airline> Members
        {
           get { return _Members; }
        }

        public Alliance(String name)
        {
            this.Name = name;
            SaveGamePublic.SaveGame.Alliances.Add(this.Code, this);

        }

        public Alliance(SerializationInfo info, StreamingContext context)
        {
            this.Name = info.GetString("Name");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", this.Name);
        }

        protected void AddMember(Airline airline)
        {
            this._Members.Add(airline.Code, airline);
        }
    }// End Class
    
}// end Namespace
