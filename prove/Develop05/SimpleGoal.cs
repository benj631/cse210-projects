using System;

public class SimpleGoal : Goal{

    public new string goalType = "Simple";

    public SimpleGoal(string goalName, int goalPoints) : base(goalName, goalPoints){
        this.goalPoints = goalPoints;
        this.goalToReach = this.goalPoints;
    }

    public override void ShowProgress(){
        Console.WriteLine(goalName);
        Console.WriteLine(this.goalProgress);
        Console.WriteLine($"Goal Achieived: {goalAchieved}");
    }

    public override void DisplayGoal(){
        ShowProgress();
    }

    public override int GetCurScore(){
        if (goalAchieved == true){
            return this.goalPoints;
        } else {
            return 0;
        }
    }

    public override void AdvanceGoalProgress(){
        this.goalProgress = this.goalPoints;
    }

    public override Dictionary<string, object> ConvertToDict(){
        Dictionary<string, object> goalDict = new Dictionary<string, object>{
            { "goalName", this.goalName },
            { "goalType", this.goalType },
            { "goalMeasurement", this.goalMeasurement },
            { "goalPoints", this.goalPoints },
            { "goalProgress", this.goalProgress },
            { "goalToReach", this.goalToReach },
            { "goalAchieved", this.goalAchieved }
        };
        return goalDict;
    }

}