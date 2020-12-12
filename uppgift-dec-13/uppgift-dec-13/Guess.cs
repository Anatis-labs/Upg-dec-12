using System;
using System.Collections.Generic;
using System.Linq;

namespace uppgift_dec_13
{

    class Guess
    {
        public String SecretWord { get; set; }

        private Memento memento;


        public void Save()
        {
            var game = new Game();
            if (SecretWord.Contains(game.CurrentGuess))
                this.memento.mementoStackRight.Push(game.CurrentGuess);
            else

                this.memento.mementoStackWrong.Push(game.CurrentGuess);
        }

        public void Revert()
        {
            var game = new Game();
            if (SecretWord.Contains(game.CurrentGuess))
            {
                this.memento.mementoStackRedoRight.Push(game.CurrentGuess);              
                game.RightLetters.Remove(this.memento.mementoStackRight.Pop());
            }
            else
            {
                this.memento.mementoStackRedoWrong.Push(game.CurrentGuess);
                game.WrongLetters.Remove(this.memento.mementoStackWrong.Pop());             
            }
        }

        public void Redo()
        {
            var game = new Game();
            this.memento.mementoStackWrong.Push(this.SecretWord);
            this.memento.mementoStackRight.Push(this.SecretWord);
            game.CurrentGuess = this.memento.mementoStackRedoWrong.Pop();
            game.CurrentGuess = this.memento.mementoStackRedoRight.Pop();
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

