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
            int y = 0;
        }
    }
}
