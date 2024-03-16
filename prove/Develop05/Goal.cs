using System;
using System.ComponentModel.DataAnnotations;

public abstract class Goal{
    private string goalName = "";
    private string goalMeasurement = "Things done";
    private int goalPoints = 100;

    private int goalProgress = 0;

    private int goalReach = 10;

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
        
    }

    public void SetProgress(int progress){
        this.goalProgress = progress;
    }





}