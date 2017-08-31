using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DucksQuakAndFly
{
    abstract class Duck
    {
        public Duck()
        {

        }

        public abstract void display();

        public void performFly()
        {
            FlyBehaviorProperty.fly();
        }

        public void performQuack()
        {
            QuackBehaviorProperty.quack();
        }

        public void swim()
        {
            Console.WriteLine("All ducks float, even decoys!");
        }

        public FlyBehavior FlyBehaviorProperty { get; set; }

        public QuackBehavior QuackBehaviorProperty { get; set; }
            
    }
}
