using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int count = 100000;
            int[] a = new int[count];

            for (int i = 0; i < count; i++)
                a[i] = random.Next(100000);

            for (int i = 0; i < count; i++)
                Console.Write(a[i] + " ");

            Methods.QuickSort(a, 0, count - 1);

            Console.WriteLine();

            for (int i = 0; i < count - 1; i++)
                Console.Write(a[i] + " ");
        }
    }
}
