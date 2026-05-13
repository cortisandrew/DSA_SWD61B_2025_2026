using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithm
{
    public class QuickSort
    {
        public void QS(List<double> arr)
        {
            QS(arr, 0, arr.Count - 1);
        }

        private void QS(List<double> arr, int left, int right)
        {
            // base case:
            if (right - left < 1)
            {
                // base case: 0 or 1 element, already sorted
                return;
            }

            // step 1: select a pivot
            int pivotIndex = left; // leftmost pivot

            // step 2: partition the array around the pivot
            int finalPivotIndex = Partition(arr, left, right);

            // step 3: recursively sort the left and right partitions
            QS(arr, left, finalPivotIndex - 1);
            QS(arr, finalPivotIndex + 1, right);
        }

        private int Partition(List<double> arr, int left, int right)
        {
            List<double> smaller = [];
            List<double> larger = [];

            // assume that the pivot is the leftmost element
            double pivotValue = arr[left];

            // note the assumption that left is the pivot element!
            for (int i = left + 1; i <= right; i++)
            {
                // go over each element in the array and compare against the pivot
                if (arr[i] <= pivotValue)
                {
                    smaller.Add(arr[i]);
                }
                else
                {
                    larger.Add(arr[i]);
                }
            }

            // now we have 3 lists: smaller, pivot, larger
            // join everything back

            int k = left;
            for (int i = 0; i < smaller.Count; i++)
            {
                arr[k] = smaller[i];
                k++;
            }

            int finalPivotIndex = k; // the pivot will be at index k after we add the smaller elements
            arr[k] = pivotValue;
            k++;

            for (int i = 0; i < larger.Count; i++)
            {
                arr[k] = larger[i];
                k++;
            }

            return finalPivotIndex;
        }
    }
}
