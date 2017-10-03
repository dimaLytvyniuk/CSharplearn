using System;
using Xunit;
using SortMethod;

namespace Test
{
    public class UnitTest1
    {
        static Random random = new Random();

        [Fact]
        public void TestQuickSort()
        {
            int n = 10;
            int[] mass = new int[n];
            int[] massAssert = new int[n];
            for (int i = 0; i < n; i++)
            {
                int a = random.Next(n * 100);
                mass[i] = a;
                massAssert[i] = a;
            }

            Methods.QuickSort(mass, 0, n - 1);
            Array.Sort(massAssert);
            Assert.Equal(mass, massAssert);
        }

        [Fact]
        public void TestCountingSort()
        {
            int n = 10;
            int[] mass = new int[n];
            int[] massAssert = new int[n];
            for (int i = 0; i < n; i++)
            {
                int a = random.Next(n * 100);
                mass[i] = a;
                massAssert[i] = a;
            }

            Methods.CountingSort(mass, n * 100 - 1);
            Array.Sort(massAssert);
            Assert.Equal(mass, massAssert);
        }

        [Fact]
        public void TestCombSort()
        {
            int n = 1000;
            int[] mass = new int[n];
            int[] massAssert = new int[n];
            for (int i = 0; i < n; i++)
            {
                int a = random.Next(n * 100);
                mass[i] = a;
                massAssert[i] = a;
            }

            Methods.CombSort(mass);
            Array.Sort(massAssert);
            Assert.Equal(massAssert, mass);
        }
    }
}
