using System;
using System.ComponentModel.DataAnnotations;

public abstract class Goal{
    public string goalName = "";
    public string goalType = "goal";

    public string goalMeasurement = "Things done";
    protected int goalPoints = 100;

    public int goalProgress = 0; // How many things we have done
    public int goalToReach = 10; // How many things required to achieve the goal
    public bool goalAchieved = false;

    public void SetProgress(int progress){
        this.goalProgress = progress;
    }

    public void SetGoalAchieved(bool achieved){
        this.goalAchieved = achieved;
    }

    public void SetGoalProgress(int progress){
        this.goalProgress = progress;
    }

    public Goal(string goalName, int goalPoints){
        this.goalName = goalName;
        this.goalPoints = goalPoints;
    }

    public virtual void DisplayGoal(){
        Console.WriteLine(this.goalName);
        Console.WriteLine(this.goalPoints);
        Console.WriteLine(this.goalProgress);

    }

    public virtual void ShowProgress(){
        Console.WriteLine($"Progress: {goalProgress} {goalMeasurement}");
    }

    public virtual string GetProgress(){
        return $"Progress: {goalProgress} {goalMeasurement}";
    }

    public virtual int GetCurScore(){
        return 0;
    }

    public virtual void AdvanceGoalProgress(){
    }

    public virtual Dictionary<string, object> ConvertToDict(){
        Dictionary<string, object> goalDict = new Dictionary<string, object>{
            { "goalName", this.goalName },
            { "goalMeasurement", this.goalMeasurement },
            { "goalPoints", this.goalPoints },
            { "goalProgress", this.goalProgress },
            { "goalToReach", this.goalToReach },
            { "goalAchieved", this.goalAchieved }
        };
        return goalDict;
    }

}