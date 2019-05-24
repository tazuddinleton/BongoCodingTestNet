using System;
using System.Collections.Generic;
using System.Text;
using BongoCodingTestNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBongoCodingTestNet
{
    [TestClass]
    public class TestCases
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

            parser.GenerateOuput(deserialized, output);
            
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

            parser.GenerateOuput(deserialized, output);

            Assert.AreEqual(expectedOutput.ToString(), output.ToString());
        }
        [TestMethod]
        public void ShouldFindLeastCommonAncestor()
        {
            // prepare the tree structure
            Node root = new Node(1, null);
            Node node_2 = new Node(2, root);
            Node node_3 = new Node(3, root);
            Node node_4 = new Node(4, node_2);
            Node node_5 = new Node(5, node_2);
            Node node_6 = new Node(6, node_3);
            Node node_7 = new Node(7, node_3);
            Node node_8 = new Node(8, node_4);
            Node node_9 = new Node(9, node_4);
            // prepare the list of nodes
            List<Node> nodes = new List<Node>();
            nodes.Add(root);
            nodes.Add(node_2);
            nodes.Add(node_3);
            nodes.Add(node_4);
            nodes.Add(node_5);
            nodes.Add(node_6);
            nodes.Add(node_7);
            nodes.Add(node_8);
            nodes.Add(node_9);
            // scenerio 1
            int n1 = 8;
            int n2 = 9;
            int expectedOutput = 4;
            int lca = Program.FindLCA(nodes.Find(x => x.Value == n1), nodes.Find(x => x.Value == n2));
            Assert.AreEqual(expectedOutput, lca);
            // scenerio 2
            n1 = 8;
            n2 = 5;
            expectedOutput = 2;
            lca = Program.FindLCA(nodes.Find(x => x.Value == n1), nodes.Find(x => x.Value == n2));
            Assert.AreEqual(expectedOutput, lca);
            // scenerio 3
            n1 = 9;
            n2 = 6;
            expectedOutput = 1;
            lca = Program.FindLCA(nodes.Find(x => x.Value == n1), nodes.Find(x => x.Value == n2));
            Assert.AreEqual(expectedOutput, lca);
            // scenerio 4
            n1 = 3;
            n2 = 6;
            expectedOutput = 3;
            lca = Program.FindLCA(nodes.Find(x => x.Value == n1), nodes.Find(x => x.Value == n2));
            Assert.AreEqual(expectedOutput, lca);
            // scenerio 5
            n1 = 1;
            n2 = 1;
            expectedOutput = 1;
            lca = Program.FindLCA(nodes.Find(x => x.Value == n1), nodes.Find(x => x.Value == n2));
            Assert.AreEqual(expectedOutput, lca);
        }
    }
}
