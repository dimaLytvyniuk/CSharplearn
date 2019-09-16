using System;
using System.Collections.Generic;
using System.Numerics;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 0, 0, 0, 0, 0 };
            var result = Arrays.largestNumber(list);
            
            Console.WriteLine(result); 
        }
    }
}
