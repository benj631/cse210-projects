using System;
using System.Diagnostics;


public class Breathing : Activity{
    public Breathing(string activityName, string activityDesc, int pauseDur) : base(activityName, activityDesc, pauseDur){
    
    }

    public override void MainActivity(int activityDur){
        Stopwatch stopwatch = Stopwatch.StartNew();

        int remainingSeconds = activityDur;

        while ((stopwatch.ElapsedMilliseconds < activityDur * 1000) && remainingSeconds > 2 ){

            remainingSeconds = activityDur - (int)(stopwatch.ElapsedMilliseconds / 1000);
            Console.WriteLine("Breath in...");
            this.AnimatePause(" " +(remainingSeconds.ToString()) + " seconds remaining");

            remainingSeconds = activityDur - (int)(stopwatch.ElapsedMilliseconds / 1000);
            Console.WriteLine("Breathe out...");
            this.AnimatePause(" " + (remainingSeconds.ToString()) + " seconds remaining");

             
        }

        stopwatch.Stop();
    }

    
}