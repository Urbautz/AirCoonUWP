using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCoon.Game.Handler;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace AirCoon.Game.Models.Aircraft
{
    [Serializable()]
    public class ProductionLine
        : ISerializable, IAmTickable
    {
    
        private String _ManufacturerName;
        public Manufacturer Manufacturer
        {
            get { return SaveGamePublic.SaveGame.Manufacturers[_ManufacturerName]; }
        }

        readonly int Capacity;

        private int _Progress;
        public int Progress {
            get { return _Progress;}
        }

        private Plane _PlaneWIP = null;
        public Plane PlaneWIP
        {
            get { return _PlaneWIP; }
        }
            
        // Constructor
        public ProductionLine(Manufacturer manufacturer, int capacity) {
           this.Capacity = capacity;
           this._ManufacturerName = manufacturer.Name;
        } // end Constructor
        
        // Deserialsizer
        public ProductionLine(SerializationInfo info, StreamingContext ctxt) {
          
            this._ManufacturerName = info.GetString("Manufacturer");
            this.Capacity = info.GetInt32("Capacity");
            this._Progress = info.GetInt32("Progress");
            try 
            {
                this._PlaneWIP = (Plane)info.GetValue("PlaneWIP", typeof(Plane));
            } catch (Exception e) {
                this._PlaneWIP = null;
            }
        }// End Deserializer
    
        // Serialiszer
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Manufacturer", this.Manufacturer.Name);
            info.AddValue("Capacity", this.Capacity);
            info.AddValue("Progress", this.Progress);
            info.AddValue("PlaneWIP", this.PlaneWIP);
        } // end GetObjectData

        public bool StartPlaneBuild(Plane plane) {
             if(this._PlaneWIP == null) {
                  this._PlaneWIP = plane;
                  return true;
             } 
             return false;
        }// end StartPlanebuild

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
