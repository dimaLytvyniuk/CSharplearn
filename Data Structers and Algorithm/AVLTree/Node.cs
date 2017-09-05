using System;

namespace AVLTree
{
    class Node<T> where T: IComparable
    {
        public Node()
        {

        }

        public Node(T data, Node<T> right, Node<T> left, int height)
        {
            Data = data;
            Right = right;
            Left = left;
            Height = height;
        }
        public T Data { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Left { get; set; }
        public int Height{get; set;}
    }
}