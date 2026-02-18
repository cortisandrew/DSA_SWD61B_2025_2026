// See https://aka.ms/new-console-template for more information
using GuessingGameApplication;

//int test = 100;
// Console.WriteLine(51/test); // integer division
// Console.WriteLine((double)51 / test); // floating point division

Console.WriteLine("Guessing Game");

int repetitions = 100;

AlgorithmA algorithmA = new AlgorithmA();

int[] problemSizes = new int[] { 100, 1000, 10000, 100000, 1000000, 1000000000 };

Console.WriteLine("Algorithm A");
foreach (int problemSize in problemSizes)
{
    List<int> guessesRequired = new List<int>();

    for (int i = 0; i < repetitions; i++)
    {
        SecretNumber secretNumber = new SecretNumber(problemSize);
        int guessedNumber = algorithmA.Guess(secretNumber);

        if (guessedNumber == secretNumber.GetSecretNumber())
        {
            guessesRequired.Add(secretNumber.Guesses);
        }
        else
        {
            throw new ApplicationException("You have some error in your algorithm!");
        }
    }

    Console.WriteLine($"For problem size {problemSize}, the mean (average) number of guesses required is {guessesRequired.Average()}.");
}

// Ideally we should use some form of strategy pattern and interface.. The code below does not really need the specific
// Algorithm instance... as long as my algorithm has the required interface, it should work.
AlgorithmB algorithmB = new AlgorithmB();

Console.WriteLine("Algorithm B");
foreach (int problemSize in problemSizes)
{
    List<int> guessesRequired = new List<int>();

    for (int i = 0; i < repetitions; i++)
    {
        SecretNumber secretNumber = new SecretNumber(problemSize);
        int guessedNumber = algorithmB.Guess(secretNumber);

        if (guessedNumber == secretNumber.GetSecretNumber())
        {
            guessesRequired.Add(secretNumber.Guesses);
        }
        else
        {
            throw new ApplicationException("You have some error in your algorithm!");
        }
    }

    Console.WriteLine($"For problem size {problemSize}, the mean (average) number of guesses required is {guessesRequired.Average()}.");
}

// Console.WriteLine(secretNumber.Summary());