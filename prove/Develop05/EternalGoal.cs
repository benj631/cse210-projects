using System;

public class EternalGoal : Goal{

    public new string goalType = "Eternal";

    private int bonusPoints = 0;
    private int bonusPointsMilestoneIncrement = 0;

    public EternalGoal(string goalName, int goalPoints,int bonusPoints, int bonusPointsMilestoneIncrement) : base(goalName, goalPoints){
        this.goalPoints = goalPoints;
        this.bonusPoints = bonusPoints;
        this.goalToReach = this.goalPoints;
        this.bonusPointsMilestoneIncrement = bonusPointsMilestoneIncrement;
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
        return (this.goalProgress * this.goalPoints + (this.bonusPoints * (int)Math.Floor((double)this.goalProgress / this.bonusPointsMilestoneIncrement)));
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
            { "bonusPoints", this.bonusPoints},
            { "bonusPointsMilestoneIncrement", this.bonusPointsMilestoneIncrement},
            { "goalProgress", this.goalProgress },
            { "goalToReach", this.goalToReach },
            { "goalAchieved", this.goalAchieved }
        };
        return goalDict;
    }
}