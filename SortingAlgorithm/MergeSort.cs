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

        private static List<double> Merge(List<double> a1_sorted, List<double> a2_sorted)
        {
            throw new NotImplementedException();
        }
    }
}
