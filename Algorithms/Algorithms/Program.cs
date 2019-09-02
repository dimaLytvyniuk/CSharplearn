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
            
            var list = new List<int> { 5, 1, 3, 2, 4 };
            var result = Arrays.wave(list);

            foreach (var res in result)
            {
                Console.WriteLine(res);   
            }
        }
    }
}
