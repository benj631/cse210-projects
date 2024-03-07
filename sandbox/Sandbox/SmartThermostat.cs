using System;

public class SmartThermostat : SmartDevice{
    private int defaultTemperature = 78;
    private int currentTemperature = 78;
    private int targetTemperature = 78;

    public List<string> interactOptions = new List<string>{
        "1. Turn on",
        "2. Turn off",
        "3. See how long it has been on",
        "4. See status",
        "5. See temperatures"
    };

    Dictionary<string, int> userProfile = new Dictionary<string, int>{
        { "mom", 75 },
        { "dad", 72 }
    };

    public SmartThermostat(string deviceName = "SmartThermostat") : base(deviceName){
        this.deviceType = "Smart Thermostat";
    }

    public void SetTemperatureValue(int temp){
        this.targetTemperature = temp;

        if (this.targetTemperature == this.currentTemperature){
            Console.WriteLine("The house is already at the target temperature");
        } else if (this.targetTemperature != this.currentTemperature){
            this.TurnOnDevice();
            Console.WriteLine($"Setting the temperature to {temp}");
        }
    }

    public void ExecuteProfile(string profile){

        // Check if the selected profile exists in the dictionary
        if (userProfile.ContainsKey(profile)){
            // Set the temperature according to the selected profile
            int temperature = userProfile[profile];

            Console.WriteLine($"Setting temperature to {temperature}°F for {profile}");
            SetTemperatureValue(temperature);
            
        } else {
            Console.WriteLine($"Profile '{profile}' not found.");
        }
    }

    public void SetTemperature(){
        Console.WriteLine("Please select an action");
        Console.WriteLine("1. Enter Desired temperature");
        Console.WriteLine("2. Run a profile");

        try {
            int action = int.Parse(Console.ReadLine());
            if (action == 1){
                Console.WriteLine("Please enter the target temperature");
                int temp = int.Parse(Console.ReadLine());
                this.SetTemperatureValue(temp);
            } else if (action == 2){
                Console.WriteLine("Please enter the profile to use");
                string profile = Console.ReadLine();
                this.ExecuteProfile(profile);
            }
        } catch (FormatException) {
            Console.WriteLine("Invalid input format. Please enter a valid number.");
        } catch (Exception ex) {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public override void DisplayStatus(){
        Console.WriteLine($"Device: {this.deviceName}");
        this.DisplayOnDurationStatus();
        Console.WriteLine($"The current temperature is {this.currentTemperature} degrees.");
    }

}
