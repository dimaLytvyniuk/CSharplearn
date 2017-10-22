using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructers.AVLSet
{
    public class AVLSet<T> : ISet<T> where T: IComparable
    {
        private int _size;
        private int _height;
        public int Count { get { return _size; } }
        public int Height { get { return _height; }  }

        private Node<T> _head;

        public bool IsReadOnly => false;


        public bool Add(T item)
        {
            _head = AVLTreeInsert(_head, item);
            return true;
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

        private Node<T> AVLTreeInsert(Node<T> root, T data) 
        {
            if (root == null)
            {
                root = new Node<T>(data, null, null, 0);
            }
            else if (data.CompareTo(root.Data) < 0)
            {
                root.Left = AVLTreeInsert(root.Left, data);
                if ((HeightOfTree(root.Left) - HeightOfTree(root.Right)) == 2)
                {
                    if (data.CompareTo(root.Left.Data) < 0)
                        root = SingleRotateLeft(root);
                    else
                        root = DoubleRotateLR(root);
                }
            }
            else if (data.CompareTo(root.Data) > 0)
            {
                root.Right = AVLTreeInsert(root.Right, data);
                if ((HeightOfTree(root.Right) - HeightOfTree(root.Left)) == 2)
                {
                    if (data.CompareTo(root.Right.Data) > 0)
                        root = SingleRotateRight(root);
                    else
                        root = DoubleRotateRL(root);
                }            
            }

            root.Height = Max(HeightOfTree(root.Left), HeightOfTree(root.Right)) + 1;
            return root;
        }

        private static int HeightOfTree(Node<T> root)
        {
            /* 
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
            */
            if (root == null)
                return -1;
            
            return root.Height;
        }

        private static Node<T> SingleRotateLeft(Node<T> node)
        {
            Node<T> leftNode = node.Left;
            node.Left = leftNode?.Right;
            leftNode.Right = node;
            node.Height = Max(HeightOfTree(node.Left), HeightOfTree(node.Right)) + 1;
            leftNode.Height = Max(HeightOfTree(leftNode?.Left), node.Height) + 1;
            return leftNode; 
        }

        private static Node<T> SingleRotateRight(Node<T> node)
        {
            Node<T> rightNode = node.Right;
            node.Right = rightNode?.Left;
            rightNode.Left = node;
            node.Height = Max(HeightOfTree(node.Left), HeightOfTree(node.Right)) + 1;
            rightNode.Height = Max(node.Height, HeightOfTree(rightNode?.Right)) + 1;
            return rightNode;
        }

        //DoubleRotateLeft
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