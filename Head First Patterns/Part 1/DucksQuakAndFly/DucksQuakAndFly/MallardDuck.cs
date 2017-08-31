using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DucksQuakAndFly
{
    class MallardDuck : Duck
    {
        public MallardDuck()
        {
            QuackBehaviorProperty = new Quack();
            FlyBehaviorProperty = new FlyWithWings();
        }

        public override void display()
        {
            Console.WriteLine("I'm a real Mallard duck");
        }
    }
}
