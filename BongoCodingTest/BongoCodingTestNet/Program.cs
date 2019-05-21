using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
namespace BongoCodingTestNet
{
    class Program
    {
        static void Main(string[] args)
        {
            NestedJsonParser parser = new NestedJsonParser();
            string json = "{\"Key1\": \"1\",\"Key2\": {\"Key3\": \"1\",\"Key4\": {\"Key5\": \"4\"}}}";
            var deserialized = parser.ParseJSON(json);
            parser.PrintWithDepth(deserialized);
            Console.ReadLine();
        }
    }
}
