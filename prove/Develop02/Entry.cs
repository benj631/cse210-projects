using System.Text.Json;
using System.Text.RegularExpressions;

public class Entry{
    public string entryPrompt = "";
    public string userEntry = "";
    public string entryDate = "";
    
    public Entry(string entryPrompt, string userEntry, string entryDate){
        this.entryPrompt = entryPrompt;
        this.userEntry = userEntry;
        this.entryDate = entryDate;
    }

    public string GetDate(){
        DateTime currentDateTime = DateTime.Now;
        string formattedDateTime = currentDateTime.ToString("yyyy, MM dd");
        return formattedDateTime;
    }
    
    // Turn an entry object into a dictionary. Use when turning journal to json
    public Dictionary<string, string> EntryToEntryDict(){
        Dictionary<string, string> entryDict = new();
        entryDict.Add("prompt",entryPrompt);
        entryDict.Add("userEntry",userEntry);
        entryDict.Add("entryDate",entryDate);

        return entryDict;
    }
    

    public void NewEntry(){
        string currentPrompt = Prompt.GetRandomPrompt();
        Console.WriteLine(currentPrompt);
        string userEntry = Console.ReadLine();
        userEntry = Regex.Replace(userEntry, "\"", "'");
        Console.WriteLine("Save entry? y/n");
        string response = Console.ReadLine();

        while (true)
        {
            if (response != "y" && response != "n")
            {
                Func<string, string> inputVerify = x =>
                {
                    Console.WriteLine("Sorry, that's not a valid response.");
                    Console.WriteLine("Save entry? y/n");
                    return Console.ReadLine().Trim().ToLower();  // Ensure lowercase for consistency
                };

                response = inputVerify(response);
            }
            else
            {
                break;  // Exit the loop if a valid response is provided
            }
        }

        if (response == "y")
        {
            this.entryPrompt = currentPrompt;
            this.userEntry = userEntry;
            this.entryDate = this.GetDate();
            Console.WriteLine("Entry saved.");

        }
        else if (response == "n")
        {
            this.entryPrompt = "";
            this.userEntry = "";
            this.entryDate = "";
            Console.WriteLine("Entry discarded.");
        }
        
    }
    
    public void DisplayEntry(){
        Console.WriteLine($"Prompt: {this.entryPrompt}");
        Console.WriteLine($"Entry: {this.userEntry}");
        Console.WriteLine($"Date: {this.entryDate}");
    }
}