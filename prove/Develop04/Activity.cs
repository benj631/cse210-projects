using System;

public abstract class Activity{
    public string activityName = "";
    public string activityDescription = "";
    int pauseDuration = 5; // Seconds

    public Activity(string activityName, string activityDesc, int pauseDur){
        
        this.activityName = activityName;
        this.activityDescription = activityDesc;
        this.pauseDuration = pauseDur;

    }

    public int GetActivityDuration(){
        Console.WriteLine("Please enter the amount of time you would like to do the activity for, \n");
        Console.WriteLine("or press enter to do the activity for the default duration.");
        
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

    public void AnimatePause(string addition=""){
        int animationDurationSeconds = this.pauseDuration;
        DateTime startTime = DateTime.Now;

        // Define the spinning sequence characters
        char[] spinningChars = { '/', '|', '\\', '-' };
        int currentIndex = 0;

        while ((DateTime.Now - startTime).TotalSeconds < animationDurationSeconds)
        {
            // Output the current spinning character
            Console.Write(spinningChars[currentIndex] + addition);

            // Wait for a short duration to control the spinning speed
            Thread.Sleep(500
            );

            foreach (char c in addition){
                DeletePreviousChar();
            }
            
            DeletePreviousChar();

            // Move to the next spinning character
            currentIndex = (currentIndex + 1) % spinningChars.Length;
        }

        // Clear the console after the animation is complete
        Console.Clear();
    }

// Method to delete the previously output character
static void DeletePreviousChar(){
        // Move the cursor back one position
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);

        // Replace the character with a space
        Console.Write(" ");
        
        // Move the cursor back again
        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
    }

    public void PrepareActivity(){
        Console.Clear();
        // Console.Clear();
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