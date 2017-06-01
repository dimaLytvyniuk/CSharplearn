using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AboutInterface
{


    class TallGuy : IClown
    {
        public string Name;
        public int Height;

        public void TalkAboutYourself()
        {
            Console.WriteLine("My name is " + Name + " and I'm " + Height + " inches tall.");
        }

        public string FunnyThingIHave
        {
            get { return "большие ботинки"; }
        }

        public void Honk()
        {
            Console.WriteLine("Honk honk!");
        }
    }


    interface IClown
    {
        void Honk();
        string FunnyThingIHave { get; } 
    }


    interface IScaryClown : IClown
    {
        string ScaryThingIHave { get; }
        void ScareLittleChildren();
    }


    class FunnyFunny : IClown
    {
        protected string funnyThingIHave;

        public FunnyFunny(string funnyThingIHave)
        {
            this.funnyThingIHave = funnyThingIHave;
        }

        public string FunnyThingIHave
        {
            get
            {
                return "Привет у меня есть " + funnyThingIHave;
            }
        }

        public void Honk()
        {
            Console.WriteLine(this.FunnyThingIHave);
        }
    }


    class ScaryScary : FunnyFunny, IScaryClown
    {
        public ScaryScary(int numberOfScaryThings, string funnyThingIHave) : base(funnyThingIHave)
        {
            this.numberOfScaryThings = numberOfScaryThings;

        }

        private int numberOfScaryThings;

        public string ScaryThingIHave
        {
            get { return  " У меня " + numberOfScaryThings + " пауков"; }
        }

        public void ScareLittleChildren()
        {
            Console.WriteLine("Ты не можешь забрать " + base.funnyThingIHave);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            TallGuy tallGuy = new TallGuy { Height = 74, Name = "Jimmy" };
            tallGuy.TalkAboutYourself();
            tallGuy.Honk();
            Console.WriteLine(tallGuy.FunnyThingIHave);

            ScaryScary fingersTheClown = new ScaryScary(14, "big shoes");
            FunnyFunny someFunnyClown = fingersTheClown;
            IScaryClown someOtherScaryClown = someFunnyClown as ScaryScary;
            someOtherScaryClown.Honk();
            Console.ReadKey();
        }
    }
}
