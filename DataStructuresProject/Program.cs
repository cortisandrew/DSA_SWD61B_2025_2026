// See https://aka.ms/new-console-template for more information
using DataStructuresProject;

IVectorADT<string> vectorADT = new ArrayBasedVector<string>();

vectorADT.InsertElementAtRank(0, "Hector");
vectorADT.InsertElementAtRank(1, "Adam");
vectorADT.InsertElementAtRank(2, "Mavis");
vectorADT.InsertElementAtRank(3, "Bob");
vectorADT.InsertElementAtRank(2, "Charles");

Console.WriteLine(vectorADT);