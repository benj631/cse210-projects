using System;

public class Room{
    public string roomName = "";
    public List<SmartDevice> devices = new();

    public Room(string roomName, List<SmartDevice> devices){
        this.roomName = roomName;
        this.devices = devices;
    }

    public void TurnOnAllLights(){
        foreach (SmartDevice device in devices){
            if (device.deviceType == "Smart Light"){
                device.TurnOnDevice();
            }
        }
    }

    public void TurnOffAllLights(){
        foreach (SmartDevice device in devices){
            if (device.deviceType == "Smart Light"){
                device.TurnOffDevice();
            }
        }
    }

    public void TurnOnAllDevices(){
        foreach (SmartDevice device in this.devices){
            device.TurnOnDevice();
        }
    }

    public void TurnOffAllDevices(){
        foreach (SmartDevice device in this.devices){
            device.TurnOffDevice();
        }
    }

    public void DisplayAllDevicesOn(){
        foreach (SmartDevice device in this.devices){
            if (device.isOn){
                device.DisplayStatus();
            }
        }
    }

    public void DisplayStatuses(){
        foreach (SmartDevice device in devices){
            device.DisplayStatus();
        }
    }

    public Dictionary<string, TimeSpan> GetDurations(){
    
        Dictionary<string, TimeSpan> durations = new Dictionary<string, TimeSpan>();

        foreach (SmartDevice device in devices){
            TimeSpan deviceOnDuration = DateTime.Now - device.initialOnTime;
            durations.Add(device.deviceName, deviceOnDuration);
        }
        
        return durations;
    }

    
}