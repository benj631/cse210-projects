using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

public static class ProgramFlow{
    
    private static Journal _curJournal = new Journal();

    public static Journal curJournal{
        get { return _curJournal; }
    }

    public static void loadNewJournal(Journal newJournal){
        _curJournal = newJournal;
    }

    public static readonly List<string> optionList =
    [
        "Write a new entry",
        "Display all entries in the journal",
        "Save the journal to a file",
        "Load the journal from a file",
        "Add a prompt to the list of prompts",
        "Quit"
    ];

    public static int writeJSONToFile(List<Dictionary<string,string>> journalJSON,string journalPath){

        string journalJSONString = JsonSerializer.Serialize(journalJSON);

        // Write the JSON string to the file
        try{
            File.WriteAllText(journalPath, journalJSONString);
            Console.WriteLine($"Journal saved to: {journalPath}");
            return 0; // Success
        } catch (FileNotFoundException ex){
            Console.WriteLine("Error writing file.");
            return 1; // Error
        }

    }

    public static int ReadJSONFileToJournal(string journalPath){
        
        try {
            string JSONString = File.ReadAllText(journalPath);
            Journal journal = new();
            journal.JSONFileToJournal(JSONString);
            ProgramFlow.loadNewJournal(journal);
            Console.WriteLine("Journal successfully read from file and stored.");

        } catch (FileNotFoundException ex) {
            Console.WriteLine("There was an issue reading from the file.");
            return 1; //err
        }
            
        Console.WriteLine("There was an issue reading from the file.");
        return 1; //err
    }

    public static void Init()
    {
        int optionSelected = 0;
        bool mainLoop = true;

        while (mainLoop){
            Console.WriteLine("Welcome to the Journal Program. Please select an option (#)");
            for (int i = 0; i < optionList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {optionList[i]}");
            }

            try
            {
                optionSelected = int.Parse(Console.ReadLine());
                // break;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Sorry, that was an invalid input, please try again");
            }

            // New Entry
            if (optionSelected == 1){
                Console.WriteLine("Let's add a new entry to the journal.");
                Entry entry = new Entry("","","");
                entry.NewEntry();

                //Check if the save happened by comparing to empty string
                if (entry.entryPrompt != ""){
                    curJournal.SaveEntry(entry);
                }
            }

            // Display All Entries
            if (optionSelected == 2){
                curJournal.DisplayJournal();
            }

            // Save Journal to a File
            if (optionSelected == 3){
                Console.WriteLine("Enter the path to the journal file:");
                string journalPath = Console.ReadLine();
                List<Dictionary<string,string>> journalJSON = curJournal.JournalToJSON();
                ProgramFlow.writeJSONToFile(journalJSON,journalPath);
            }

            // Load the Journal from a File
            if (optionSelected == 4){
                Console.WriteLine("Enter the path to the journal file:");
                string journalPath = Console.ReadLine();
            }

            // Add a prompt
            if (optionSelected == 5){
                bool promptVerify = true;
                Console.WriteLine("Enter a prompt to add:");
                string newPrompt = Console.ReadLine();
                newPrompt = Regex.Replace(newPrompt, "\"", "'");

                Console.WriteLine("Add prompt? (y/n)");
                string response = Console.ReadLine();
                while (promptVerify){
                    if (response == "y"){
                        Prompt.AddPrompt(newPrompt);
                        Console.WriteLine("Prompt successfully added");
                        promptVerify = false;
                    } else if (response == "n"){
                        Console.WriteLine("Prompt not added.");
                        promptVerify = false;
                    } else {
                        Console.WriteLine("Response invalid.");
                        Console.WriteLine("Enter a prompt to add:");
                        newPrompt = Console.ReadLine();
                        newPrompt = Regex.Replace(newPrompt, "\"", "'");
                        Console.WriteLine("Add prompt? (y/n)");
                    }
                }  
            }

            // Quit
            if (optionSelected == 6){
                Console.WriteLine("Thank you for using the journal program.");
                Environment.Exit(0);
            }
        }
    }
}