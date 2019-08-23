using System;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Arrays.pascalTriangle(5);

            foreach (var list in result)
            {
                foreach (var item in list)
                {
                   Console.Write(item + " "); 
                }
                Console.WriteLine();
            }
        }
    }
}