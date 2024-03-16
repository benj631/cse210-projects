using System;

public class ChecklistGoal : Goal{

    int bonusPoints = 0;
    public ChecklistGoal(string goalName, int goalPoints, int bonusPoints) : base(goalName, goalPoints){

        this.bonusPoints = bonusPoints;
    }

    public override void ShowProgress(){
        Console.WriteLine(this.goalName);
        Console.WriteLine(this.goalPoints);
    }


    

}