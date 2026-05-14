using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    /// <summary>
    /// The class MUST be static to allow the creation of extension methods
    /// </summary>
    public static class ExtensionHelpers
    {
        /// <summary>
        /// Methods in static classes must be static
        /// The this keyword in the parameters is used to "attach" the method to the type of this parameter
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public static void Swap<T>(this List<T> myList, int i, int j)
        {
            // perform a swap at positions i and j in the list
            T temp = myList[i];
            myList[i] = myList[j];
            myList[j] = temp;
        }

        public static List<int> HeapSort(this List<int> myList)
        {
            // build an empty array to store the sorted elements (same size as the input list)
            List<int> sorted = new List<int>(myList.Count);

            Heap heap = new Heap();

            // Build a heap by adding all values, one by one
            foreach (var intValue in myList)    // xn elements
            {
                heap.Add(intValue);             // O(log n) time
            }
            // foreach total time: O(n log n)

            while (heap.Count > 0)              // xn elements
            {
                int minValue = heap.RemoveMin(); // O(log n) time
                sorted.Add(minValue);             // O(1) time
            }
            // while total time: O(n log n)

            return sorted; // total time: O(n log n)
        }
    }
}
