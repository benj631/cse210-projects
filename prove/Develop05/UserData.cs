using System;
using System.Text.Json;

public class UserData{
    public List<Goal> goalList = new();

    public void ShowGoalList(){
        foreach (Goal goal in goalList){
            goal.DisplayGoal();
        }
    }

    public void ShowGoalAchievement(){
        foreach (Goal goal in goalList){
            switch(goal.goalType){
                case "Simple":
                    if (goal.goalAchieved){
                        Console.WriteLine($"[X] {goal.goalName}");
                    } else {
                        Console.WriteLine($"[ ] {goal.goalName}");
                    }
                    break;
        
                case "Eternal":
                    Console.WriteLine($"{goal.GetProgress()} {goal.goalName}");
                    break;
                case "Checklist":
                    Console.WriteLine($"{goal.GetProgress()} {goal.goalName}");
                    break;
        
                default:
                    Console.WriteLine("Unknown goal type.");
                    Environment.Exit(1);
                break;
            }
        }
    }

    public void DisplayTotalScore(){
        foreach (Goal goal in goalList){

        }
    }

    public Goal CreateGoalFromJSON(Dictionary<string, object> goalDict){
    string goalType = (string)goalDict["goalType"];
    switch (goalType){

        case "Simple":
            SimpleGoal simple = new SimpleGoal((string)goalDict["goalName"], (int)goalDict["goalPoints"]);
            simple.goalMeasurement = (string)goalDict["goalMeasurement"];
            simple.goalProgress = (int)goalDict["goalProgress"];
            simple.goalToReach = (int)goalDict["goalToReach"];
            simple.goalAchieved = (bool)goalDict["goalAchieved"];
            return simple;

        case "Checklist":
            ChecklistGoal checklist = new ChecklistGoal((string)goalDict["goalName"], (int)goalDict["goalPoints"], (int)goalDict["bonusPoints"], (int)goalDict["goalToReach"]);
            checklist.goalMeasurement = (string)goalDict["goalMeasurement"];
            checklist.goalProgress = (int)goalDict["goalProgress"];
            checklist.goalToReach = (int)goalDict["goalToReach"];
            checklist.goalAchieved = (bool)goalDict["goalAchieved"];
            return checklist;

        case "Eternal":
            EternalGoal eternal = new EternalGoal((string)goalDict["goalName"], (int)goalDict["goalPoints"], (int)goalDict["bonusPoints"], (int)goalDict["bonusPointsMilestoneIncrement"]);
            eternal.goalMeasurement = (string)goalDict["goalMeasurement"];
            eternal.goalProgress = (int)goalDict["goalProgress"];
            eternal.goalToReach = (int)goalDict["goalToReach"];
            eternal.goalAchieved = (bool)goalDict["goalAchieved"];
            
            return eternal;

        case "Daily":
            DailyGoal daily = new DailyGoal((string)goalDict["goalName"], (int)goalDict["goalPoints"], (int)goalDict["bonusPoints"], (int)goalDict["goalToReach"]);
            daily.goalMeasurement = (string)goalDict["goalMeasurement"];
            daily.goalProgress = (int)goalDict["goalProgress"];
            daily.goalToReach = (int)goalDict["goalToReach"];
            daily.goalAchieved = (bool)goalDict["goalAchieved"];
            daily.doneToday = (bool)goalDict["doneToday"];
            daily.daysDone = (int)goalDict["daysDone"];
            
            return daily;

        default:
            Console.WriteLine("Invalid goalType given.");
            Environment.Exit(1);
            return null; // To satisfy return type requirement, though it should never reach here
        }
    }


    public bool WriteDataToFile(List<Dictionary<string, object>> data, string filePath){
        try{
            string jsonData = JSONSerialize(data);
            File.WriteAllText(filePath, jsonData);
            return true;
        } catch (Exception ex){
            Console.WriteLine($"Error writing data to file: {ex.Message}");
            return false;
        }
    }

    public string JSONSerialize(List<Dictionary<string, object>> data){
        return JsonSerializer.Serialize(data);
    }

    public bool ReadDataFromFile(string filePath, out List<Dictionary<string, object>> result){
        result = null;
        try{
            if (File.Exists(filePath)){
                string jsonData = File.ReadAllText(filePath);
                result = JSONDeserialize(jsonData);
                return true;
            }else{
                Console.WriteLine("File does not exist.");
                return false;
            }
        } catch (Exception ex){
            Console.WriteLine($"Error reading data from file: {ex.Message}");
            return false;
        }
    }

    public List<Dictionary<string, object>> JSONDeserialize(string jsonData){
        return JsonSerializer.Deserialize<List<Dictionary<string, object>>>(jsonData);
    }

}