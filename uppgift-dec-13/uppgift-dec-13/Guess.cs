using System;
using System.Collections.Generic;
using System.Linq;

namespace uppgift_dec_13
{

    class Guess
    {
        public string SecretWord { get; set; }
        public string CurrentGuess { get; set; }
        private Memento memento;


        public void Save()
        {
            var game = new Game();
            if (SecretWord.Contains(this.CurrentGuess))
                memento.mementoStackRight.Push(this.CurrentGuess);
            else
                memento.mementoStackWrong.Push(this.CurrentGuess);
        }

        public void Revert()
        {
            var game = new Game();
            if (SecretWord.Contains(CurrentGuess))
            {
                this.memento.mementoStackRedoRight.Push(CurrentGuess);              
                game.RightLetters.Remove(this.memento.mementoStackRight.Pop());
            }
            else
            {
                this.memento.mementoStackRedoWrong.Push(CurrentGuess);
                game.WrongLetters.Remove(this.memento.mementoStackWrong.Pop());             
            }
        }

        public void Redo()
        {
            var game = new Game();
            this.memento.mementoStackWrong.Push(this.SecretWord);
            this.memento.mementoStackRight.Push(this.SecretWord);
            CurrentGuess = this.memento.mementoStackRedoWrong.Pop();
            CurrentGuess = this.memento.mementoStackRedoRight.Pop();
        }
    }

    class Memento
    {
        public readonly string SecretWord;
        public Stack<string> mementoStackRight = new Stack<string>();
        public Stack<string> mementoStackWrong = new Stack<string>();
        public Stack<string> mementoStackRedoRight = new Stack<string>();
        public Stack<string> mementoStackRedoWrong = new Stack<string>();
        public Memento(String SecretWord)
        {
            this.SecretWord = SecretWord;
            mementoStackRight.Push(SecretWord);
            mementoStackWrong.Push(SecretWord);
        }
        public Memento(string SecretWord, string old)
        {
            this.SecretWord = SecretWord;
            mementoStackRedoRight.Push(SecretWord);
            mementoStackRedoWrong.Push(SecretWord);
        }
    }
}

