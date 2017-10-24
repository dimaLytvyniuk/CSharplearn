using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructers.Heap
{
    public class HeapSet<T> : ISet<T> where T : IComparable
    {
        private T[] _array;
        private int _capacity;
        private readonly HeapType typeOfHeap;
        public HeapType TypeOfHeap { get => typeOfHeap; }
        public int Count { get; private set; } = 0;

        public bool IsReadOnly => false;

        public HeapSet()
        {
            _capacity = 10;
            _array = new T[_capacity];
            typeOfHeap = HeapType.MaxHeap;
        }

        public HeapSet(int capacity, HeapType heapType)
        {
            if (capacity < 1)
                throw new ArgumentOutOfRangeException();

            _capacity = capacity;
            _array = new T[_capacity];
            typeOfHeap = heapType;
        }

        private int Parent(int i)
        {
            if (i <= 0 || i >= Count)
                return -1;

            return (i - 1) / 2;
        }

        private int LeftChild(int i)
        {
            int left = 2 * i + 1;
            if (left >= Count)
                return -1;

            return left;
        }

        private int RightChild(int i)
        {
            int right = 2 * i + 2;
            if (right >= Count)
                return -1;

            return right;
        }

        public int GetMax()
        {
            throw new NotImplementedException();
        }

        public int GetMin()
        {
            throw new NotImplementedException();
        }

        private void PrecolateDown(int i)
        {
            if (typeOfHeap == HeapType.MaxHeap)
                PrecolateDownMax(i);
            else
                PrecolateDownMin(i);
        }

        private void PrecolateDownMax(int i)
        {
            int left;
            int max;
            int right;

            left = LeftChild(i);
            right = RightChild(i);

            if (left != -1 && _array[left].CompareTo(_array[i]) > 0)
                max = left;
            else
                max = i;
            
            if (right != -1 && _array[right].CompareTo(_array[max]) > 0)
                max = right;

            if (max != i)
            {
                T temp = _array[i];
                _array[i] = _array[max];
                _array[max] = temp;
                PrecolateDownMin(max);
            }
        }

        private void PrecolateDownMin(int i)
        {
            int left;
            int right;
            int min;

            left = LeftChild(i);
            right = RightChild(i);

            if (left != -1 && _array[left].CompareTo(_array[i]) < 0)
                min = left;
            else
                min = i;

            if (right != -1 && _array[right].CompareTo(_array[min]) < 0)
                min = right;
            
            if (min != i)
            {
                T temp = _array[i];
                _array[i] = _array[min];
                _array[min] = temp;
                PrecolateDownMin(min);
            }
        }

        public T DeleteElement()
        {
            if (Count == 0)
                throw new ArgumentNullException();

            T data = _array[0];
            _array[0] = _array[--Count];
            PrecolateDown(0);
            return data;
        }

        private void InsertMax(T data)
        {
            if (Count == _capacity)
                ResizeHeap();
            int i = Count++;

            while (i > 0 && data.CompareTo(_array[(i - 1) / 2]) > 0)
            {
                _array[i] = _array[Parent(i)];
                i = Parent(i);
            }

            _array[i] = data;
        }

        private void InsertMin(T data)
        {
            if (Count == _capacity)
                ResizeHeap();
            int i = Count++;

            while (i > 0 && data.CompareTo(_array[Parent(i)]) < 0)
            {
                _array[i] = _array[Parent(i)];
                i = Parent(i);
            }

            _array[i] = data;
        }

        private void ResizeHeap()
        {
            int newSize = _capacity + (int)(_capacity * 0.3);
            T[] promArray = new T[_capacity];
            Array.Copy(_array, promArray, _capacity);
            _array = new T[newSize];
            Array.Copy(promArray, promArray, _capacity);
            _capacity = newSize;
        }

        public bool Add(T item)
        {
            if (typeOfHeap == HeapType.MaxHeap)
                InsertMax(item);
            else 
                InsertMin(item);

            return true;
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

        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
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

        public bool Remove(T item)
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public enum HeapType
    {
        MaxHeap,
        MinHeap
    }
}