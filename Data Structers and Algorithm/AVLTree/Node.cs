using System;

namespace AVLTree
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Right { get; set; }
        public Node<T> Left { get; set; }

        public int Height{get; set;}
    }
}