using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGameApplication
{
    /// <summary>
    /// A secret number that will be used in the guessing game
    /// </summary>
    public class SecretNumber
    {
        private int _secretNumber;
        private int _guesses = 0;

        public int Guesses
        {
            get {  return _guesses; }
            private set { _guesses = value; }
        }

        /// <summary>
        /// Creates a secret number between 1 and n (both inclusive)
        /// </summary>
        /// <param name="n">Problem size</param>
        public SecretNumber(int n)
        {
            _secretNumber = Random.Shared.Next(1, n + 1);
        }

        /// <summary>
        /// Try to guess (increases the number of guesses required by 1)
        /// Returns whether you guessed or otherwise, plus a hint if you did not guess
        /// </summary>
        /// <param name="guess">Your guess</param>
        /// <returns>0 if you guess correctly, -1 if the secret number is smaller than your guess, 1 otherwise</returns>
        public int Guess(int guess)
        {
            _guesses++;

            if (guess == _secretNumber)
            {
                return 0;
            }
            else if (_secretNumber < guess)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }

        /// <summary>
        /// You probably do not want to reveal the _secretNumber directly, but we will use this to test
        /// </summary>
        /// <returns></returns>
        public string Summary()
        {
            return $"You have performed {_guesses} guesses and the secret number is {_secretNumber}.";
        }
    }
}
