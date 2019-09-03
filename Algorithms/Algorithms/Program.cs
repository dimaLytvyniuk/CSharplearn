using System;
using System.Collections.Generic;
using System.Numerics;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new[] {0, 4, 3, 0};

            var result = Arrays.TwoSum(array, 0);
            foreach (var res in result)
            {
                Console.WriteLine(res);   
            }
        }
    }
}
