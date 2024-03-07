using System;

class House{

    public List<Room> rooms = new();

    public List<string> options = new List<string>{
        "Turn on all lights",
        "Turn off all lights",
        "Turn on all devices",
        "Turn off all devices",
        "Show all devices that are on",
        "Show all statuses",
        "Show all statuses in a room",
        "Show the device that has been on the longest",
        "Interact with a device"
    };

    public void SetUpHouse(){
        SmartThermostat smartThermostat01 = new SmartThermostat("Smart Thermostat 01");
        SmartLight smartLight01 = new SmartLight("Smart Light 01");
        SmartToaster smartToaster01 = new SmartToaster("Smart Toaster 01");
        SmartTV smartTV01 = new SmartTV("Smart TV 01");

        SmartThermostat smartThermostat02 = new SmartThermostat("Smart Thermostat 02");
        SmartLight smartLight02 = new SmartLight("Smart Light 02");
        SmartLight smartLight03 = new SmartLight("Smart Light 02");
        SmartTV smartTV02 = new SmartTV("Smart TV 02");

        List<SmartDevice> kitchenDevices = new List<SmartDevice>{
            smartThermostat01,
            smartLight01,
            smartToaster01,       
            };

        List<SmartDevice> livingRoomDevices = new List<SmartDevice>{
            smartThermostat02,
            smartLight02,
            smartLight03,
            smartTV02         
            };

        Room kitchen = new Room("Kitchen", kitchenDevices);
        Room livingRoom = new Room("Living Room", livingRoomDevices);

        List<Room> houseRooms = new List<Room>{
            kitchen,
            livingRoom
        };

        this.rooms = houseRooms;
    }

    public void TurnOnAllLights(){
        foreach (Room room in this.rooms){
            room.TurnOnAllLights();
        }
    }

    public void TurnOffAllLights(){
        foreach (Room room in this.rooms){
            room.TurnOffAllLights();
        }
    }

    public void TurnOnAllDevices(){
        foreach (Room room in this.rooms){
            room.TurnOnAllDevices();
        }
    }

    public void TurnOffAllDevices(){
        foreach (Room room in this.rooms){
            room.TurnOffAllDevices();
        }
    }

    public void DisplayStatuses(){
        foreach (Room room in rooms){
            room.DisplayStatuses();
        }
    }

    public void DisplayAllDevicesOn(){
        foreach (Room room in this.rooms){
            room.DisplayAllDevicesOn();
        }
    }

    public void DisplayAllDevicesInRoom(string roomToDisplay){
        foreach (Room room in this.rooms){
            if (room.roomName == roomToDisplay){
                room.DisplayStatuses();
            } else {
                Console.WriteLine("Sorry, that room hasn't been added yet.");
            }
            
        }
    }


    public void ReportLongestOnDuration(){
        Dictionary<string,TimeSpan> durations = new();
        foreach (Room room in rooms){
            Dictionary<string,TimeSpan> roomDurations = room.GetDurations();
            foreach (var kvp in roomDurations){
                durations[kvp.Key] = kvp.Value;
            }
        }

        string longestOnDevice = "";
        TimeSpan longestDuration = TimeSpan.Zero;

        foreach (KeyValuePair<string, TimeSpan> kvp in durations){
            if (kvp.Value > longestDuration){
                longestDuration = kvp.Value;
                longestOnDevice = kvp.Key;
            }
        }

        Console.WriteLine($"The device that has been on the longest is {longestOnDevice} which has been on for {longestDuration.TotalMinutes} minutes and {longestDuration.Seconds} seconds");
    }

    public void HandleUserSelection(){
        Console.WriteLine("Please select an option:");
        foreach (string option in options){
            Console.WriteLine(option);
        }
        
        bool continueMainLoop = true;

        while(continueMainLoop){


            int selection = 0;
            bool validSelection = false;

            while (!validSelection){
                try{
                    selection = int.Parse(Console.ReadLine()) - 1;

                    if (selection < 0 || selection > 8){
                        Console.WriteLine("Sorry, your selection was invalid.");
                    } else {
                        validSelection = true; // Set validSelection to true only if the input is valid
                    }
                } catch (FormatException) {
                    Environment.Exit(1); // Handle FormatException here if necessary
                }
            }
            
            switch (selection){
                // "Turn on all lights",
                case 0:
                    Console.WriteLine("Turning on all lights...");
                    this.TurnOnAllLights();
                    Console.WriteLine("All lights turned on.");

                // "Turn off all lights",
                    break;
                case 1:
                    Console.WriteLine("Turning off all lights...");
                    this.TurnOffAllLights();
                    Console.WriteLine("All lights turned off");
                    break;
                // "Turn on all devices",
                case 2:
                    Console.WriteLine("Turning on all devices...");
                    this.TurnOnAllDevices();
                    Console.WriteLine("All devices turned on.");
                    break;
                // "Turn off all devices",
                case 3:
                    Console.WriteLine("Turning off all devices.");
                    this.TurnOffAllDevices();
                    Console.WriteLine("All devices turned off.");
                    break;
                // "Show all devices that are on",
                case 4:
                    Console.WriteLine("Showing all devices that are on...");
                    this.DisplayAllDevicesOn();
                    Console.WriteLine("All devices displayed.");
                    break;
                // "Show all statuses",
                case 5:
                    Console.WriteLine("Showing all statuses...");
                    this.DisplayStatuses();
                    Console.WriteLine("All statuses displayed.");
                    break;
                // "Show all statuses in a room",
                case 6:
                    string roomName = Console.ReadLine();
                    foreach (Room room in rooms){
                        if (roomName == room.roomName){
                            room.DisplayStatuses();
                        } else {
                            Console.WriteLine("Sorry, no rooms match that name.");
                        }
                    } 
                    break;
                // "Show the device that has been on the longest",
                case 7:
                    this.ReportLongestOnDuration();
                    break;
                // "Interact with a device"
                case 8:
                    Console.WriteLine("Enter a device to interact with:");
                    string deviceToInteractWith = Console.ReadLine();

                    foreach (Room room in rooms){
                        foreach (SmartDevice device in room.devices){
                            if (device.deviceName == deviceToInteractWith){
                                device.DisplayStatus();
                                device.DisplayOptions();
                            }
                        }
                    }
                    // put code here to validate stuff. !!!
                    break;

                // else
                default:
                        break;
            }
            
            validSelection = false;

            Console.WriteLine("Would you like to continue making actions? y/n");

            string makeAnotherAction = "";

            while (!validSelection){
                makeAnotherAction = Console.ReadLine();
                if (makeAnotherAction != "n" || makeAnotherAction == "y" ){
                        validSelection = true; // Set validSelection to true only if the input is valid
                    } else {
                        Console.WriteLine("Sorry, your selection was invalid.");
                        Console.WriteLine("Would you like to continue making actions? y/n");
                    }
                }
            
            if (makeAnotherAction == "n"){
                continueMainLoop = false;
                Console.WriteLine("Thank you for using your Smart Home.");
            }
        }
    }

    public void Init(){
        this.SetUpHouse();
        this.HandleUserSelection();
    }
}