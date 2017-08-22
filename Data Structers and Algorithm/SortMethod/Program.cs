using System;

namespace SortMethod
{
    class Program
    {
        static void Main(string[] args)
        {
                       Random random = new Random();

            int count = 10;
            int[] a = new int[count];

            for (int i = 0; i < count; i++)
                a[i] = random.Next(11);

            for (int i = 0; i < count; i++)
                Console.Write(a[i] + " ");

            //Methods.QuickSort(a, 0, count - 1);
            Methods.CountingSort(a, 10);
            Console.WriteLine();

            for (int i = 0; i < count; i++)
                Console.Write(a[i] + " ");

            Console.WriteLine();
        }
    }
}
