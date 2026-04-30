// See https://aka.ms/new-console-template for more information


using SortingAlgorithm;

List<double> a = [ 5, 2, 4, 6, 1, 3];

Console.WriteLine(
    string.Join(", ", MergeSortAlgorithm.MergeSort(a)));