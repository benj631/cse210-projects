using System;

public abstract     class Activity{
    public string activityName = "";
    public string activityDescription = "";
    int pauseDuration = 5; // Seconds

    public Activity(string activityName, string activityDesc, int pauseDur){
        
        this.activityName = activityName;
        this.activityDescription = activityDesc;
        this.pauseDuration = pauseDur;

    }

    public int GetActivityDuration(){
        Console.WriteLine("Please enter the amount of time you would like to, or press enter  do the activity. For the default duration, press enter:");
        
        int duration = 0;
        try {
        string input = Console.ReadLine();
        if (input == ""){
            duration = 25;
        } else {
            duration = int.Parse(input);
        }
        } catch (FormatException) {
            // Handle invalid input
            Console.WriteLine("Sorry, that's an invalid selection. Please restart the program.");
            Environment.Exit(1);
        }
    return duration;
    }

    public void AnimatePause(){

        int animationDurationSeconds = this.pauseDuration; // Change duration as needed
        DateTime startTime = DateTime.Now;

        while ((DateTime.Now - startTime).TotalSeconds < animationDurationSeconds){
            int consoleWidth = Console.WindowWidth;

            for (int i = 0; i < consoleWidth - 1; i++){
                Console.Write(" ");
            }

            Console.Write("*");

            TimeSpan remainingTime = TimeSpan.FromSeconds(animationDurationSeconds) - (DateTime.Now - startTime);
            Console.WriteLine($"\nRemaining Time: {remainingTime:mm\\:ss}"); // Display remaining time
            Thread.Sleep(100); // Adjust speed as needed
            Console.CursorLeft = 0;
        }

        Console.Clear();
    }

    public void PrepareActivity(){
        Console.Clear();
        Console.WriteLine($"The {this.activityName.ToLower()} activity will begin shortly.");
        this.AnimatePause();
    }

    public abstract void MainActivity(int activityDur);

    public void ExitActivity(){
        Console.WriteLine($"Thank you for participating in the {this.activityName.ToLower()} activity.");
        this.AnimatePause();
    }

    
    public void Run(){
        int activityDur = this.GetActivityDuration();
        this.PrepareActivity();
        this.MainActivity(activityDur);
        this.ExitActivity();
    }
}