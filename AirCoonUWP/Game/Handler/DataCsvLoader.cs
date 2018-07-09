using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AirCoon.Game.Handler
{
    class DataCsvLoader
    {
        private StreamReader Stream;
        private String LastLine;
        private String PrevLine;
        private String[] Headers;

        public DataCsvLoader(StreamReader stream, bool stripfirstline=true, bool firstlineisheaders=false)
        {
            this.Stream = stream;
            if(stripfirstline)
            {
                LastLine = Stream.ReadLine();
            } else if (firstlineisheaders) {
                Headers = this.getNextLine();
            }
        }

        public String[] getNextLine(int minElements = 2)
        {
            PrevLine = LastLine;
            LastLine = Stream.ReadLine();
            
            if(LastLine == null)
            {
                Stream.Close();
                return null;
            }
            
            String[] splitted = LastLine.Split(new Char[] { ',' });
            if (splitted.Length == 0)
            {
                Debug.Write("Empty line read", 1);
                Stream.Close();
                return null;
            }
             if (splitted[minElements-1] is null )
            {
                Debug.Write("Min. number of elements not found " + PrevLine, 1);
                Stream.Close();
                return null;
            }     
            return splitted;
            
        }
        
        public Dictionary<string,string> getNextLineHeaders(int minElements = 2)
            String[] data = this.getNextLine(minElements);
            Dictionary<string,string> result = new Dictionary<string,string>
            if(data.Length != this.Headers.Length)
                return null;
            
            for(i = 0; i<data.Length; i++) {
                result.add(this.Headers[i], data[i]);
            }
            return result;
        
    }
}
