using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogCanine
{
    struct Dog
    {
        public string Name;
        public string Breed;

        public Dog(string Name, string Breed)
        {
            this.Name = Name;
            this.Breed = Breed;
        }

        public void Speak()
        {
            Console.WriteLine("My name is {0} and I {1}", Name, Breed);
        }
    }

    class Canine
    {
        public string Name;
        public string Breed;

        public Canine(string Name, string Breed)
        {
            this.Name = Name;
            this.Breed = Breed;
        }

        public void Speak()
        {
            Console.WriteLine("My name is {0} and I {1}", Name, Breed);
        }
    }
}
