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

        public Dictionary<string, object> Deserialized
        { get { return _deserialized; } }
        // Implementing Fluent API here
        public NestedJsonParser Deserialize(string json)
        {
            _deserialized =  _serializer.Deserialize<Dictionary<string, object>>(json);
            return this;
        }
        public string Serialize(object obj)
        {
            try
            {
                return _serializer.Serialize(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }        
        public void Print()
        {
            try
            {
                StringBuilder outPutBuilder = new StringBuilder();
                DeepParse(_deserialized, outPutBuilder);
                Console.WriteLine(outPutBuilder.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public StringBuilder DeepParse(Dictionary<string, object> dict, StringBuilder output, int depth = 1)
        {
            try
            {
                foreach (var item in dict)
                {
                    output.Append(item.Key + ": " + depth + "\r\n");
                    if (item.Value is Dictionary<string, object>)
                    {
                        DeepParse((Dictionary<string, object>)item.Value, output, depth + 1);
                    }
                }
                return output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }    
}
