using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFly
{
    class Program
    {
        enum KindOfDuck
        {
            Mallard,
            Muscovy,
            Decoy,
        }

        class Bird
        {
            public virtual  string Name { get; set; }

            public virtual void Fly()
            {
                Console.WriteLine("Fly!Fly!");
            }

            public override string ToString()
            {
                return "Bird's Name " + Name;
            }
        }

        class Penguin : Bird
        {
            public override void Fly()
            {
                Console.WriteLine("We don't fly");
            }

            public override string ToString()
            {
                return "Penguin's Name " + base.Name;
            }
        }

        class Duck : Bird, IComparable <Duck>
        {
            public int Size;
            public KindOfDuck Kind;
                          
                public override string ToString()
            {
                return "Ducks " + Size.ToString() + " -дюймов" + Kind.ToString();
            }
            
            
            public int CompareTo(Duck duckToCompare)
            {
                if (this.Size > duckToCompare.Size)
                    return 1;
                else if (this.Size < duckToCompare.Size)
                    return -1;
                else
                    return 0;
            }
        }

        static void Main(string[] args)
        {
            List<Duck> ducks = new List<Duck>()
            {
                new Duck() {Kind=KindOfDuck.Mallard,Size=17 },
                new Duck() {Kind=KindOfDuck.Muscovy,Size=18 },
                new Duck() {Kind=KindOfDuck.Muscovy,Size=17 },
                new Duck() {Kind=KindOfDuck.Decoy,Size=14 },
                new Duck() {Kind=KindOfDuck.Muscovy,Size=11 },
                 new Duck() {Kind=KindOfDuck.Mallard,Size=14 },
                new Duck() {Kind=KindOfDuck.Mallard,Size=14 },
                new Duck() {Kind=KindOfDuck.Decoy,Size=13 },
            };

            IEnumerable<Bird> upcastDucks = ducks;

            List<Bird> birds = new List<Bird>();
            birds.Add(new Bird() { Name = "Пернатые" });
            birds.AddRange(upcastDucks);
            birds.Add(new Penguin() { Name = "Джордж" });

            foreach (Bird bird in birds)
                Console.WriteLine(bird);
            Console.ReadKey();
        }
    }
}
