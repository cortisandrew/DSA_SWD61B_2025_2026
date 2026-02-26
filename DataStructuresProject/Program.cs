// See https://aka.ms/new-console-template for more information
using DataStructuresProject;
using System.ComponentModel;
using System.Diagnostics;

IVectorADT<string> vectorADT = new ArrayBasedVector<string>();

vectorADT.InsertElementAtRank(0, "Hector");
vectorADT.InsertElementAtRank(1, "Adam");
vectorADT.InsertElementAtRank(2, "Mavis");
vectorADT.InsertElementAtRank(3, "Bob");
vectorADT.InsertElementAtRank(2, "Charles");
vectorADT.InsertElementAtRank(0, "Francis");


vectorADT.RemoveElementAtRank(2);

IVectorADT<int> test = new ArrayBasedVector<int>();
Stopwatch stopwatch = new Stopwatch();

/*
for (int i = 0; i < 1000000; i++)
{
    stopwatch.Start();
    test.InsertElementAtRank(0, i);
    stopwatch.Stop();
}

Console.WriteLine($"Time taken to insert 1 million elements at rank 0: {stopwatch.ElapsedTicks} ticks");
*/

test = new ArrayBasedVector<int>();

stopwatch.Reset();
for (int i = 0; i < 1000000; i++)
{
    stopwatch.Start();
    test.Append(i);
    stopwatch.Stop();
}

Console.WriteLine($"Time taken to append 1 million elements: {stopwatch.ElapsedTicks} ticks");
Console.WriteLine($"Time taken to append 1 million elements: {stopwatch.ElapsedMilliseconds} ms");

// Console.WriteLine(vectorADT);
