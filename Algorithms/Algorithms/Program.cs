using System;
using System.Collections.Generic;
using System.Numerics;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 2, 4, 6};
            var hamingDistance = MathTasks.hammingDistanceWithoutTuples(list);
            Console.WriteLine(hamingDistance);
        }
    }
}
