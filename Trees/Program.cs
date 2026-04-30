// See https://aka.ms/new-console-template for more information
using Trees;

Console.WriteLine("Hello, World!");

BinarySearchTree<string> bst = new BinarySearchTree<string>();

bst.Insert(5, "five");
bst.Insert(5, "three");
bst.Insert(7, "seven");
bst.Insert(2, "two");
bst.Insert(4, "four");

Console.WriteLine("BST generated");

Console.WriteLine(bst);
Console.ReadLine();

Console.WriteLine(bst.Search(2));
Console.WriteLine(bst.Search(7));

try
{
    Console.WriteLine(bst.Search(1));
}
catch (KeyNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}