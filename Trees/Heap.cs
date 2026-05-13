using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Heap
    {
        // The arraybasedvector below holds the array with the data of the heap
        // It can also provide the count of elements
        List<int> _data = new List<int>();

        public int Count => _data.Count;

        public void Add(int value)
        {
            // Add the new value to the end of the list
            // The new node is placed in the next available position in the complete binary tree
            // This maintains the complete tree property of the heap
            _data.Add(value);

            // Heap-order might not be satisfied at position _data.Count - 1, so we need to restore it
            // Restore the heap property by bubbling up the new value
            HeapUp(_data.Count - 1);
        }

        private void HeapUp(int index)
        {
            if (index == 0)
            {
                // We have reached the root of the heap
                // The root has no parent,
                // Therefore the value added is the smallest value globally
                // no more work to be done
                return;
            }

            // compare the value at index with its parent
            int parentIndex = GetParentIndex(index);

            if (_data[index] < _data[parentIndex])
            {
                // the heap-order property is violated
                // so we need to continue working...
                _data.Swap(index, parentIndex);
                HeapUp(parentIndex); // we continue checking at the parentIndex
            }
            // else
            // the heap-order is restored, we can stop
            return;
        }

        public int RemoveMin()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Heap is empty");
            }

            int returnValue = _data[0]; // the minimum value is at the root of the heap

            _data.Swap(0, _data.Count - 1); // swap the root with the last element
            _data.RemoveAt(_data.Count - 1); // remove the last element (the minimum value)

            // The root might not have heap-order
            // therefore, we will use heap-down at the root to restore it
            HeapDown(0);

            return returnValue;
        }

        private void HeapDown(int index)
        {
            // we will stop heapdown when:
            // either we do not need to swap at all
            // or we arrive at a lead node (a node with no children)

            int leftChildIndex = GetLeftChildIndex(index);

            // case i) leaf node
            // compare the leftChildIndex with the count of _data
            if (leftChildIndex >= _data.Count)
            {
                // _data[leftChildIndex] // out of bounds exception
                // no left child exists
                // therefore no children (tree is complete)

                // since there are no children, the value which has bubbled down is larger than its parent
                // there is no extra work to be done (i.e. no childrent to compare against)
                return;
            }

            int smallestChildIndex = leftChildIndex;

            // case ii) left child only
            if (leftChildIndex == _data.Count - 1)
            {
                // if we only have 1 child, this is the smallest child
                // do nothing
            }
            else // case iii) both children exist
            {
                int rightChildIndex = GetRightChildIndex(index);

                // compare the left and right child to find the smallest child
                if (_data[rightChildIndex] < _data[leftChildIndex])
                {
                    // right child is smaller
                    smallestChildIndex = rightChildIndex;
                }
                // else left child is smaller or equal, so we do nothing
            }

            // now we have the smallest child index
            // we can compare the parent against the smallest child
            if (_data[index] > _data[smallestChildIndex])
            {
                // the heap-order property is violated
                // we need to swap and continue bubbling down
                _data.Swap(index, smallestChildIndex);
                HeapDown(smallestChildIndex); // we continue checking at the smallest child index
            }
            // else, the heap-order is restored, we can stop
            return;
        }


        #region Support operations

        private int GetParentIndex(int index)
        {
            return (index - 1) / 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }


        #endregion
    }
}
