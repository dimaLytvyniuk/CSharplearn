using System;
using System.Collections.Generic;
using System.Numerics;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 3, 4, 1, 4, 1 };
            var result = Arrays.repeatedNumber(list);
            Console.WriteLine(result); 
        }
    }
}
