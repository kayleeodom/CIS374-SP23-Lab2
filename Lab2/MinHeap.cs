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
        /// Time complexity: O(1).
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
        /// Time complexity: O(log(n)).
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
        /// Time complexity: O( N )
        /// </summary>
        public T ExtractMax()
        {
            if (IsEmpty)
            {
                throw new Exception("Empty Heap");
            }
            // linear search
            T max = array[0];

            for(int i = 1; i < array.Length; i++)
            {
                max = array[i];
            }

            return max;

            //throw new NotImplementedException();
        }

        // DONE
        /// <summary>
        /// Removes and returns the min item in the min-heap.
        /// Time complexity: O( log(n) )
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
        /// Time complexity: O( N )
        /// </summary>
        public bool Contains(T value)
        {
            // linear search

            for (int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    return true;
                }
            }

            return false;

        }

        // TODO
        /// <summary>
        /// Updates the first element with the given value from the heap.
        /// Time complexity: O( ? )
        /// </summary>
        public void Update(T oldValue, T newValue)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                if (array[i].CompareTo(oldValue) == 0)
                {
                    Update(oldValue, newValue);
                    Remove(oldValue);
                    if (newValue.CompareTo(oldValue) == 1)
                    {
                        TrickleUp(i);
                    }
                    else
                    {
                        TrickleDown(i);
                    }

                }
                
            }
        }

        // TODO
        /// <summary>
        /// Removes the first element with the given value from the heap.
        /// Time complexity: O(log(n))
        /// </summary>
        public void Remove(T value)
        {
            

            for (int i = 0; i < Count - 1; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    Swap(i, Count - 1);
                    //array[i] = array[Count - 1];
                    i = Count - 1;
                    Count--;
                    TrickleDown(i);
                    break;
                    //Remove(value);
                }
                //else
                //{ throw new Exception(); }
                //throw new Exception();
            }
            //throw new Exception();
        }

        // TODO
        // Time Complexity: O( log(n) )
        private void TrickleUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = Parent(index);


                if (array[index].CompareTo(array[parentIndex]) == 1)
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
            int childIndex = LeftChild(index);
            T value = array[index];

            while (childIndex < Count)
            {
                T maxValue = value;
                int maxIndex = -1;
                int i = 0;
                while (i < 2 && i + childIndex < Count)
                {
                    if (array[i + childIndex].CompareTo(maxValue) == -1)
                    {
                        maxValue = array[i + childIndex];
                        maxIndex = i + childIndex;
                    }
                    i++;
                }
                if (maxValue.CompareTo(value) == 0)
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


