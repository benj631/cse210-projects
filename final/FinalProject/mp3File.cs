using System;
using System.Diagnostics;
using System.IO;
using System.Net;

public class mp3File : SystemFile{
    
    private string filePath = "";
    private string fileName = "";
    private double fileSize = 0;
    private DateTime dateCreated = new();
    private DateTime lastModified = new();

    string title = "";
    string artist = "";
    string album = "";

    bool hasAlbumArt = false;

    TimeSpan songDuration = new();
    public mp3File(string filePath) : base(filePath){
        this.filePath = filePath;
        this.GetMetaData();
    }

    public override void GetMetaData(){
        // not written

    }
    public override void ViewMetaData(){
        
        Console.WriteLine("Title: " + title);
        Console.WriteLine("Artist(s): " + artist);
        Console.WriteLine("Album: " + album);
        Console.WriteLine("Duration: " + songDuration.ToString(@"hh\:mm\:ss")); // Format the TimeSpan
        Console.WriteLine("Has Album Art: " + hasAlbumArt);
    }

    public override string GetEditOption(){
        while (true) {
            Console.WriteLine("Select a field to edit:");
            Console.WriteLine("1. Title");
            Console.WriteLine("2. Artist");
            Console.WriteLine("3. Album");

            string input = Console.ReadLine();

            switch (input){
                case "1":
                    return "title:";
                case "2":
                    return "artist:";
                case "3":
                    return "album:";
                default:
                    Console.WriteLine("No valid option selected, try again.");
                    throw new InvalidOperationException("Invalid option selected.");

            }
        }
    }

    public override void ChangeMetaData(string toChange, string newValue){
        string audioFile = "";
        // This should never run
        if (audioFile == null){
            GetMetaData();
        }
        // Modify metadata based on the input parameter
        
        // Save the changes back to the file
        try {
            // audioFile.Save();
            Console.WriteLine($"{toChange} changed to {newValue} successfully.");
        }
        catch (Exception ex){
            Console.WriteLine($"An error occurred while saving changes: {ex.Message}");
        }

    }
    
}
