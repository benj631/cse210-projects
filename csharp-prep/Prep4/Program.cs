using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        bool go = true;
        List<int> numList = new List<int>();

        while (go) {
            Console.WriteLine("Enter a number");
            int num = int.Parse(Console.ReadLine());
            if (num == 0){
                go = false;
            }
            numList.Add(num);
        }
        int sum = 0;
        int nums = 0;
        int largest = 0;
        foreach (int n in numList){
            sum += n;
            nums += 1;
            if (n > largest){
                largest = n;
            }
        }
        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {sum/nums}");
        Console.WriteLine($"The largest number is: {largest}");

    }
}