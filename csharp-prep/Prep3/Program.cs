using System;

class Program
{
    static void Main()
    {
        
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);

        Console.WriteLine("Enter your guess:");
        int guessNumber = int.Parse(Console.ReadLine());

        while (guessNumber != number){
            if (guessNumber > number){
                Console.WriteLine("Lower");
            }
            else if (guessNumber < number){
                Console.WriteLine("Higher");
            }
            Console.WriteLine("Enter your guess");
            guessNumber = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("You guessed it!");

    }
}