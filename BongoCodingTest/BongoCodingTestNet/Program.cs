using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
namespace BongoCodingTestNet
{
    public class Program
    {   
        static void Main(string[] args)
        {
            try
            {
                NestedJsonParser parser = new NestedJsonParser();
                StringBuilder jsonBuilder = new StringBuilder();

                Person personA = new Person("User", "1", null);
                Person personB = new Person("User", "2", personA);

                jsonBuilder.Append("{\"Key1\": \"1\",\"Key2\": {\"Key3\": \"1\",\"Key4\": {\"Key5\": \"4\", \"user\":user_placeholder}}}");
                jsonBuilder.Replace("user_placeholder", parser.Serialize(personB));

                parser.Deserialize(jsonBuilder.ToString())
                      .Print();

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

                int n1, n2, lca;
                string userInput = "user input";
                while (!string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Press enter to exit");
                    Console.WriteLine("To find LCA insert two node value seperated by space");
                    userInput = Console.ReadLine();
                    if (!string.IsNullOrEmpty(userInput))
                    {
                        var inputs = userInput.Split(' ');
                        n1 = int.Parse(inputs[0]);
                        n2 = int.Parse(inputs[1]);
                        lca = LCA(nodes.Find(node => node.Value == n1), nodes.Find(node => node.Value == n2));
                        Console.WriteLine("LCA : {0}", lca);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hope you enjoyed!");
                Console.Beep(1000, 100);                
                Thread.Sleep(1000);
            }
            
        }

        public static int LCA(Node node1, Node node2)
        {
            try
            {
                // check if one of them is root node
                if (node1.Parent == null)
                    return node1.Value;
                if (node2.Parent == null)
                    return node2.Value;
                // check if they have same parent
                if (node1.Parent.Value == node2.Parent.Value)
                    return node2.Parent.Value;
                // check if either one of them is parent of another
                if (node1.Parent.Value == node2.Value)
                    return node2.Value;
                if (node2.Parent.Value == node1.Value)
                    return node1.Value;
                // recurse until found
                return LCA(node1.Parent, node2.Parent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
