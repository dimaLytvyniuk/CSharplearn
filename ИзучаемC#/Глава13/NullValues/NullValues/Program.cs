using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input your birthday: ");
            string birthday = Console.ReadLine();
            Console.Write("Input your height: ");
            string height = Console.ReadLine();
            RobustGuy guy = new RobustGuy(birthday, height);
            Console.WriteLine(guy);
            Console.ReadKey();

            OrdinaryHuman steve = new OrdinaryHuman(185);
            Console.WriteLine(steve.BreakWalls(100.890));
        }
    }

    class RobustGuy
    {
        public DateTime? Birthday { get; private set; }
        public int? Height { get; private set; }

        public RobustGuy(string birthday, string height)
        {
            DateTime tempDate;
            if (DateTime.TryParse(birthday, out tempDate))
                Birthday = tempDate;
            else
                Birthday = null;

            int tempInt;
            if (int.TryParse(height, out tempInt))
                Height = tempInt;
            else
                Height = null;
        }

        public override string ToString()
        {
            string description;
            if (Birthday.HasValue)
                description = "I was born " + Birthday.Value.ToLongDateString();
            else
                description = "I dunno when I was born";

            if (Height.HasValue)
                description += ", my height was " + Height + "inch";
            else
                description += ", I dunno my height";

            return description;
        }
    }

    sealed class OrdinaryHuman
    {
        private int age;
        public int weight;

        public OrdinaryHuman(int weight)
        {
            this.weight = weight;
        }

        public void GoToWork()
        {
            Console.WriteLine("I'm going to work");
        }
    }

    static class SuperSoldier
    {
        public static string BreakWalls(this OrdinaryHuman h, double wallDestiny)
        {
            return "I'm brick int the wall " + wallDestiny;
        }
    }
}
