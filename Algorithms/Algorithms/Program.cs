using System;
using System.Collections.Generic;
using System.Numerics;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var val1 = 4_894_672;
            var val2 = 16_962_742;
            
            var list = new List<int> { 10 };
            var result = Arrays.maximumGap(list);
            Console.WriteLine(result);
        }
    }
}
