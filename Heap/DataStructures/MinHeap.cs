using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap.DataStructures
{
    public class MinHeap<T> : Heap<T> where T : IComparable<T>
    {
        protected override void ReArrangeOnInsert()
        {
            int elementIndex = _size - 1;
            T element = list[elementIndex];

            int parentIndex = GetParentIndex(elementIndex);
            T parent = GetParent(elementIndex);

            if (comparer.Compare(element, parent) == 0)
                return;

            while (comparer.Compare(element, parent) < 0)
            {
                Swap(elementIndex, parentIndex);

                elementIndex = parentIndex;
                parentIndex = GetParentIndex(elementIndex);
                parent = GetParent(elementIndex);
            }
        }

        protected override void ReArrangeOnDelete()
        {
            int elementIndex = 0;

            // We assume it's always a complete Binary Tree and will have this
            while (HasLeftChild(elementIndex))
            {
                var smallerIndex = GetLeftChildIndex(elementIndex);
                if (HasRightChild(elementIndex) && comparer.Compare(GetRightChild(elementIndex), GetLeftChild(elementIndex)) < 0)
                {
                    smallerIndex = GetRightChildIndex(elementIndex);
                }

                if (comparer.Compare(list[elementIndex], list[smallerIndex]) <= 0)
                {
                    break;
                }

                Swap(smallerIndex, elementIndex);
                elementIndex = smallerIndex;
            }
        }
    }
}
