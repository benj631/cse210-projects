using System;
using System.Diagnostics;

public abstract class SmartDevice {
    public string deviceType = "";
    public string deviceName;
    public bool isOn = false;

    public string isOnString = "off";
    public DateTime lastTurnedOff = new();
    public DateTime initialOnTime = new();

    public List<string> interactOptions;

    public SmartDevice(string deviceName){
        this.deviceName = deviceName;
        this.isOn = false;
    }

    public TimeSpan GetDuration(DateTime initial) {
        return DateTime.Now - initial;
    }

    public void SetIsOnString(){
        if (this.isOn){
            this.isOnString = "on";
        } else if (!this.isOn){
            this.isOnString = "off";
        }
    }

    public void TurnOnDevice(){
        this.isOn = true;
        this.SetIsOnString();
        this.initialOnTime = DateTime.Now;
    }

    public void TurnOffDevice(){
        this.isOn = false;
        this.SetIsOnString();
        this.lastTurnedOff = DateTime.Now;
    }
    public void DisplayIsOnStatus(){
        this.SetIsOnString();
        
        Console.WriteLine($"The {this.deviceName} is {isOnString}"); 
    }

    public void DisplayOnDurationStatus(){
        this.SetIsOnString();
        
        if (this.isOn){
            Console.WriteLine($"The {this.deviceName} has been on for {GetDuration(this.initialOnTime)}"); 
        }
    }

    public virtual void DisplayStatus(){
        Console.WriteLine($"Device: {this.deviceName}");
        this.DisplayOnDurationStatus();
    }

    public void DisplayOptions(){
        foreach (string option in this.interactOptions){
            Console.WriteLine(option);
        }
    }
    public virtual void ExecuteUserCommand(int command){
        // !!! execute code.
    }
}                                                              