// See https://aka.ms/new-console-template for more information


using SortingAlgorithm;

List<double> a = [ 5, 2, 4, 6, 1, 3];

QuickSort qs = new QuickSort();
qs.QS(a);
Console.WriteLine(
    string.Join(", ", a));

//Console.WriteLine(
//    string.Join(", ", MergeSortAlgorithm.MergeSort(a)));