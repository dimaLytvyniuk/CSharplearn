using System;
using System.Collections.Generic;
using System.Numerics;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 2, 3, 4 };

            var variants = Arrays.GetCircleValues(list);

            for (var i = 0; i < variants.GetLength(0); i++)
            {
                for (var j = 0; j < variants.GetLength(1); j++)
                {
                    Console.Write($"{variants[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
