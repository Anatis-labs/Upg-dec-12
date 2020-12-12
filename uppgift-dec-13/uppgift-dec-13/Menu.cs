using System;
using System.Collections.Generic;
using System.Text;

namespace uppgift_dec_13
{
    class Menu
    {
        public void ListMenu()
        {
            var guess = new Guess();
            var game = new Game();
            var menu = new Menu();

            Console.WriteLine("Pick a choice in the menu:");
            Console.WriteLine("1: Enter the secret word.");
            Console.WriteLine("2: Enter a letter");
            Console.WriteLine("3: Revert the guess");
            Console.WriteLine("4: Redo the last revert");
            Console.WriteLine("5: Quit");

            Console.WriteLine();
            Console.WriteLine("Current right letters are:");
            foreach (var c in game.RightLetters)
            {
                Console.Write(" {0}", c);
            }
            Console.WriteLine();
            Console.WriteLine("The wrong guesses are:");
            foreach (var c in game.WrongLetters)
            {
                Console.Write(" {0}", c);
            }
            Console.WriteLine();
        }
    }
}

