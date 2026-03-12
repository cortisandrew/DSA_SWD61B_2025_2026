// See https://aka.ms/new-console-template for more information
using DataStructuresProject;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

SinglyLinkedList<string> singlyLinkedList
    = default!; // ! means that we don't want the IDE to complain (remove warning)

singlyLinkedList = new SinglyLinkedList<string>();
singlyLinkedList.AddFirst("A");
singlyLinkedList.AddFirst("B");
singlyLinkedList.AddFirst("C");
singlyLinkedList.AddFirst("D");

Node<string>? cursor =
    singlyLinkedList.Head;

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