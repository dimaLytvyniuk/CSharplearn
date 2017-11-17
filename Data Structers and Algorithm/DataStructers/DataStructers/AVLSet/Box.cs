using System;

namespace DataStructers.AVLSet
{
    class Box : IComparable 
    {
        public int data;

        public Box(int data)
        {
            this.data = data;
        }

        public Box()
        {
            data = 0;
        }
        public int CompareTo(object obj)
        {
            if (obj is Box)
            {
                Box box = (Box)obj;
                if (this.data < box.data)
                    return -1;
                else if (this.data == box.data)
                    return 0;
                else
                    return 1;
            }

            return -1;
        }
    }
}