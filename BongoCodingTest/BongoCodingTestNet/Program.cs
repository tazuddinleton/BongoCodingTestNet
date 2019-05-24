using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
namespace BongoCodingTestNet
{

    public class Person
    {
        public string firstName, lastName;
        public object father;
        public Person() { }
        public Person(string firstName, string lastName, object father)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.father = father;
        }
    }

    class Program
    {   
        static void Main(string[] args)
        {
            NestedJsonParser parser = new NestedJsonParser();
            StringBuilder jsonBuilder = new StringBuilder();           

            Person personA = new Person("User", "1", null);
            Person personB = new Person("User", "2", personA);            
            
            jsonBuilder.Append("{\"Key1\": \"1\",\"Key2\": {\"Key3\": \"1\",\"Key4\": {\"Key5\": \"4\", \"user\":user_placeholder}}}");            
            jsonBuilder.Replace("user_placeholder", parser.Serialize(personB));
            parser.Deserialize(jsonBuilder.ToString())
                  .Print();
            Console.ReadLine();
        }
    }
}
