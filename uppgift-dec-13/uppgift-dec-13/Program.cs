using System;

namespace uppgift_dec_13
{
    class Program
    {
        public string TextLine { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var student = new Student();
            //var memento = new Memento();
            int stackCount = 0;

            bool loop = true;
            while (loop == true)
            {
                Console.WriteLine("Pick a choice in the menu:");
                Console.WriteLine("1: Enter a text");
                Console.WriteLine("2: Edit entered text");
                Console.WriteLine("3: Revert the last change");
                Console.WriteLine("4: Redo the last revert");
                Console.WriteLine("5: Write out the saved textline");
                Console.WriteLine("5: Quit");

                Console.WriteLine();
                Console.WriteLine("Current word is:");
                Console.WriteLine(student.Status);


                int SwitchChoice = Convert.ToInt32(Console.ReadLine());
                switch (SwitchChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter a row text:");
                        student.Status = Console.ReadLine();
                        student.Save();
                        stackCount++;
                        break;
                        
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter the new line of text");
                        student.Status = Console.ReadLine();
                        student.Save();
                        stackCount++;
                        break;

                    case 3:
                        if (stackCount > 0)
                        {
                            student.Revert();
                            Console.Clear();
                            Console.WriteLine("Your string has been reverted to:");
                            stackCount--;
                        }
                        else
                        {
                            Console.WriteLine("No more saved changes to undo");
                        }
                        break;

                    case 4:
                        student.Redo();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("The textline is: {0}", student.Status);
                        Console.WriteLine("Press a key to return to menu");
                        break;

                    case 6:
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
