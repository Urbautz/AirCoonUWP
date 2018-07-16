
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
        : ISerializable, IAmTickable
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
        } // End Constructor
        
        
        
         void MiniTick(Tick CurrentTick, int MiniTick){
        } // End Minitick
        
        void Tick(Tick CurrentTick){
        } // End Tick
        
        void DailyTick(Tick CurrentTick){
        } // End DailyTick
        
        void WeeklyTick(Tick CurrentTick){
        } // End WeeklyTick
        
        void QuarterlyTick(Tick CurrentTick){
        } // End QuarterlyTick
        
        void YearlyTick(Tick CurrentTick){
        } // End YearlyTick
    } // End Class
} // End Namespace
