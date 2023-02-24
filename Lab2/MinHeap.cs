using System;
using System.Linq;

namespace Lab2
{
    public class MinHeap<T> where T : IComparable<T>
    {
        private T[] array;
        private const int initialSize = 8;

        public int Count { get; private set; }

        public int Capacity => array.Length;

        public bool IsEmpty => Count == 0;


        public MinHeap(T[] initialArray = null)
        {
            array = new T[initialSize];

            if (initialArray == null)
            {
                return;
            }

            foreach (var item in initialArray)
            {
                Add(item);
            }

        }

        /// <summary>
        /// Returns the min item but does NOT remove it.
        /// Time complexity: O(?).
        /// </summary>
        public T Peek()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            return array[0];
        }

        // DONE
        /// <summary>
        /// Adds given item to the heap.
        /// Time complexity: O(?).
        /// </summary>
        public void Add(T item)
        {
            int nextEmptyIndex = Count;

            array[nextEmptyIndex] = item;

            TrickleUp(nextEmptyIndex);

            Count++;

            // resize if full
            if (Count == Capacity)
            {
                DoubleArrayCapacity();
            }

        }

        public T Extract()
        {
            return ExtractMin();
        }

        // TODO
        /// <summary>
        /// Removes and returns the max item in the min-heap.
        /// Time complexity: O( N ).
        /// </summary>
        public T ExtractMax()
        {
            //if (IsEmpty)
            //{
            //    throw new Exception("Empty Heap");
            //}
            // linear search
            //T max = array[0];

            //return max;

            throw new NotImplementedException();
        }

        // DONE
        /// <summary>
        /// Removes and returns the min item in the min-heap.
        /// Time ctexity: O( log(n) ).
        /// </summary>
        public T ExtractMin()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            T min = array[0];

            // swap root (first) and last element
            Swap(0, Count - 1);

            // "remove" last
            Count--;

            // trickle down from root (first)
            TrickleDown(0);

            return min;
        }

        // Done
        /// <summary>
        /// Returns true if the heap contains the given value; otherwise false.
        /// Time complexity: O( N ).
        /// </summary>
        public bool Contains(T value)
        {
            // linear search

            foreach (var item in array)
            {
                if (item.CompareTo(value) == 0)
                {
                    return true;
                }
            }

            return false;

        }

        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleUp(int index)
        {
            while(index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (array[index].CompareTo(array[parentIndex]) == -1)
                { 
                    return;
                }

                else
                {
                    Swap(index, Count - 1);
                }
            }
            //throw new NotImplementedException();
        }

        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleDown(int index)
        {
            throw new NotImplementedException();
        }

        // DONE
        /// <summary>
        /// Gives the position of a node's parent, the node's position in the heap.
        /// </summary>
        private static int Parent(int position)
        {
            int parentIndex = (position - 1) / 2;
            return parentIndex;
        }

        // DONE
        /// <summary>
        /// Returns the position of a node's left child, given the node's position.
        /// </summary>
        private static int LeftChild(int position)
        {
            int leftChild = 2 * position + 1;
            return leftChild;
        }

        // DONE
        /// <summary>
        /// Returns the position of a node's right child, given the node's position.
        /// </summary>
        private static int RightChild(int position)
        {
            int rightChild = 2 * position + 2;
            return rightChild;
        }

        private void Swap(int index1, int index2)
        {
            var temp = array[index1];

            array[index1] = array[index2];
            array[index2] = temp;
        }

        private void DoubleArrayCapacity()
        {
            Array.Resize(ref array, array.Length * 2);
        }


    }
}


