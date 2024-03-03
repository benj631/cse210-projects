using System;
using System.Diagnostics;

public class Reflecting : Activity{
    public Reflecting(string activityName, string activityDesc, int pauseDur) : base(activityName, activityDesc, pauseDur){
        
    }

    // Method to simulate listing items (replace it with actual user input if needed)
    private static int GetItemCount()
    {
        // Here you can implement logic to prompt the user to list items
        // For now, I'll return a random number between 1 and 10 as a placeholder
        Random rand = new Random();
        return rand.Next(1, 11); // Generate a random number between 1 and 10
    }

    private static List<string> promptList = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What are some good things you've accomplished in life?"
    };

    public List<string> userEntries = new();

    public override void MainActivity(int activityDur)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();

        Console.WriteLine("Welcome to the reflection activity!");
        Console.WriteLine("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        Console.WriteLine("Please think about the following prompt for " + activityDur + " seconds:");

        Random rand = new Random();
        int randomPromptIndex = rand.Next(promptList.Count);
        string randomPrompt = promptList[randomPromptIndex];

        int remainingSeconds = activityDur;
        while ((stopwatch.ElapsedMilliseconds < activityDur * 1000) && remainingSeconds > 2 ){
            Console.Clear();
            Console.WriteLine(randomPrompt);
            Console.WriteLine($"Time remaining: {remainingSeconds}");
            string userEntry = Console.ReadLine();
            userEntries.Add(userEntry);
            remainingSeconds = activityDur - (int)(stopwatch.ElapsedMilliseconds / 1000);
            
        }

        stopwatch.Stop();

        int i = 0;
        foreach (string item in userEntries){
            Console.WriteLine($"Entry {i+1}: {item}");
            i++;
        }
        i = 0;
    }

}