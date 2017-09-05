using System;

namespace AVLTree
{
    class Node<T>
    {
        public Node()
        {

        }

        public Node(IComparable data, Node<T> right, Node<T> left, int height)
        {
            Data = data;
            Right = right;
            Left = left;
            Height = height;
        }
        public IComparable Data { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Left { get; set; }
        public int Height{get; set;}
    }
}