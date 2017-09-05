using System;
using System.Collections;
using System.Collections.Generic;

namespace AVLTree
{
    class AVLSet<T> : ISet<T> 
    {
        private int _size;
        private int _height;
        public int Count { get { return _size; } }
        public int Height { get { return _height; }  }

        private Node<T> _head;

        public bool IsReadOnly => false;


        public bool Add(T item)
        {

            return false;
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private Node<T> AVLTreeInsert(Node<T> root, IComparable data) 
        {
            if (root == null)
            {
                root = new Node<T>(data, null, null, 0);
            }
            else if (data.CompareTo(root.Data) < 0)
            {
                root.Left = av
            }
        }

        private static int HeightOfTree(Node<T> root)
        {
            int leftHeight;
            int rightHeight;

            if (root == null)
                return 0;

            leftHeight = HeightOfTree(root.Left);
            rightHeight = HeightOfTree(root.Right);

            if (leftHeight > rightHeight)
                return ++leftHeight;
            else
                return ++rightHeight;
            
        }

        private static Node<T> SingleRotateLeft(Node<T> node)
        {
            Node<T> leftNode = node.Left;
            node.Left = leftNode.Right;
            leftNode.Right = node;
            node.Height = Max(HeightOfTree(node.Left), HeightOfTree(node.Right)) + 1;
            leftNode.Height = Max(HeightOfTree(leftNode.Left), node.Height) + 1;
            return leftNode; 
        }

        private static Node<T> SingleRotateRight(Node<T> node)
        {
            Node<T> rightNode = node.Right;
            node.Right = rightNode.Left;
            rightNode.Left = node;
            node.Height = Max(HeightOfTree(node.Left), HeightOfTree(node.Right)) + 1;
            rightNode.Height = Max(node.Height, HeightOfTree(rightNode.Right)) + 1;
            return rightNode;
        }

        private static Node<T> DoubleRotateLR(Node<T> node)
        {
            node.Left = SingleRotateRight(node.Left);
            return SingleRotateLeft(node);
        }

        private static Node<T> DoubleRotateRL(Node<T> node)
        {
            node.Right = SingleRotateLeft(node.Right);
            return SingleRotateRight(node); 
        }
        private static int Max(int x, int y)
        {
            return x > y ? x : y;
        }
    }
}