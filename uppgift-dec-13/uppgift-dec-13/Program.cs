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
            int stackCount = 0;

            bool loop = true;
            while (loop == true)
            {
                Console.WriteLine("Pick a choice in the menu:");
                Console.WriteLine("1: Enter a text");
                Console.WriteLine("2: Edit entered text");
                Console.WriteLine("3: Revert the last change");
                Console.WriteLine("4: Write out the saved textline");
                Console.WriteLine("5: Quit");

                Console.WriteLine();
                Console.WriteLine("Current word is:");
                Console.WriteLine(student.Status);

                string temp = "";
                int SwitchChoice = Convert.ToInt32(Console.ReadLine());
                switch (SwitchChoice)
                {                  
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Enter a row text:");
                        temp = Console.ReadLine();
                        student.Status = temp;
                        student.Save(temp);
                        stackCount++;
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter the new line of text");                         
                        temp = Console.ReadLine();
                        student.Status = temp;
                        student.Save(temp); 
                        stackCount++;
                        break;
                    case 3:
                        if (stackCount <= 0)
                        {
                            student.Revert();
                            Console.Clear();
                            Console.WriteLine("Your string has been reverted to:");
                            Console.WriteLine(student.Status);
                            stackCount--;
                        }
                        else
                        {
                            Console.WriteLine("No more saved changes to undo");
                        }
                        
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("The textline is: {0}", student.Status);                      
                        Console.WriteLine("Press a key to return to menu");
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
