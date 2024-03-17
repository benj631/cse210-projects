using System;

public class ChecklistGoal : Goal{

    public new string goalType = "Checklist";
    private int bonusPoints = 0;

    public ChecklistGoal(string goalName, int goalPoints, int bonusPoints, int goalToReach) : base(goalName, goalPoints){
        this.goalToReach = goalToReach;
        this.bonusPoints = bonusPoints;
    }

    public override void ShowProgress(){
        Console.WriteLine(goalName);
        Console.WriteLine($"{goalProgress}/{goalToReach} {goalMeasurement}");
        Console.WriteLine($"Goal Achieived: {goalAchieved}");
    }

    public override void DisplayGoal(){
        Console.WriteLine($"Goal Name: {this.goalName}");
        Console.WriteLine($"Goal Points: {this.goalPoints}");
        Console.WriteLine($"Goal Progress: {this.goalProgress}");
    }

    public override string GetProgress(){
        return $"{goalProgress}/{goalToReach}";
    }

    public override int GetCurScore(){
        if (goalAchieved == true){
            return this.goalPoints/this.goalToReach + this.bonusPoints;
        } else {
            return this.goalPoints/this.goalToReach;
        }
    }

    public override void AdvanceGoalProgress(){
        this.goalProgress += 1;
    }
    
    public override Dictionary<string, object> ConvertToDict(){
        Dictionary<string, object> goalDict = new Dictionary<string, object>{
            { "goalName", this.goalName },
            { "goalType", this.goalType },
            { "goalMeasurement", this.goalMeasurement },
            { "goalPoints", this.goalPoints },
            { "bonusPoints", this.bonusPoints},
            { "goalProgress", this.goalProgress },
            { "goalToReach", this.goalToReach },
            { "goalAchieved", this.goalAchieved }
        };
        return goalDict;
    }


}