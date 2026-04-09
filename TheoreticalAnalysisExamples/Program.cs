// See https://aka.ms/new-console-template for more information

int count = 0;
int n = 100;

for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        for (int k = 0; k < n; k++)
        {
            count++;
        }
    }
}

Console.WriteLine(count);



/*
int[] input = [45, 32, 98];

for (int i = 1; i < 11; i++)
{
    input = new int[i];
    
    for (int j = 0; j < input.Length; j++)
    {
        input[j] = j;
    }

    int max = FindMax(input, out int n, out int time);

    Console.WriteLine($"{n}, {time}");
}
*/

/*
(int, int, int) FindMax(int[] X)
{
    // do work..

    return (m, n, time);
}

MyClass FindMax(int[] X)
{

    MyClass myClass = new MyClass(...);
    return myClass;
}
*/

int FindMax(int[] X, out int n, out int time)
{
    time = 0; // counter to keep the number of operations
    n = input.Length; // this is the problem size

    int m = X[0]; // declare a variable of type int to keep the max value, read X[0], and assign m to X[0]
    time++; // 1 time

    int k = 1; // next element from array to read
    time++; // 1 time to declare and assign k

    while (k < n) // while we still have elements, read the next element
    {
        // since we entered the loop, this means that I have 
        // worked out k < n and obtained true
        time++;

        time++; // time taken to work out X[k] > m
        if (X[k] > m)
        {
            m = X[k]; // assign the new maximum
            time++; // 1 time to assign the maximum
        }

        k++; // increment k
        time++; // 1 time to increment k
    }
    // since I exited the while loop, this means I evaluated k < n, and got false
    time++;

    time++; // 1 time to return max
    return m;
}

