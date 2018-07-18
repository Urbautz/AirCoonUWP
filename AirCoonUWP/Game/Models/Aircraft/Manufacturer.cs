
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
        private List<ProductionLine> ProductionLines;
        private Queue<Plane> OrderBook;
        private List<Plane> _PlaneInStock;
        public List<Plane> PlanesInStock {
            get { return _PlanesInStock; }
        }
            
        
        public Manufacturer(String name, int productionlines, int capacity) 
        {
           this.Name = name;
           ProductionLines = new List<ProductionLine>;
           for (int i=0;i<productionlines;i++) {
             ProductionLines.add(new ProductionLine(this, capacity));
           }
           this.OrderBook = new Queue();
           this._PlanesInStock = new List<Plane>;

        } // End Constructor
        
        
        public Manufacturer(SerializationInfo info, StreamingContext ctxt) 
        {
          this.Name = info.GetString("Name');
          this.ProductionLines = (List<ProductionLine>) info.GetValue("ProductionLines", typeof(List<ProductionLine>));
          
          this.OrderBook = new Queue();
          List<Plane> temp = (List<Plane>) info.GetValue("OrderBook", typeof(List<Plane>)) )
          foreach (Plane p in temp) {
              this.Orderbook.enqueue(p);
          }
          this.PlanesInStock = (List<Plane>) info.GetValue("PlanesInStock", typeof(List<Planes>));
          
        } // End Deserializer
        
        // Serialiszer
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Name", this.Name);
            info.Addvalue("ProductionLines", this.ProductionLines);
            info.AddValue("OrderBook", this.OrderBook.ToList() );
            info.AddValue("PlanesInStock", this.PlanesInStock);
        }
        
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
