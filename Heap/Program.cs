using Heap.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class Program
    {
        static void Main(string[] args)
        {
            MinHeap<int> heap = new MinHeap<int>();
            heap.Add(10);
            heap.Add(16);
            heap.Add(30);
            heap.Add(20);
            heap.Add(50);
            heap.Add(15);
            heap.Add(8);

            while (!heap.IsEmpty)
            {
                Console.Write(heap.Pop() + " ");
            }

            EndProgram();
        }

        static void EndProgram()
        {
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("******* End of Program *******");
            System.Console.ReadLine();
        }
    }
}
