using System.Text.Json;

public class Journal{
    List<Entry> journalEntries = new();

    public void saveEntry(Entry entry){
        this.journalEntries.Add(entry);
    }

    public void displayJournal(){
        foreach (Entry entry in this.journalEntries){
            entry.displayEntry();
        }
    }

    public List<Dictionary<string,string>> journalToJSON(){
        List<Dictionary<string,string>> entryJSONList = new();
        Dictionary<string,string> curEntryJSON = new();

        foreach (Entry entry in this.journalEntries){
            curEntryJSON = entry.entryToEntryDict();
            entryJSONList.Add(curEntryJSON);
        }

        return entryJSONList;
    }
    
    public void JSONFileToJournal(string JSONString){

        // Deserialize the JSON string into a list of dictionaries
        List<Dictionary<string, string>> entryListOfDictionaries = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(JSONString);

        foreach (Dictionary<string,string> entry in entryListOfDictionaries){
            Entry curEntry = new Entry(entry["prompt"],entry["userEntry"],entry["entryDate"]);
            this.saveEntry(curEntry);
        }
    }
}