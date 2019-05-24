using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
