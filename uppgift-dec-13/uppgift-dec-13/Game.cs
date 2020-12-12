using System;
using System.Collections.Generic;

namespace uppgift_dec_13
{
    class Game
    {
        public string CurrentGuess { get; set; }

        public List<string> RightLetters = new List<string>();

        public List<string> WrongLetters = new List<string>();
             
        public int Hp { get; set; }

        public void Guess()
        {
            var guess = new Guess();          
            if (guess.SecretWord.Contains(CurrentGuess))
            {
                RightGuess(CurrentGuess);
                RightLetters.Add(CurrentGuess);
            }
            else
            {
                WrongGuess(CurrentGuess);
                WrongLetters.Add(CurrentGuess);
            }
            guess.Save();         
        }
        public void RightGuess(string RightLetter)
        {
            var guess = new Guess();
            guess.Save();
        }

        public void WrongGuess(string WrongLetter)
        {
            var guess = new Guess();
            guess.Save();
        }
    }
}
