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
            
            NestedJsonParser parser = new NestedJsonParser();
            StringBuilder output = new StringBuilder();
            StringBuilder jsonBuilder = new StringBuilder();
            StringBuilder expectedOutput = new StringBuilder();
            jsonBuilder.Append("{\"Key1\": \"1\",\"Key2\": {\"Key3\": \"1\",\"Key4\": {\"Key5\": \"4\"}}}");
            var deserialized = parser.Deserialize(jsonBuilder.ToString()).Deserialized;
            expectedOutput.Append(@"Key1: 1@Key2: 1@Key3: 2@Key4: 2@Key5: 3@");
            expectedOutput.Replace("@", Environment.NewLine);

            output = parser.DeepParse(deserialized, output);
            
            Assert.AreEqual(expectedOutput.ToString(), output.ToString());            
        }
        [TestMethod]
        public void ShouldParseNestedJsonStringAndPrintWithDepthWithCsharpObject()
        {
            NestedJsonParser parser = new NestedJsonParser();
            StringBuilder output = new StringBuilder();
            StringBuilder jsonBuilder = new StringBuilder();
            StringBuilder expectedOutput = new StringBuilder();
            Person personA = new Person("User", "1", null);
            Person personB = new Person("User", "2", personA);

            jsonBuilder.Append("{\"Key1\": \"1\",\"Key2\": {\"Key3\": \"1\",\"Key4\": {\"Key5\": \"4\", \"user\":user_placeholder}}}");
            jsonBuilder.Replace("user_placeholder", parser.Serialize(personB));

            var deserialized = parser.Deserialize(jsonBuilder.ToString()).Deserialized;
            expectedOutput.Append("Key1: 1@Key2: 1@Key3: 2@Key4: 2@Key5: 3@user: 3@");
            expectedOutput.Append("firstName: 4@lastName: 4@father: 4@firstName: 5@lastName: 5@father: 5@");
            expectedOutput.Replace("@", Environment.NewLine);

            output = parser.DeepParse(deserialized, output);

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }

    }
}
