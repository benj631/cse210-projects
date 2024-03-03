using System;
using System.Diagnostics;
using System.Collections.Generic;

public class Listing : Activity{
    public Listing(string activityName, string activityDesc, int pauseDur) : base(activityName, activityDesc, pauseDur){
        
    }

    private static List<string> promptList = new List<string>()
{
    "Think of a time when you stood up for someone else.",
    "Think of a time when you did something really difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you did something truly selfless.",
    "Think of a time you were able to accomplish a goal you wanted to achieve."
};

private static List<string> questionList = new List<string>()
{
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?"
};



    public override void MainActivity(int activityDur){
        Stopwatch stopwatch = Stopwatch.StartNew();

        int remainingSeconds = activityDur;

         Random rand = new Random();

        // Generate a random index within the range of valid indices
        int promptRandomIndex = rand.Next(0, promptList.Count);
        int questionRandomIndex = rand.Next(0,questionList.Count);

        // Access the list at the random index
        string randomPromptItem = promptList[promptRandomIndex];
        string randomQuestionItem = promptList[questionRandomIndex];

        while ((stopwatch.ElapsedMilliseconds < activityDur * 1000) && remainingSeconds > 2 ){

            remainingSeconds = activityDur - (int)(stopwatch.ElapsedMilliseconds / 1000);
            Console.WriteLine(randomPromptItem);
            this.AnimatePause(" " +(remainingSeconds.ToString()) + " seconds remaining");

            remainingSeconds = activityDur - (int)(stopwatch.ElapsedMilliseconds / 1000);
            Console.WriteLine(randomQuestionItem);
            this.AnimatePause(" " + (remainingSeconds.ToString()) + " seconds remaining");

        }

        stopwatch.Stop();
    }
}