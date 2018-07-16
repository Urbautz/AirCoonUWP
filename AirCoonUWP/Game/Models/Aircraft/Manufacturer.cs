
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
    public class Manufacturer
        : ISerializable
    {
    
        readonly String Name;
        private ProductionLine[] ProductionLines;
        private Queue OrderBook;
        private List<Aircraft> _AircraftInStock;
        public List<Aircraft> AircraftInStock {
            get { return _AircraftInStock;}
        }
            
        
        public Manufacturer(String name, int productionlines, int capacity) {
           this.Name = name;
           ProductionLines[] = new ProductionLine[productionlines]
           for (int i=0;i<productionlines;i++) {
             ProductionLines[i] = new ProductionLine(this, capacity);
           }
           this.OrderBook = new Queue();
           this._AircraftInStock = new List<Aircraft>;
        } // end Constructor
        
        public Manufacturer(SerializationInfo info, StreamingContext ctxt) {
          this.Name = info.GetString("Name');
          blablah missing
        } // End Deserializer
    
    } // End Class
} // End Namespace
