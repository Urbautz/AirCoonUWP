
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Handler;
using AirCoon.Game.Models.Aircraft;
using AirCoon.Game.Models.Airlines;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace AirCoon.Game.Models.Aircraft
{

    public enum PlaneState
    {
        Ordered,
        InProduction,
        InStock,
        Maintenance,
        Idle,
        Preparation,
        Boarding,
        TaxiToRunway,
        Takeoff,
        InFlight,
        Approach,
        TaxitoTerminal,
        DeBoarding
    }
    
    
    public abstract class ICanOwnPlane {
    
         public String Code;
         public String DesignationCode;
        
         public abstract String GetNextDesignation();
        
    } // End class ICanOwnPlane
    

    [Serializable()]
    public class Plane 
        : ISerializable, IAmTickable
    {

        readonly Aircraft Aircraft;
        private readonly String _Designation;
        public String Designation { get { return _Designation; } }
        

        private ICanOwnPlane _Owner;
        public ICanOwnPlane Owner {
          get { return _Owner; }
        }

        private PlaneState _PlaneState;
        public PlaneState PlaneState
        {
            get { return _PlaneState; }
        }

        private Airport _Position;
        public Airport Position
        {
            get { return _Position; }
        }

        public Plane(Aircraft aircraft, ICanOwnPlane owner = null, PlaneState planestate = PlaneState.Ordered) 
        {
            this.Aircraft = aircraft;
            if (owner == null)
                this._Owner = aircraft.Manufacturer;
            else
                this._Owner = owner;
                
            this._Designation = owner.GetNextDesignation();
            this._PlaneState = planestate;
        }  // End Constructor
        
        public Plane(SerializationInfo info, StreamingContext context) 
        {
            
        
        } // End Deserializier

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Aircraft", Aircraft.Name);
            info.AddValue("Owner", this.Owner.Code);
            info.AddValue("OwnerType", this.Owner.GetType());
           // WIE WIRD OWNER-Klasse bestimmt?
        } // End Serializer

        public void MiniTick(Tick CurrentTick, int MiniTick)
        {
            throw new NotImplementedException();
        }

        public void Tick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void DailyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void WeeklyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void QuarterlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }

        public void YearlyTick(Tick CurrentTick)
        {
            throw new NotImplementedException();
        }
    } // End Class


} // End Namespace
