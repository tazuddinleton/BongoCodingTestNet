using System;
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
            var parsed = parser.ParseJSON(json);
            parser.PrintWithDepth(parsed);
        }
    }
}
