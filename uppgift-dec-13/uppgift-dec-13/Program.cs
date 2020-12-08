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


            bool loop = true;
            while (loop == true)
            {
                Console.WriteLine("Pick a choice in the menu:");
                Console.WriteLine("1: Enter a text");
                Console.WriteLine("2: Edit entered text");
                Console.WriteLine("3: Revert the last change");
                Console.WriteLine("4: Write out the saved textline");
                Console.WriteLine("5: Quit");

                int SwitchChoice = Convert.ToInt32(Console.ReadLine());
                switch (SwitchChoice)
                {
                    case 1:
                        Console.WriteLine("Enter a row text:");
                        student.Status = Console.ReadLine();
                        student.Save(student.Status);
                        break;
                    case 2:
                        Console.WriteLine("Enter the new line of text");
                        string newString = Console.ReadLine();
                        student.Status = newString;
                        break;
                    case 3:
                        student.Revert();
                        Console.WriteLine("Your string has been reverted");
                        break;
                    case 4:
                        Console.WriteLine("The textline is: {0}", student.Status);
                        break;
                    case 5:
                        loop = false;
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }
    }

}
