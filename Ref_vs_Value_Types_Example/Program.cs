// See https://aka.ms/new-console-template for more information
using Ref_vs_Value_Types_Example;

Console.WriteLine("Hello, World!!!");

// Declare and assign two integers
// (value type variables)
int a;
int b;

a = 5;
b = 6;

Console.WriteLine("Value type behaviour");
Console.WriteLine("Declared a to 5 and b to 6");
Console.WriteLine($"The value of {nameof(a)} is {a}");  // 5
Console.WriteLine($"The value of {nameof(b)} is {b}");  // 6

a = b;
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("a = b");
Console.WriteLine($"The value of {nameof(a)} is {a}");  // 6
Console.WriteLine($"The value of {nameof(b)} is {b}");  // 6

b = 10;

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("b = 10");
Console.WriteLine($"The value of {nameof(a)} is {a}");  // 6
Console.WriteLine($"The value of {nameof(b)} is {b}");  // 10

Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Reference type behaviour");
Console.WriteLine("Declared a_Ref to 5 and b_Ref to 6");

RefTypeClass a_Ref = new RefTypeClass() { Value = 5 };
RefTypeClass b_Ref = new RefTypeClass() { Value = 6 };

Console.WriteLine($"The value of {nameof(a_Ref)} " +
    $"is {a_Ref.Value}");  // 5
Console.WriteLine($"The value of {nameof(b_Ref)} " +
    $"is {b_Ref.Value}");  // 6

a_Ref = b_Ref;

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The value of {nameof(a_Ref)} " +
    $"is {a_Ref.Value}");  // 6
Console.WriteLine($"The value of {nameof(b_Ref)} " +
    $"is {b_Ref.Value}");  // 6

b_Ref.Value = 10;
Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The value of {nameof(a_Ref)} " +
    $"is {a_Ref.Value}");  // 10
Console.WriteLine($"The value of {nameof(b_Ref)} " +
    $"is {b_Ref.Value}");  // 10

a_Ref = new RefTypeClass() { Value = 2 };

Console.WriteLine();
Console.WriteLine();
Console.WriteLine($"The value of {nameof(a_Ref)} " +
    $"is {a_Ref.Value}");  // 2
Console.WriteLine($"The value of {nameof(b_Ref)} " +
    $"is {b_Ref.Value}");  // 10

