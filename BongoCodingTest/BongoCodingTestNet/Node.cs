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
}
