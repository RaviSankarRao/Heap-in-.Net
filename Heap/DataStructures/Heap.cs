using System;
using System.Collections.Generic;
using System.Linq;

namespace Heap.DataStructures
{
    /*
        Heap implementation in .Net using C#
        This uses an array as heap implementation
     */
    public abstract class Heap<T> where T : IComparable<T>
    {
        protected List<T> list;
        protected int _size;

        protected IComparer<T> comparer;

        public Heap()
        {
            list = new List<T>();
            comparer = Comparer<T>.Default;
        }

        public Heap(IComparer<T> comparer)
        {
            list = new List<T>();
            this.comparer = comparer;
        }

        /*
            For a given index i
                - Left child is at 2i
                - Right child is at 2i + 1
                - Parent is at i/2 floor value

            Since in programming laguages index starts from 0,
                - Left and right child positions are increamented by 1
                - Parent decreased by 1 
            to save us from checking exceptions
        */
        protected int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;
        protected int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;
        protected int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;

        protected T GetLeftChild(int elementIndex) => list[GetLeftChildIndex(elementIndex)];
        protected T GetRightChild(int elementIndex) => list[GetRightChildIndex(elementIndex)];
        protected T GetParent(int elementIndex) => list[GetParentIndex(elementIndex)];

        protected bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;
        protected bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;

        public int Count => list.Count();

        public bool IsEmpty => _size == 0;

        public T Peek()
        {
            if (list.Count() == 0)
                throw new IndexOutOfRangeException("Heap is empty");

            return list[0];
        }

        public void Add(T element)
        {
            // Always insert at the last known index to maintain 
            //  - Continuity
            //  - Keep the heap as valid Complete Binary Tree
            list.Add(element);
            _size++;

            // The heap has to be rearranged to maintain it's property of either Min/Max heap
            ReArrangeOnInsert();
        }

        public T Pop()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException("Heap is empty");

            // The best place to pop a heap is always the root element
            var result = list[0];

            // The last element is set made the root so that the heap remains a Complete Binary Tree
            list[0] = list[_size - 1];
            list.RemoveAt(_size - 1);
            _size--;

            // The heap has to be rearranged to maintain it's property of either Min/Max heap
            ReArrangeOnDelete();

            return result;
        }

        protected void Swap(int firstIndex, int secondIndex)
        {
            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        protected abstract void ReArrangeOnInsert();

        protected abstract void ReArrangeOnDelete();
    }
}
