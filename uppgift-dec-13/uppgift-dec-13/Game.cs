//using System;
//using System.Collections.Generic;

//namespace uppgift_dec_13
//{
//    class Game
//    {
//        public readonly string SecretWord;
//        public List<string> RightLetters = new List<string>();

//        public List<string> WrongLetters = new List<string>();
             
//        public int Hp { get; set; }

//        public Game()
//        {
//            var guess = new Guess();
//            this.SecretWord = guess.SecretWord;

//        }
//        public void Guess(string temp)
//        {
//            var guess = new Guess();          
//            if (guess.SecretWord.Contains(temp))
//            {
//                RightGuess(temp);
//                RightLetters.Add(temp);
//            }
//            else
//            {
//                WrongGuess(temp);
//                WrongLetters.Add(temp);
//            }
//            guess.Save(temp);         
//        }
//        public void RightGuess(string RightLetter)
//        {
//            var guess = new Guess();
//            guess.Save(RightLetter);
//        }

//        public void WrongGuess(string WrongLetter)
//        {
//            var guess = new Guess();
//            guess.Save(WrongLetter);
//        }
//    }
//}
