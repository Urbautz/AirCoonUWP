using AirCoon.Game.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Models.Airlines;
using AirCoon.Game.Models;

namespace AirCoon.Game.Models.Airlines.Assets
{
    [Serializable]
    public class Base
      : ISerializable, IAmTickable

    {
        protected Airport _Airport;
        public Airport Airport
        {
            get { return _Airport; }
        }

        public Base(Airport airport)
        {
            this._Airport = airport;
        }

        private bool _IsHub = false;
        public bool IsHub { get { return _IsHub;} }

        public Base() {
            _IsHub = true;
        }

        public Base(Airport Aiport, bool ishub = true)
        {

        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }

        public void DailyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void MiniTick(Tick CurrentTick, int MiniTick)
        {
            throw new NotImplementedException();
        }

        public void QuarterlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void Tick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void WeeklyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void YearlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }


    }
}
