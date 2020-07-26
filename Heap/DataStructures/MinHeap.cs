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
            // TO DO
        }

        protected override void ReArrangeOnDelete()
        {
            // TO DO
        }
    }
}
