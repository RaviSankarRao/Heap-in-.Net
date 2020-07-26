using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap.DataStructures
{
    public class MaxHeap<T> : Heap<T> where T : IComparable<T>
    {
        // Heapify Up
        protected override void ReArrangeOnInsert()
        {
            // This is the last inserted element index
            int elementIndex = _size - 1;
            T element = _elements[elementIndex];

            int parentIndex = GetParentIndex(elementIndex);
            T parent = GetParent(elementIndex);

            if (comparer.Compare(element, parent) == 0)
                return;

            while (comparer.Compare(element, parent) > 0)
            {
                Swap(elementIndex, parentIndex);
                
                elementIndex = parentIndex;
                parentIndex = GetParentIndex(elementIndex);
                parent = GetParent(elementIndex);
            }
        }

        // Heapify Down
        protected override void ReArrangeOnDelete()
        {
            // After root pop, the last element was repalced with the root which is the smallest in the heap
            // Hence we start from '0' index
            int elementIndex = 0;

            // We assume it's always a complete Binary Tree and will have this
            while(HasLeftChild(elementIndex))
            {
                var biggerIndex = GetLeftChildIndex(elementIndex);
                if (HasRightChild(elementIndex) && comparer.Compare(GetRightChild(elementIndex), GetLeftChild(elementIndex)) > 0)
                {
                    biggerIndex = GetRightChildIndex(elementIndex);
                }

                if (comparer.Compare(_elements[elementIndex], _elements[biggerIndex]) >= 0)
                {
                    break;
                }

                Swap(biggerIndex, elementIndex);
                elementIndex = biggerIndex;
            }
        }
    }
}
