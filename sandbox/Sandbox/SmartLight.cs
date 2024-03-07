using System;

class SmartLight : SmartDevice{

    public List<string> interactOptions = new List<string>{
        "1. Turn on",
        "2. Turn off",
        "3. See how long it has been on",
        "4. See status"
    };
    public SmartLight(string deviceName = "SmartLight") : base(deviceName){
        this.deviceType = "Smart Light";
    }

}