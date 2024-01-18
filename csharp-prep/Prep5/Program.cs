using System;

class Program
{
    static void Main(string[] args)
    {
        
        static void DisplayWelcome(){
            Console.WriteLine("Welcome to the program!");
        }
        static string PromptUserName(){
            Console.WriteLine("Please enter your name:");
            string name = Console.ReadLine();
            return name;
        }
        static int PromptUserNumber(){
            Console.WriteLine("Please enter your favorite number:");
            int num = int.Parse(Console.ReadLine());
            return num;
        }
        static int SquareNumber(int sq){
            return sq * sq;
        }

        static string DisplayResult(string name, int sqNum){
            return String.Concat("Brother ", name,", ", "the square of your favorite number is ",sqNum);
        }

        DisplayWelcome();
        string user = PromptUserName();
        Console.WriteLine($"Your name is {user}");
        int num = SquareNumber(PromptUserNumber());
        Console.WriteLine(DisplayResult(user,num));
        
    }
}