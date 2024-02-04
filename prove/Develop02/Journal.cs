using System.Text.Json;

public class Journal{
    List<Entry> journalEntries = new();

    public void SaveEntry(Entry entry){
        this.journalEntries.Add(entry);
    }

    public void DisplayJournal(){
        foreach (Entry entry in this.journalEntries){
            entry.DisplayEntry();
        }
    }

    public List<Dictionary<string,string>> JournalToJSON(){
        List<Dictionary<string,string>> entryJSONList = new();
        Dictionary<string,string> curEntryJSON = new();

        foreach (Entry entry in this.journalEntries){
            curEntryJSON = entry.EntryToEntryDict();
            entryJSONList.Add(curEntryJSON);
        }

        return entryJSONList;
    }
    
    public void JSONFileToJournal(string JSONString){

        // Deserialize the JSON string into a list of dictionaries
        List<Dictionary<string, string>> entryListOfDictionaries = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(JSONString);

        foreach (Dictionary<string,string> entry in entryListOfDictionaries){
            Entry curEntry = new Entry(entry["prompt"],entry["userEntry"],entry["entryDate"]);
            this.SaveEntry(curEntry);
        }
    }
}