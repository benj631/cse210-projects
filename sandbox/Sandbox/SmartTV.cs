using System;

public class SmartTV : SmartDevice{

    public List<string> interactOptions = new List<string>{
        "1. Turn on",
        "2. Turn off",
        "3. See how long it has been on",
        "4. See status"
    };

    public SmartTV(string deviceName = "SmartTV") : base(deviceName){
        this.deviceType = "Smart TV";
    }

    public void WatchTV(int durationMinutes){
        // Simulate watching TV process
        Console.WriteLine($"Watching TV for {durationMinutes} minutes...");
        // Code to watch TV for specified duration
        Console.WriteLine("Enjoy your show!");
    }

    public void SetDuration(int durationMinutes){
        // Set the duration for watching TV
        Console.WriteLine($"Setting TV watching duration to {durationMinutes} minutes.");
    }
}