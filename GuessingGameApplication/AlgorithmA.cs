using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameApplication
{
    public class AlgorithmA
    {
        private readonly bool _printToConsole;
        public AlgorithmA(bool printToConsole = false) { 
            _printToConsole = printToConsole;
        }

        public int Guess(SecretNumber secretNumber)
        {
            // Guess all the numbers in sequence, starting from the Min, up to the Max
            // e.g. guess 1, 2, 3, 4, ...

            int currentGuess = secretNumber.Min;
            int result;

            while (currentGuess <= secretNumber.Max)
            {
                result = secretNumber.Guess(currentGuess);

                if (_printToConsole)
                {
                    Console.WriteLine($"Current guess: {currentGuess},\t Total guesses: {secretNumber.Guesses}");
                }

                if (result == 0)
                {
                    if (_printToConsole)
                    {
                        Console.WriteLine($"Guessed successfully {currentGuess}");
                    }

                    return currentGuess;
                }

                // Go to the next possible number
                currentGuess++;
            }

            throw new InvalidDataException("Something went wrong, the secret number is not within the expected range!");

            /*
            for (int i = secretNumber.Min; i <= secretNumber.Max; i++)
            {
                result = secretNumber.Guess(i);
            }

            secretNumber.
            throw new NotImplementedException();
            */
        }
    }
}
