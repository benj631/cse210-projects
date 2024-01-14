using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is the grade in a percent?");
        string gradeString = Console.ReadLine();
        int grade = int.Parse(gradeString);
        string gradeLetter = null;

        if (grade >= 90){
            gradeLetter = "A";
        } else if (grade >= 80) {
            gradeLetter = "B";
        } else if (grade >= 70) {
            gradeLetter = "C";
        } else if (grade >= 60) {
            gradeLetter = "D";
        } else if (grade < 60) {
            gradeLetter = "F";
        }
        
        Console.WriteLine($"Your grade letter is {gradeLetter}");

    }
}