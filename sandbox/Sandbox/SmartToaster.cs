using System;

public class SmartToaster : SmartDevice{

    public List<string> interactOptions = new List<string>{
        "1. Turn on",
        "2. Turn off",
        "3. See how long it has been on",
        "4. See status"
    };
    private const int DefaultToastDurationSeconds = 120; // Default duration for toasting in econds

    public SmartToaster(string deviceName = "SmartToaster") : base(deviceName){
        this.deviceType = "Smart Toaster";
    }

    public void ToastBread(){
         Console.WriteLine("Toasting...");
        ToastBreadWithDuration(DefaultToastDurationSeconds);
    }

    public void ToastBreadWithDuration(int durationSeconds){
        // Simulate toasting process
        Console.WriteLine($"Toasting bread for {durationSeconds} seconds...");
        // Code to toast bread for specified duration
        Console.WriteLine("Toast is ready!");
    }
}