using System.Collections.Generic;

namespace uppgift_dec_13
{

    class Guess
    {
        public string SecretWord { get; set; }
        public string CurrentGuess { get; set; }

        private Memento memento;

        public List<string> RightLetters = new List<string>();

        public List<string> WrongLetters = new List<string>();
        public int Hp { get; set; }

        public Guess()
        {
            this.SecretWord = "test";
            this.CurrentGuess = "";
            this.memento = new Memento(SecretWord, CurrentGuess);
            this.Hp = 10;
        }

        public void Attempt(string temp)
        {
            var guess = new Guess();
            if (guess.SecretWord.Contains(temp))
            {
                RightGuess(temp);
            }
            else
            {
                WrongGuess(temp);
                --this.Hp;
            }
        }

        public void RightGuess(string RightLetter)
        {
            Save(RightLetter);
        }

        public void WrongGuess(string WrongLetter)
        {
            Save(WrongLetter);
        }

        public void Save(string temp)
        {
            memento.mementoStackGuess.Push(this.CurrentGuess);
            if (SecretWord.Contains(this.CurrentGuess))
            {
                this.RightLetters.Add(CurrentGuess);
            }
            else
            {
                this.WrongLetters.Add(CurrentGuess);
            }
        }

        public void Revert()
        {
            this.memento.mementoStackRedoGuess.Push(CurrentGuess);
            if (SecretWord.Contains(CurrentGuess))
            {
                RightLetters.Remove(CurrentGuess);               
            }
            else
            {
                WrongLetters.Remove(CurrentGuess);              
            }
            CurrentGuess = this.memento.mementoStackGuess.Pop();
        }

        public void Redo()
        {
            this.memento.mementoStackGuess.Push(CurrentGuess);
            CurrentGuess = this.memento.mementoStackRedoGuess.Pop();
            if (SecretWord.Contains(CurrentGuess))
            {
                RightLetters.Add(CurrentGuess);
            }
            else
            {
                WrongLetters.Add(CurrentGuess);
            }

        }
        public void Reset()
        {
            this.CurrentGuess = "Empty";
            this.memento.mementoStackGuess.Clear();
            this.memento.mementoStackRedoGuess.Clear();
            this.RightLetters.Clear();
            this.WrongLetters.Clear();
            this.CurrentGuess = "";
            this.Hp = 10;
        }
    }

    class Memento
    {
        public readonly string SecretWord;
        public readonly string CurrentGuess;
        public Stack<string> mementoStackGuess = new Stack<string>();

        public Stack<string> mementoStackRedoGuess = new Stack<string>();

        public Memento(string secretWord, string temp)
        {
            this.SecretWord = secretWord;
            this.CurrentGuess = temp;
            mementoStackGuess.Push(temp);            
        }

        //public Memento(string SecretWord, string old)
        //{
        //    this.CurrentGuess = SecretWord;
        //    mementoStackRedoRight.Push(SecretWord);
        //    mementoStackRedoWrong.Push(SecretWord);
        //}
    }
}

