using System;

namespace uppgift_dec_13
{
    class Program
    {
        public string TextLine { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var guess = new Guess();
            var game = new Game();
            var menu = new Menu();
            //var memento = new Memento();
            int stackCount = 0;

            bool loop = true;
            while (loop == true)
            {                
                menu.ListMenu();

                var SwitchChoice = Convert.ToInt32(Console.ReadLine());
                switch (SwitchChoice)
                {
                    case 1:                      
                        Console.WriteLine("Enter a letter");
                        guess.SecretWord = Console.ReadLine();
                        break;
                        
                    case 2:                                                
                        Console.WriteLine("Enter a letter:");
                        do
                        {
                            game.CurrentGuess = Console.ReadLine();
                            if (game.CurrentGuess.Length == 1)
                            {
                                do
                                {
                                    if (game.WrongLetters.Contains(game.CurrentGuess) || game.RightLetters.Contains(game.CurrentGuess))
                                    {
                                        Console.WriteLine("That letter have been entered before, please try a new one");
                                        game.CurrentGuess = Console.ReadLine();
                                    }
                                    
                                } while (game.WrongLetters.Contains(game.CurrentGuess) || game.RightLetters.Contains(game.CurrentGuess));
                                //game.Guess(game.CurrentGuess);
                            }
                            else
                            {
                                Console.WriteLine("Please enter only one letter");
                            }
                        } while (game.CurrentGuess.Length > 1);

                        guess.Save();
                        stackCount++;
                        break;

                    case 3:
                        if (stackCount > 0)
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
