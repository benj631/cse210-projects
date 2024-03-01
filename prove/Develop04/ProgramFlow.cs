using System;
using System.Collections.Generic;

public class ProgramFlow{

    Dictionary<string,string> activityDescriptions = new Dictionary<string, string>(){
        {"Breathing","This activity will help you relax by pacing your breathing. Allow your focus to settle on just the breath, and your mind to be clear."},   
        {"Reflecting","This activity will help you gain strength and resilience by helping you reflect on memories. Allow your mind to be clear and calm."},
        {"Listing","This activity will help you exercise gratitude by listing things in certain areas. Allow ideas to come freely to your mind."}
    };

    List<Activity> activities = new();

    List<string> menuOptions = new List<string> {"Breathing", "Reflecting", "Listing"};
    public void Init(){
        
        bool continueLoopInit = true;

        while (continueLoopInit){
            Activity curActivity = this.GetActivitySelection();
            Console.WriteLine($"You have selected the activity: {curActivity.activityName}");
            Console.Clear();
            curActivity.Run();
            continueLoopInit = GetContinue();
        }
        
    }

    public bool GetContinue(){
        
        Console.WriteLine("Would you like to do another activity? (y/n)");
        
        string response = Console.ReadLine();
        if (response == "y"){
            return true;
        } else {
            Console.WriteLine("Invalid response. Thank you for participating in the activity.");
            return false;
        }
    }

    public void SetActivityVars(){
            Breathing breathing = new Breathing("Breathing", activityDescriptions["Breathing"],5);
            Reflecting reflecting = new Reflecting("Reflecting", activityDescriptions["Reflecting"],5);
            Listing listing = new Listing("Breathing", activityDescriptions["Listing"],5);

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
        } catch (FormatException){
            Console.WriteLine("Sorry, that's an invalid selection. Please restart the program.");
            Environment.Exit(1);
        }
        return activities[selected - 1];
    }


}
