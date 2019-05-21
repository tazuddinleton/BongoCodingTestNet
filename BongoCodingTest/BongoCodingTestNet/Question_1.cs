using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
namespace BongoCodingTestNet
{
    class Question_1
    {
        static void Main(string[] args)
        {
            string json = "{\"Key1\": \"1\",\"Key2\": {\"Key3\": \"1\",\"Key4\": {\"Key5\": \"4\"}}}";

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var res = serializer.Deserialize<Dictionary<string, object>>(json);
            PrintWithDepth(res, 1);
            Console.ReadLine();                
        }

        static void PrintWithDepth(Dictionary<string, object> dict, int depth)
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
