using System;

namespace Lab2
{
	public class MaxHeap<T> where T: IComparable<T>
	{
        private T[] array;
        private const int initialSize = 8;

        public int Count { get; private set; }

        public int Capacity => array.Length;

        public bool IsEmpty => Count == 0;


        public MaxHeap(T[] initialArray = null)
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
            return ExtractMax();
        }

        // DONE
        /// <summary>
        /// Removes and returns the min item in the max-heap.
        /// Time complexity: O( N ).
        /// </summary>
        public T ExtractMax()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }

            T max = array[0];

            // swap root (first) and last element
            Swap(0, Count - 1);

            // "remove" last
            Count--;

            // trickle down from root (first)
            TrickleDown(0);

            return max;

        }

        // TODO
        /// <summary>
        /// Removes and returns the max item in the max-heap.
        /// Time ctexity: O( log(n) ).
        /// </summary>
        public T ExtractMin()
        {
            // confused
            //if (IsEmpty)
            //{
            //    throw new Exception("Empty Heap");
            //}
            // linear search
            //T min = array[0];

            //return min;
            throw new NotImplementedException();
        }

        // DONE
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
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (array[index].CompareTo(array[parentIndex]) == -1)
                {
                    return;
                }

                else
                {
                    Swap(index, parentIndex);

                    index = parentIndex;
                }
            }

        }

        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleDown(int index)
        {
            while (index > 0)
            {
                int childIndex = 2 * index + 1;
                int value = index;

                while (array[childIndex].CompareTo(array[Capacity]) == 0)
                {
                    int maxValue = value;
                    int maxIndex = -1;
                    int i = 0;
                    while (i < maxValue)
                    {
                        if(i < 2 && i + childIndex < array.Length)
                        //if (array[i + childIndex].CompareTo(array[childIndex + i]) == 0)
                        {
                            maxValue = childIndex + i;
                            maxIndex = i + childIndex;
                        }
                        i++;
                    }
                    if (maxValue == value)
                    {
                        return;
                    }
                    else
                    {
                        Swap(index, maxIndex);

                        index = maxIndex;
                        childIndex = 2 * index + 1;
                    }
                }

            }

            //throw new NotImplementedException();
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

