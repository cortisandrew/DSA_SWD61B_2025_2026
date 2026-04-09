// See https://aka.ms/new-console-template for more information
using DataStructuresProject;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

// Step 0: variables
Stopwatch sw = new Stopwatch();
int[] problemSizes = new[] { 100, 200, 400, 800, 1600, 3200, 6400, 12800 };
int repetitions = 100;


// Step i:
// Run some work without reporting the time (this avoids issues where the first run is slower)
ArrayBasedVector<int> arrayBasedVector;


for (int i = 0; i < repetitions; i++)
{
    arrayBasedVector = new ArrayBasedVector<int>();

    for (int j = 0; j < 100; j++)
    {
        arrayBasedVector.Append(i);
    }

    sw.Start();
    arrayBasedVector.Append(1);
    sw.Stop();
}


// Step ii:
// Repeat the same task for multiple problem sizes
Console.WriteLine("Append");
foreach (int problemSize in problemSizes)
{
    sw.Reset(); // time is reset back to 0

    // Step ii.1:
    // Setup the work to execute - create an array based vector with n elements
    arrayBasedVector = new ArrayBasedVector<int>();
    for (int i = 0; i < problemSize; i++)
    {
        arrayBasedVector.Append(i);
    }

    // Step ii.2:
    // Repeat the measurement for the same problem size multiple times
    for (int i = 0; i < repetitions; i++)
    {
        sw.Start(); // start but do not reset to 0
        // run the method here
        arrayBasedVector.Append(i);
        sw.Stop();  // stops the stopwatch, but does not reset
    }
    // elapsed ticks has the total time for running the same method over the repetitions

    // print time / repetition
    Console.WriteLine($"{problemSize}::{sw.ElapsedTicks/(double)repetitions}");
}

Console.WriteLine();
Console.WriteLine("Insert At Rank 0");
foreach (int problemSize in problemSizes)
{
    sw.Reset(); // time is reset back to 0

    // Step ii.1:
    // Setup the work to execute - create an array based vector with n elements
    arrayBasedVector = new ArrayBasedVector<int>();
    for (int i = 0; i < problemSize; i++)
    {
        arrayBasedVector.Append(i);
    }

    // Step ii.2:
    // Repeat the measurement for the same problem size multiple times
    for (int i = 0; i < repetitions; i++)
    {
        sw.Start(); // start but do not reset to 0
        // run the method here
        arrayBasedVector.InsertElementAtRank(0, 1);
        sw.Stop();  // stops the stopwatch, but does not reset
    }
    // elapsed ticks has the total time for running the same method over the repetitions

    // print time / repetition
    Console.WriteLine($"{problemSize}::{sw.ElapsedTicks / (double)repetitions}");
}

// TestQueue();
// TestLinkedList();

static void TestLinkedList()
{
    SinglyLinkedList<string> singlyLinkedList
        = default!; // ! means that we don't want the IDE to complain (remove warning)

    singlyLinkedList = new SinglyLinkedList<string>();
    singlyLinkedList.AddFirst("D");
    singlyLinkedList.AddFirst("C");
    singlyLinkedList.AddFirst("B");
    singlyLinkedList.AddFirst("X");
    singlyLinkedList.AddFirst("A");

    Console.WriteLine(singlyLinkedList);


    Node<string>? cursor =
        singlyLinkedList.Head;

    singlyLinkedList.RemoveAfter(cursor!);



    try
    {
        singlyLinkedList.RemoveBefore(cursor);
    }
    catch (InvalidOperationException)
    {
        // Log this
        Console.WriteLine("We know this operation should not be called with the cursor == Head");
    }
    catch (NotImplementedException)
    {
        Console.WriteLine("Yes, I will implement this later...");
    }
    /*
    catch
    {
        // hiding the exception is an anti-pattern and very dangerous!
    }
    */


    while (cursor != null)
    {
        Console.WriteLine($"Cursor is at Node with element: {cursor.Element}");
        cursor = singlyLinkedList.Next(cursor); //  move forward one step
    }

    // Points towards the Node "B"
    cursor = singlyLinkedList.Head.Next.Next;

    Console.WriteLine(
        $"The element of the previous node is {singlyLinkedList.Previous(cursor).Element}"); // "C"


    // TestStack();

#pragma warning disable CS8321 // Local function is declared but never used
    static void TestStack()
    {
        Stack_usingABV<string> stack_UsingABV = new Stack_usingABV<string>();

        stack_UsingABV.Push("A");
        stack_UsingABV.Push("B");
        stack_UsingABV.Push("C");

        Console.WriteLine(stack_UsingABV);
        Console.ReadKey();

        Console.WriteLine("Push D on top of the stack");
        Console.WriteLine();

        stack_UsingABV.Push("D");
        Console.WriteLine(stack_UsingABV);
        Console.ReadKey();

        Console.WriteLine("Push E and F on top of the stack");
        Console.WriteLine();

        stack_UsingABV.Push("E");
        stack_UsingABV.Push("F");
        Console.WriteLine(stack_UsingABV);
        Console.ReadKey();

        Console.WriteLine("Pop top element");
        Console.WriteLine($"The element {stack_UsingABV.Pop()} was popped!");

        Console.WriteLine(stack_UsingABV);
        Console.ReadKey();
    }
#pragma warning restore CS8321 // Local function is declared but never used
}

static void TestQueue()
{
    Queue_usingLinkedList<string> queue_UsingLinkedList = new Queue_usingLinkedList<string>();

    queue_UsingLinkedList.Enqueue("A");
    queue_UsingLinkedList.Enqueue("B");
    queue_UsingLinkedList.Enqueue("C");

    Console.WriteLine(queue_UsingLinkedList.Dequeue()); // A
    Console.WriteLine(queue_UsingLinkedList.Dequeue()); // B

    queue_UsingLinkedList.Enqueue("D");

    Console.WriteLine(queue_UsingLinkedList.Dequeue()); // C
    Console.WriteLine(queue_UsingLinkedList.Dequeue()); // D

    queue_UsingLinkedList.Enqueue("E");
    queue_UsingLinkedList.Enqueue("F");

    while (queue_UsingLinkedList.Size > 0)
    {
        Console.WriteLine(queue_UsingLinkedList.Dequeue()); // dequeue the remaining elements
    }
}


/*
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
*/

/*
for (int i = 0; i < 1000000; i++)
{
    stopwatch.Start();
    test.InsertElementAtRank(0, i);
    stopwatch.Stop();
}

Console.WriteLine($"Time taken to insert 1 million elements at rank 0: {stopwatch.ElapsedTicks} ticks");
*/

/*
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
*/