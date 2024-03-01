using System;
using System.Diagnostics;


public class Breathing : Activity{
    public Breathing(string activityName, string activityDesc, int pauseDur) : base(activityName, activityDesc, pauseDur){
        
    }

    public override void MainActivity(int activityDur){
        Stopwatch stopwatch = Stopwatch.StartNew();

        while (stopwatch.ElapsedMilliseconds < activityDur * 1000){

            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Breath in...");
            this.AnimatePause();
            Console.WriteLine("Breathe out...");
            this.AnimatePause();
        }

        stopwatch.Stop();
    }

    
}