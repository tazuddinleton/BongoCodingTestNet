using System;
using System.Text;
using BongoCodingTestNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBongoCodingTestNet
{
    [TestClass]
    public class TestJsonParser
    {
        [TestMethod]
        public void ShouldParseNestedJsonStringAndPrintWithDepth()
        {
            string json = "{\"Key1\": \"1\",\"Key2\": {\"Key3\": \"1\",\"Key4\": {\"Key5\": \"4\"}}}";
            NestedJsonParser parser = new NestedJsonParser();
            parser.Deserialize(json)
                  .Print();            
        }
        [TestMethod]
        public void ShouldParseNestedJsonStringAndPrintWithDepthWithCsharpObject()
        {
            NestedJsonParser parser = new NestedJsonParser();
            StringBuilder jsonBuilder = new StringBuilder();

            Person personA = new Person("User", "1", null);
            Person personB = new Person("User", "2", personA);

            jsonBuilder.Append("{\"Key1\": \"1\",\"Key2\": {\"Key3\": \"1\",\"Key4\": {\"Key5\": \"4\", \"user\":user_placeholder}}}");
            jsonBuilder.Replace("user_placeholder", parser.Serialize(personB));
            parser.Deserialize(jsonBuilder.ToString())
                  .Print();
        }

    }
}
