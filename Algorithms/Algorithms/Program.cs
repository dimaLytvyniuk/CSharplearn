using System;
using System.Collections.Generic;
using System.Numerics;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var result = Arrays.MaxArea(array);
            Console.WriteLine(result); 
        }
    }
}
