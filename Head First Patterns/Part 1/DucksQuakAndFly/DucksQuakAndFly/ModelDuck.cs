using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DucksQuakAndFly
{
    class ModelDuck : Duck
    {
        public ModelDuck()
        {
            FlyBehaviorProperty = new FlyNoWay();
            QuackBehaviorProperty = new Quack();
        }

        public override void display()
        {
            Console.WriteLine("I'm a model duck");
        }
    }
}
