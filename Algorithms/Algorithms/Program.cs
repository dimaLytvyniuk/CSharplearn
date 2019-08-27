using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<List<int>>()
            {
                new List<int>() { 1, 2, 3},
                new List<int>() { 4, 5, 6},
                new List<int>() { 7, 8, 9},
            };

            var result = Arrays.antiDiagonal(list);
            foreach (var diag in result)
            {
                foreach (var val in diag)
                {
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
