using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BongoCodingTestNet
{
    public class Node
    {
        private int _value;
        private Node _parent;
        public Node(int value, Node parent)
        {
            this._value = value;
            this._parent = parent;
        }

        public int Value => _value;
        public Node Parent => _parent;
    }
    public class LeastCommonAncestor
    {
        static void Main(string[] args)
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

            int n1 = 6;
            int n2 = 7;
            int lca = LCA(nodes.Find(x => x.Value == n1), nodes.Find(x => x.Value == n2));
            Console.WriteLine(lca);
            Console.ReadLine();
        }

        public static int LCA(Node node1, Node node2)
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
        
    }
}
