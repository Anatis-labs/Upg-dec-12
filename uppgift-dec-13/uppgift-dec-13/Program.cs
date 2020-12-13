using System;

namespace uppgift_dec_13
{
    class Program
    {
        public string TextLine { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var guess = new Game();
            //var menu = new Menu();

            int stackCount = 0;
            string temp = "";
            int SwitchChoice = 0;
            int rightguess = 0;
            int reset = 0;

            bool loop = true;
            while (loop == true)
            {
                //menu.ListMenu();

                Console.WriteLine("Pick a choice in the menu:");
                Console.WriteLine("1: Enter the secret word.");
                Console.WriteLine("2: Enter a letter");
                Console.WriteLine("3: Revert the guess");
                Console.WriteLine("4: Redo the last revert");
                Console.WriteLine("5: Quit");
                Console.WriteLine();
                Console.WriteLine("Current hp: {0}", guess.Hp);
                Console.WriteLine();
                Console.WriteLine("Current right letters are:");


                


                foreach (var c in guess.RightLetters)
                {
                    foreach (var wordCharacter in guess.SecretWord)
                    {
                        if (c == wordCharacter.ToString())
                        {
                            Console.Write(' ' + c);
                            rightguess++;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Current ammount of right letters are:");
                Console.WriteLine("{0}/{1}", rightguess, guess.SecretWord.Length);


                if (rightguess == guess.SecretWord.Length || guess.Hp == 0)
                {
                    Console.WriteLine();
                    if (rightguess == guess.SecretWord.Length)
                    {
                        Console.WriteLine("CONGRATS! you guessed the right word");
                    }
                    else
                    {
                        Console.WriteLine("You lost, do u wanna try again??");
                    }
                    Console.WriteLine("Do u wanna try again??");
                    do
                    {
                        try
                        {
                            Console.WriteLine("Type 1 if u wanna play again, or 2 if you want to quit");
                            reset = Convert.ToInt32(Console.ReadLine());

                        }
                        catch
                        {
                            Console.WriteLine("Please enter 1 or 2");
                        }
                    } while (reset <= 0);
                    if (reset == 1)
                    {
                        guess.Reset();
                    }
                    else
                    {
                        SwitchChoice = 5;
                    }
                }

                rightguess = 0;
                Console.WriteLine();
                Console.WriteLine("The wrong guesses are:");
                foreach (var c in guess.WrongLetters)
                {
                    Console.Write(" {0}", c);
                }
                Console.WriteLine();

                Console.WriteLine("Please select from the menu: ");
                try
                {
                    if (SwitchChoice == 5)
                    {
                        Console.WriteLine("Thanks for playing!");
                        Console.ReadKey();
                    }
                    else
                    {
                        SwitchChoice = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch
                {
                    SwitchChoice = 0;
                }
                switch (SwitchChoice)
                {
                    case 1:
                        Console.WriteLine("Enter a secret word");
                        guess.SecretWord = Console.ReadLine().ToUpper();
                        break;

                    case 2:
                        Console.WriteLine("Enter a letter:");
                        do
                        {
                            temp = Console.ReadLine().ToUpper();
                            guess.CurrentGuess = temp;
                            if (guess.CurrentGuess.Length == 1)
                            {
                                do
                                {
                                    if (guess.WrongLetters.Contains(guess.CurrentGuess) || guess.RightLetters.Contains(guess.CurrentGuess))
                                    {
                                        Console.WriteLine("That letter have been entered before, please try a new one");
                                        guess.CurrentGuess = Console.ReadLine().ToUpper();
                                    }
                                } while (guess.WrongLetters.Contains(guess.CurrentGuess) || guess.RightLetters.Contains(guess.CurrentGuess));
                            }
                            else
                            {
                                Console.WriteLine("Please enter only one letter");
                            }
                        } while (guess.CurrentGuess.Length > 1);

                        guess.Attempt(temp);
                        stackCount++;
                        break;

                    case 3:
                        if (stackCount >= 0)
                        {
                            guess.Revert();
                            Console.WriteLine("Your string has been reverted to:");
                            stackCount--;
                        }
                        else
                        {
                            Console.WriteLine("No more saved changes to undo");
                        }
                        break;

                    case 4:
                        guess.Redo();
                        break;

                    case 5:
                        loop = false;
                        break;

                    default:
                        Console.WriteLine("please enter a number between 1 and 5.");
                        break;
                }
                Console.Clear();
            }
        }
    }

}
