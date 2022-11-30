using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter_
{
    public class model
    {
        public string name;
        public int age;
        public string[] pets;
        public model(string name, int age, string[] pets)
        {
            this.name = name;
            this.age = age;
            this.pets = pets;
        }

        public model()
        {

        }
    }
}
