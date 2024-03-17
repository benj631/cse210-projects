using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;

class ProgramFlow{

    private List<string> options = new List<string>{
        "Add new goal",
        "Show all goals",
        "Add Progress to a Goal",
        "Get total score",
        "Store user data",
        "Retrieve user data"
    };

    private List<string> goalTypes = new List<string>{
        "Checklist",
        "Eternal",
        "Simple",
        "Daily"
    };

    public void Init(){
        UserData userData = new();
        bool continueMainLoop = true;

        while (continueMainLoop){
            int userSelectionMain = GetUserSelectionMain();

            if (userSelectionMain == 1){
                string goalType = GetGoalType();
                Goal newGoal = CreateNewGoalFromUserInput(goalType);
                userData.goalList.Add(newGoal);
                Console.WriteLine("Goal successfully created!");
            }

            if (userSelectionMain == 2){
                foreach(Goal goal in userData.goalList){
                    goal.DisplayGoal();
                }
            }

            if (userSelectionMain == 3){
                Console.WriteLine("Enter the goal name:");
                string goalName = Console.ReadLine();

                // Find the goal from the userData.goalList
                Goal goal = userData.goalList.FirstOrDefault(g => g.goalName == goalName);

                if (goal != null)
                {
                    // Display the current progress and options for modification
                    Console.WriteLine($"Current progress of {goal.goalName}: {goal.goalProgress}/{goal.goalToReach}");
                    Console.WriteLine("Choose modification:");
                    Console.WriteLine("1. Add 1 progress");
                    Console.WriteLine("2. See progress");

                    // Get the user's choice
                    int choice = GetIntegerInput("Enter your choice:");

                    // Perform the selected modification
                    switch (choice)
                    {
                        case 1:
                            // Add 1 progress to the goal
                            goal.AdvanceGoalProgress();
                            Console.WriteLine("1 progress added.");
                            if (goal.goalProgress == goal.goalToReach){

                                goal.goalAchieved = true;
                                Console.WriteLine("Goal achieved!");
                            }
                            break;
                        case 2:
                            // Add bonus points to the goal
                            Console.WriteLine($"Progress: {goal.GetProgress()}");
                            Console.WriteLine($"Score: {goal.GetProgress()}");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                } else {
                    Console.WriteLine("Goal not found.");
                    }
                }

            if (userSelectionMain == 4){
                int totalScore = 0;
                foreach (Goal goal in userData.goalList){
                    totalScore += goal.GetCurScore();
                }
                Console.WriteLine($"Your total score is: {totalScore}");
            }

            if (userSelectionMain == 5){
                Console.WriteLine("Converting goals...");

                List<Dictionary<string, object>> goalDictionaries = new List<Dictionary<string, object>>();

                foreach (Goal goal in userData.goalList){
                    Dictionary<string, object> goalDict = goal.ConvertToDict();
                    goalDictionaries.Add(goalDict);
                }

                // Validate path to store stuff.

                string pathToValidate;

                do {
                    Console.WriteLine("Enter a path to validate:");
                    pathToValidate = Console.ReadLine();

                    if (ValidatePath(pathToValidate)) {
                        Console.WriteLine("The path is valid.");
                        break; // Exit the loop if a valid path is provided

                    } else {
                        Console.WriteLine("The path is invalid. Please try again.");
                    }
                    
                } while (true); // Loop until a valid path is provided

                string path = pathToValidate;
                
                bool success = userData.WriteDataToFile(goalDictionaries, path);
                if (success){
                    Console.WriteLine("Goals data written to file successfully.");
                } else {
                    Console.WriteLine("Failed to write goals data to file.");
                }
            }

            if (userSelectionMain == 6){
                Console.WriteLine("Retrieving data from file...");

                string pathToValidate;

                do {
                    Console.WriteLine("Enter a path to validate:");
                    pathToValidate = Console.ReadLine();

                    if (ValidatePath(pathToValidate)) {
                        Console.WriteLine("The path is valid.");
                        break; // Exit the loop if a valid path is provided

                    } else {
                        Console.WriteLine("The path is invalid. Please try again.");
                    }
                    
                } while (true); // Loop until a valid path is provided
                
                string path = pathToValidate;
                List<Dictionary<string, object>> goalDictList = new();
                bool success = userData.ReadDataFromFile(path, out goalDictList);

                if (success){
                // Data read successfully, use goalDictList
                    foreach (Dictionary<string, object> dict in goalDictList){
                        foreach (var kvp in dict){
                            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
                        }
                        Goal newGoal = userData.CreateGoalFromJSON(dict);
                        userData.goalList.Add(newGoal);
                    }
                } else {
                    // Failed to read data from file
                    Console.WriteLine("Failed to read data from file.");
                }
            }
        
        continueMainLoop = ValidateContinue();
        }
    }

    private static bool ValidateContinue(){
        while (true){
            Console.WriteLine("Do you want to continue? (y/n):");
            string userInput = Console.ReadLine();

            // Verify the input
            if (userInput.ToLower() == "y") {
                // User wants to continue
                return true;
            } else if (userInput.ToLower() == "n") {
                // User wants to exit
                Console.WriteLine("Good luck with your goals!");
                return false;
            } else {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
            }
        } 
    }

    static int GetIntegerInput(string prompt){
        int input;
        bool isValid;
        do{
            Console.WriteLine(prompt);
            isValid = int.TryParse(Console.ReadLine(), out input);
        } while (!isValid);
        return input;
    }

    private string GetGoalType(){
        string selectedGoalType = "";
        while (true) {
            Console.WriteLine("Select a goal type to add:");
            
            // Print out the available goal types
            for (int i = 0; i < goalTypes.Count; i++){
                Console.WriteLine($"{i + 1}. {goalTypes[i]}");
            }

            // Read user input
            if (int.TryParse(Console.ReadLine(), out int selection)){
                // Check if the selection is within the valid range
                if (selection >= 1 && selection <= goalTypes.Count){
                    selectedGoalType = goalTypes[selection - 1]; // Adjust for zero-based index
                    break; // Exit the loop if a valid selection is made
                } else {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            } else {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        
        return selectedGoalType;
    }

    public int GetUserSelectionMain(){
        int selection;
        while (true)
        {
            // Display options with numbers
            for (int i = 0; i < options.Count; i++){
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            // Prompt user for input
            Console.Write("Please select an option: ");
            if (int.TryParse(Console.ReadLine(), out selection)){
                // Validate the selection
                if (selection >= 1 && selection <= options.Count){
                    Console.WriteLine($"You selected: {options[selection - 1]}");
                    break; // Exit the loop if a valid selection is made
                } else {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            } else {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            Console.WriteLine(); // Add a blank line for better readability
        }
        return selection;
    }

    public Goal CreateNewGoalFromUserInput(string goalType){

    Console.WriteLine("Enter goal name:");
    string goalName = Console.ReadLine();

    Console.WriteLine("Enter goal points:");
    int goalPoints = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter goal measurement:");
    string goalMeasurement = Console.ReadLine();

    Console.WriteLine("Enter goal progress:");
    int goalProgress = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter goal to reach:");
    int goalToReach = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter goal achieved (true/false):");
    bool goalAchieved = bool.Parse(Console.ReadLine());

    switch (goalType)
        {
            case "Simple":
                return new SimpleGoal(goalName, goalPoints)
                {
                    goalMeasurement = goalMeasurement,
                    goalProgress = goalProgress,
                    goalToReach = goalToReach,
                    goalAchieved = goalAchieved
                };

            case "Checklist":
                Console.WriteLine("Enter bonus points:");
                int bonusPoints = int.Parse(Console.ReadLine());
                return new ChecklistGoal(goalName, goalPoints, bonusPoints, goalToReach)
                {
                    goalMeasurement = goalMeasurement,
                    goalProgress = goalProgress,
                    goalToReach = goalToReach,
                    goalAchieved = goalAchieved
                };

            case "Eternal":
                Console.WriteLine("Enter bonus points:");
                int eternalBonusPoints = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points milestone increment:");
                int bonusPointsMilestoneIncrement = int.Parse(Console.ReadLine());
                return new EternalGoal(goalName, goalPoints, eternalBonusPoints, bonusPointsMilestoneIncrement)
                {
                    goalMeasurement = goalMeasurement,
                    goalProgress = goalProgress,
                    goalToReach = goalToReach,
                    goalAchieved = goalAchieved
                };

            case "Daily":
                Console.WriteLine("Enter bonus points:");
                int dailyBonusPoints = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter done today (true/false):");
                bool doneToday = bool.Parse(Console.ReadLine());
                Console.WriteLine("Enter days done:");
                int daysDone = int.Parse(Console.ReadLine());
                return new DailyGoal(goalName, goalPoints, dailyBonusPoints, goalToReach)
                {
                    goalMeasurement = goalMeasurement,
                    goalProgress = goalProgress,
                    goalToReach = goalToReach,
                    goalAchieved = goalAchieved,
                    doneToday = doneToday,
                    daysDone = daysDone
                };

            default:
                Console.WriteLine("Invalid goal type.");
                Environment.Exit(1);
                return null;
        }
    }

    static bool ValidatePath(string path){
        try
        {
            // Attempt to get the full path
            string fullPath = Path.GetFullPath(path);

            // Check if the full path is the same as the provided path
            // This ensures that the path is valid and doesn't contain any invalid characters
            return fullPath.Equals(path, StringComparison.OrdinalIgnoreCase);
        }
        catch (Exception)
        {
            // If an exception occurs, the path is invalid
            return false;
        }
    }

}