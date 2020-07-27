using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap.DataStructures
{
    /*
        Heap implementation in .Net using C#
        This uses an array as heap implementation
     */
    public abstract class Heap<T> where T : IComparable<T>
    {
        protected List<T> _elements;
        protected int _size;

        protected IComparer<T> comparer;

        public Heap()
        {
            _elements = new List<T>();
            comparer = Comparer<T>.Default;
        }

        public Heap(IComparer<T> comparer)
        {
            _elements = new List<T>();
            this.comparer = comparer;
        }

        public int GetParentIndex(int elementIndex) => (elementIndex - 1) / 2;

        public int GetLeftChildIndex(int elementIndex) => 2 * elementIndex + 1;

        public int GetRightChildIndex(int elementIndex) => 2 * elementIndex + 2;

        public T GetLeftChild(int elementIndex) => _elements[GetLeftChildIndex(elementIndex)];

        public T GetRightChild(int elementIndex) => _elements[GetRightChildIndex(elementIndex)];

        public T GetParent(int elementIndex) => _elements[GetParentIndex(elementIndex)];

        public bool IsRoot(int elementIndex) => elementIndex == 0;

        public bool HasLeftChild(int elementIndex) => GetLeftChildIndex(elementIndex) < _size;

        public bool HasRightChild(int elementIndex) => GetRightChildIndex(elementIndex) < _size;
        
        public int Count => _elements.Count();

        public bool IsEmpty => _size == 0;

        public T Peek()
        {
            if (_elements.Count() == 0)
                throw new IndexOutOfRangeException("Heap is empty");

            return _elements[0];
        }

        public void Add(T element)
        {
            // Always insert at the last known index to maintain 
            //  - Continuity
            //  - Keep the heap as valid Complete Binary Tree
            _elements.Add(element);
            _size++;

            // The heap has to be rearranged to maintain it's property of either Min/Max heap
            ReArrangeOnInsert();
        }

        public T Pop()
        {
            if (_size == 0)
                throw new IndexOutOfRangeException("Heap is empty");

            // The best place to pop a heap is always the root element
            var result = _elements[0];

            // The last element is set made the root so that the heap remains a Complete Binary Tree
            _elements[0] = _elements[_size - 1];
            _elements.RemoveAt(_size - 1);
            _size--;

            // The heap has to be rearranged to maintain it's property of either Min/Max heap
            ReArrangeOnDelete();

            return result;
        }

        protected void Swap(int firstIndex, int secondIndex)
        {
            var temp = _elements[firstIndex];
            _elements[firstIndex] = _elements[secondIndex];
            _elements[secondIndex] = temp;
        }

        protected abstract void ReArrangeOnInsert();

        protected abstract void ReArrangeOnDelete();
    }
}
