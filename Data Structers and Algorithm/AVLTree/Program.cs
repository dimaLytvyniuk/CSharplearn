using System;

namespace AVLTree
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLSet<Box> avlSet = new AVLSet<Box>();
            avlSet.Add(new Box(5));
            avlSet.Add(new Box(6));
            avlSet.Add(new Box(4));
            avlSet.Add(new Box(7));
            avlSet.Add(new Box(8));
            avlSet.Add(new Box(9));
            avlSet.Add(new Box(30));
            avlSet.Add(new Box(20));
            avlSet.Add(new Box(15));
            avlSet.Add(new Box(17));
            avlSet.Add(new Box(2));
            avlSet.Add(new Box(3));


            Random random = new Random();

            for (int i = 0; i < 100; i++)
                avlSet.Add(new Box(random.Next(1000)));
                
            int y = 0;
        }
    }
}
