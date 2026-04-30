using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithm
{
    public class MergeSortAlgorithm
    {

        public static List<double> MergeSort(List<double> a)
        {
            if (a.Count <= 1)
            {
                return a;
            }

            // 5 / 2  = 2 (integer absorbtion)
            var a1 = a.Take(a.Count / 2).ToList();
            var a2 = a.Skip(a.Count / 2).ToList();

            var a1_sorted = MergeSort(a1);
            var a2_sorted = MergeSort(a2);

            return Merge(a1_sorted, a2_sorted);
        }

        /// <summary>
        /// Total time, we copy exactly n elements. One while loop iteration, copies 1 element. So, Theta(n) time complexity.
        /// </summary>
        /// <param name="a1_sorted">Must be pre-sorted</param>
        /// <param name="a2_sorted">Must be pre-sorted</param>
        /// <returns></returns>
        private static List<double> Merge(List<double> a1_sorted, List<double> a2_sorted)
        {
            List<double> merged = new List<double>(a1_sorted.Count + a2_sorted.Count);

            int i = 0, j = 0;

            // while there are still elements in both lists
            // i < a1_sorted.Count && j < a2_sorted.Count
            // we still have elements to compare from both lists
            while (i < a1_sorted.Count && j < a2_sorted.Count)
            {
                // if a1 has the smaller element at position i, this is the smallest element globally
                if (a1_sorted[i] <= a2_sorted[j])
                {
                    // copy it to the merged list
                    merged.Add(a1_sorted[i]);
                    // element at position i is copied, and no longer required. Move forward 1 step
                    i++;
                }
                else // a2 has the smaller element globally
                {
                    // copy it to the merged list
                    merged.Add(a2_sorted[j]);
                    // element at position j is copied, and no longer required. Move forward 1 step
                    j++;
                }
            }

            // while there are still elements in a1_sorted, copy them to the merged list
            while (i < a1_sorted.Count)
            {
                // we are copying everything that is left in order
                // since a1_sorted is already sorted the result is still sorted
                merged.Add(a1_sorted[i]);
                i++;
            }

            // while there are still elements in a2_sorted, copy them to the merged list
            while (j < a2_sorted.Count)
            {
                // we are copying everything that is left in order
                // since a2_sorted is already sorted the result is still sorted
                merged.Add(a2_sorted[j]);
                j++;
            }

            return merged;
        }
    }
}
