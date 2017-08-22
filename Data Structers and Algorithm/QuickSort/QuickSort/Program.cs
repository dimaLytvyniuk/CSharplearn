using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int count = 10;
            int[] a = new int[count];

            for (int i = 0; i < count; i++)
                a[i] = random.Next(10);

            for (int i = 0; i < count; i++)
                Console.Write(a[i] + " ");

            Methods.Sort(a, 0, count - 1);

            Console.WriteLine();

            for (int i = 0; i < count; i++)
                Console.Write(a[i] + " ");
        }
    }
}
