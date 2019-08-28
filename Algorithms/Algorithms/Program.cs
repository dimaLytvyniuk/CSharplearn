using System;
using System.Collections.Generic;
using System.Numerics;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> {336465782, -278722862, -2145174067, 1101513929, 1315634022, -1369133069, 1059961393, 628175011, -1131176229, -859484421};
            
            var result = Arrays.maxNonNegativeSubarray(list);
            foreach (var val in result)
            {
                Console.WriteLine(val);
            }

            var value1 = 1101513929;
            var value2 = 1315634022;
            long sum = 1101513929;
            sum += value2;
            
            Console.WriteLine(sum + " ");
        }
    }
}
