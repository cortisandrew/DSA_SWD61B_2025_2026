using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProject
{
    /// <summary>
    /// The ArrayBasedVector is a data structure. It is a
    /// concrete implementation of the IVectorADT.
    /// </summary>
    /// <typeparam name="T">This is the type of element stored</typeparam>
    public class ArrayBasedVector<T> : IVectorADT<T>
    {
        private const int DEFAULT_LENGTH = 4;
        private T[] _array = new T[DEFAULT_LENGTH];

        public int Size { get; private set; }

        public void Append(T element)
        {
            // Size is the next available rank, so we can simply place the element at rank Size
            InsertElementAtRank(Size, element);
        }

        public T ElementAtRank(int rank)
        {
            // Step 1:
            // Validate the input!

            // Rank < 0 is invalid (you can't have < 0 elements before you!)
            // ArgumentOutOfRangeException.ThrowIfLessThan(rank, 0, nameof(rank));
            if (rank < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rank), "Rank must be greater than or equal to 0");
            }

            // if there are Size = 4 elements, the last element has a rank of 3
            if (rank >= Size)
            {
                string message =
                    Size == 0 ?
                        "There are no elements to return!" :
                        $"Rank must have a value between 0 and {Size - 1} (inclusive).";
                // There is no element which matches your input!
                throw new ArgumentOutOfRangeException(nameof(rank), message);

                // if there are 0 elements, you cannot get element at rank, because there is nothing to return!
            }

            // Step 2:
            // The index is the rank of the element
            // Simply return the element at index rank
            // We know that we will find the element, since Size > rank AND there are no gaps in the _array
            return _array[rank];
        }

        public void InsertElementAtRank(int rank, T element)
        {
            // Step 1:
            // Validation
            if (rank < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rank), "Rank must be greater than or equal to 0");
            }

            // if there are Size = 4 elements, the last element has a rank of 3. This means that I can place a new element
            // at rank 4
            // I am allowed to place the element at Rank == size
            if (rank > Size)
            {
                // if rank > size, this means that I have a "gap"
                throw new ArgumentOutOfRangeException(nameof(rank), $"Rank must have a value between 0 and {Size} (inclusive).");

                // if there are 0 elements, you can insert at rank 0 (this will be the first and only element)
            }

            if (Size == _array.Length)
            {
                // _array is full!

                // Create a new array with double the length of the current array
                T[] newArray = new T[_array.Length * 2];

                // Copy every element from the old array to the new array
                for (int i = 0; i < _array.Length; i++)
                {
                    newArray[i] = _array[i];
                }

                // Replace the old array with the new array
                _array = newArray;
            }

            // Step 2:
            // Because the _array is NOT full, we have at least 1 available space.

            // pick every element from Rank onwards, and move it back by 1 space
            // attempt 2:

            // start from Size - 1 (last element)
            for (int i = Size - 1; i >= rank; i--)
            {
                // shift the element forward by 1 place
                _array[i + 1] = _array[i];
            }

            // Step 3:
            // Place the element in the correct position
            _array[rank] = element;
            // Increment the Size to reflect that I have one extra element
            Size++;
        }

        public T RemoveElementAtRank(int rank)
        {
            // Step 1:
            // Validate the input!

            // Rank < 0 is invalid (you can't have < 0 elements before you!)
            // ArgumentOutOfRangeException.ThrowIfLessThan(rank, 0, nameof(rank));
            if (rank < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rank), "Rank must be greater than or equal to 0");
            }

            // if there are Size = 4 elements, the last element has a rank of 3
            if (rank >= Size)
            {
                string message =
                    Size == 0 ?
                        "There are no elements to remove!" :
                        $"Rank must have a value between 0 and {Size - 1} (inclusive).";
                // There is no element which matches your input!
                throw new ArgumentOutOfRangeException(nameof(rank), message);
            }

            // Step 2:
            // Input is valid, we can remove the element at rank
            T removedElement = _array[rank];

            // shift the elements to close the gap left by the removed element
            for (int i = rank; i < Size - 1; i++)
            {
                // shift the element forward by 1 place
                _array[i] = _array[i + 1];
            }

            _array[Size - 1] = default; // remove the value stored here - this prevents memory leaks

            // Step 4:
            Size--;
            return removedElement;

        }

        public T ReplaceElementAtRank(int rank, T newElement)
        {
            // Get the element at rank and store it
            // Put the new element in the same rank
            // Return the element stored
            throw new NotImplementedException("Exercise!");
        }

        public override string ToString()
        {
            return "[ " + string.Join(", ", _array.Take(Size)) + " ]";
        }
    }
}
