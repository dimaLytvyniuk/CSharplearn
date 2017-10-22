using System;
using Xunit;
using DataStructers.AVLSet;

namespace DataStructers.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestAVLSet()
        {
            AVLSet<int> avl = new AVLSet<int>();
            Random random = new Random();
            int n = random.Next(20);
            for (int i = 0; i < n; i++)
            {
                int size = random.Next(100);
                for (int j = 0; j < size; j++)
                {
                    avl.Add(random.Next(10000));
                }
            }
        }
    }
}
