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
        private Dictionary<string, object> _deserialized;
        public NestedJsonParser()
        {
            _serializer = new JavaScriptSerializer();            
        }

        public NestedJsonParser Deserialize(string json)
        {
            _deserialized =  _serializer.Deserialize<Dictionary<string, object>>(json);
            return this;
        }
        public string Serialize(object obj)
        {
            return _serializer.Serialize(obj);
        }        
        public void Print()
        {
            _printWithDepth(_deserialized);
        }

        private void _printWithDepth(Dictionary<string, object> dict, int depth = 1)
        {
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + " : " + depth);
                if (item.Value is Dictionary<string, object>)
                {
                    _printWithDepth((Dictionary<string, object>)item.Value, depth + 1);
                }
            }
        }
    }    
}
