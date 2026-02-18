using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameApplication
{
    internal class AlgorithmB
    {
        internal int Guess(SecretNumber secretNumber)
        {
            // Find the min and max of the secretNumber
            // The number to guess is between min and max
            // Find the number in the middle of min and max
            // Try guessing this number, if we did not guess, we get a hint
            // update the possible range and repeat

            int min = secretNumber.Min;
            int max = secretNumber.Max;

            int currentGuess;

            while (max - min >= 1)
            {
                // the number in the middle of the range (round downwards! to nearest integer)
                currentGuess = (max + min) / 2;

                int result = secretNumber.Guess(currentGuess);

                if (result == 0)
                {
                    // guessed correctly!
                    return currentGuess;
                }
                else if (result > 0)
                {
                    // secret Number is greater than guess
                    // since the secret number > currentGuess
                    // restrict the range of possible numbers
                    min = currentGuess + 1;
                }
                else // result < 0
                {
                    // secret Number is SMALLER than guess
                    max = currentGuess - 1;
                }
            }

            // max = min (or an error in the logic of secret number, e.g. max < min)
            int finalResult = secretNumber.Guess(min);

            if (finalResult == 0)
            {
                return min;
            }
            else
            {
                throw new ApplicationException("There is some error in your logic!");
            }   
        }
    }
}
