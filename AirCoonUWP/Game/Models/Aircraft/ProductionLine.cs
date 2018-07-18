using System;
using System.Collections.Generic;
using System.Collections.Queue;
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
    
        readonly Manufacturer Manufacturer;
        readonly int Capacity;
        private int _Progress;
        public int Progress {
            get { return _Progress;}
        }
        private Plane PlaneWIP = null;
            
        
        public ProductionLine(Manufacturer manufacturer, int capacity) {
           this.Capacity = capacity;
           this.Manufacturer = manufacturer;
        } // end Constructor
        
        public ProductionLIne(SerializationInfo info, StreamingContext ctxt) {
          m = info.GetString("Manufacturer");  
          this.Manufacturer = SaveGamePublic.SaveGame.Manufacturers[m];
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
             if(this.PlaneWIP == null) {
                  this.PlaneWIP = ac;
                  return true;
             } 
             return false;
        }// end StartPlanebuild
    } // End Class
} // End Namespace
