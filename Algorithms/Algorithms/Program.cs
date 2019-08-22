using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var len = Arrays.coverPointsBestSolution(new List<int> {4, 8, -7, -5, -13, 9, -7, 8}, new List<int> {4, -15, -10, -3, -13, 12, 8, -8});
            Console.WriteLine(len);
        }
    }
}