using System;

public class DailyGoal : Goal{

    public new string goalType = "Daily";
    public bool doneToday = false;
    public int daysDone = 0;
    public int bonusPointsMilestoneIncrement;
    public int bonusPoints;

    public DailyGoal(string goalName, int goalPoints,int bonusPoints, int bonusPointsMilestoneIncrement) : base(goalName, goalPoints){
        this.goalPoints = goalPoints;
        this.goalToReach = this.goalPoints;
        this.bonusPoints = bonusPoints;
        this.bonusPointsMilestoneIncrement = bonusPointsMilestoneIncrement;

    }

    public void SetDoneToday(){
        doneToday = true;
        daysDone += 1;
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
            return this.goalPoints + this.bonusPoints;
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
            { "bonusPoints", this.bonusPoints},
            { "bonusPointsMilestoneIncrement", this.bonusPointsMilestoneIncrement},
            { "goalProgress", this.goalProgress },
            { "goalToReach", this.goalToReach },
            { "goalAchieved", this.goalAchieved },
            { "doneToday", this.doneToday },
            { "daysDone", this.daysDone }
        };

        return goalDict;
    }
}