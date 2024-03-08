using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment mathAssignment = new("Jimmy", "Fractions", "Chapter 4", "1-42");
        WritingAssignment writingAssignment = new("Jimmy", "Poetry", "Aggressive Flowers");

        Console.WriteLine(mathAssignment.ReturnSummary());
        Console.WriteLine(writingAssignment.ReturnSummary());


    }
}