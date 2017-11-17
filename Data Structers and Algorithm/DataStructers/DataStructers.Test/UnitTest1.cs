using System;
using Xunit;
using DataStructers.AVLSet;
using DataStructers.Heap;

namespace DataStructers.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestAVLSet()
        {
            AVLSet<int> avl;
            Random random = new Random();
            int n = random.Next(20);
            for (int i = 0; i < n; i++)
            {
                avl = new AVLSet<int>();
                int size = random.Next(100);
                for (int j = 0; j < size; j++)
                {
                    avl.Add(random.Next(10000));
                }
            }
        }

        [Fact]
        public void TestHeapSet()
        {
            HeapSet<int> heap;
            Random random = new Random();
            int n = random.Next(20);

            for (int i = 0; i < n; i++)
            {
                heap = new HeapSet<int>();
                int size = random.Next(1000);
                int[] massAssert = new int[size];
                for (int j = 0; j < size; j++)
                {
                    int tmp = random.Next(10000);
                    heap.Add(tmp);
                    massAssert[j] = tmp;
                }
                int[] massHeap = new int[size];
                for (int j = 0; i < size; i++)
                    massHeap[j] = heap.DeleteElement();
                
                Array.Sort(massAssert);
                Assert.Equal(massHeap, massAssert);
            }
        }
    }
}
