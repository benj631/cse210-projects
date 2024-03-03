using System;
using System.Collections.Generic;

public class ProgramFlow{

    Dictionary<string,string> activityDescriptions = new Dictionary<string, string>(){
        {"Breathing","This activity will help you relax by pacing your breathing. Allow your focus to settle on just the breath, and your mind to be clear."},   
        {"Reflecting","This activity will help you gain strength and resilience by helping you reflect on memories. Allow your mind to be clear and calm."},
        {"Listing","This activity will help you exercise gratitude by listing things in certain areas. Allow ideas to come freely to your mind."}
    };

    public List<Activity> activities = new();

    private int activitiesDone = 0;
    
    List<string> menuOptions = new List<string> {"Breathing", "Reflecting", "Listing"};
    public void Init(){
        this.SetActivityVars();
        bool continueLoopInit = true;

        while (continueLoopInit){
            Activity curActivity = this.GetActivitySelection();
            Console.WriteLine($"You have selected the activity: {curActivity.activityName}");
            this.ClearConsoleIfNotRedirected();
            curActivity.Run();
            this.activitiesDone += 1;
            Console.WriteLine($"You have done the following number of activities: {activitiesDone}");
            continueLoopInit = GetContinue();
        }
        
    }

    public bool GetContinue(){
        
        Console.WriteLine("Would you like to do another activity? (y/n)");
        
        string response = Console.ReadLine();
        if (response == "y"){
            return true;
        } else if (response == "n") {
            Console.WriteLine("Thank you for participating.");
            return false;
        } else {
            Console.WriteLine("Invalid response - Thank you for participating.");
           return false;
        }
    }

    public void SetActivityVars(){
            Breathing breathing = new Breathing("Breathing", activityDescriptions["Breathing"],5);
            Reflecting reflecting = new Reflecting("Reflecting", activityDescriptions["Reflecting"],5);
            Listing listing = new Listing("Listing", activityDescriptions["Listing"],5);

            activities.Add(breathing);
            activities.Add(reflecting);
            activities.Add(listing);
    }

    public void PrintMenuOptions(){
        int i = 0;
        foreach (Activity activity in activities){
            Console.WriteLine($" Activity {i+1}: {activity.activityName} \n");
            Console.WriteLine($"{activity.activityDescription}");
            i++;
        }
    }

    public Activity GetActivitySelection(){
        this.PrintMenuOptions();
        int selected = 0;
        Console.WriteLine("Please enter the activity number:");
        try {
            selected = int.Parse(Console.ReadLine());
            if (selected < 1 || selected > activities.Count){
                throw new ArgumentOutOfRangeException(nameof(selected), "Invalid activity number. Please select a valid activity number.");
            }
        } 
        catch (FormatException){
            Console.WriteLine("Sorry, that's an invalid selection. Please restart the program.");
            Environment.Exit(1);
        }
        
        return activities[selected - 1];
    }

    public void ClearConsoleIfNotRedirected(){
        if (!Console.IsOutputRedirected){
            try {
                Console.Clear();
            } catch (IOException ex){
                // Handle the exception gracefully
                Console.WriteLine($"Failed to clear the console: {ex.Message}");
            }
        }
    }

}
