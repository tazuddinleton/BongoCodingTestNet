using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace BongoCodingTestNet
{
    public class NestedJsonParser
    {
        private JavaScriptSerializer _serializer;        
        public NestedJsonParser()
        {
            _serializer = new JavaScriptSerializer();            
        }

        public Dictionary<string, object> ParseJSON(string json)
        {
            return _serializer.Deserialize<Dictionary<string, object>>(json);            
        }
        public void PrintWithDepth(Dictionary<string, object> dict, int depth = 1)
        {           
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " : " + depth);
                if (item.Value is Dictionary<string, object>)
                {                    
                    PrintWithDepth((Dictionary<string, object>)item.Value, depth + 1);
                }
            }
        }
    }    
}
