using System;
using System.Diagnostics;
using System.IO;
using System.Net;


public class txtFile : SystemFile{
    
    private string filePath = "";
    private string fileName = "";
    private double fileSize = 0;
    private DateTime dateCreated = new();
    private DateTime lastModified = new();

    public txtFile(string filePath) : base(filePath){

    }

    public override void EditTxt(){
        Console.WriteLine("Enter the path of the text file:");
        string filePath = Console.ReadLine();

        try{
            // Open the text file or create a new one if it doesn't exist
            using (StreamWriter writer = File.AppendText(filePath)){
                Console.WriteLine($"Enter text. Press Escape to save and exit.");

                // Read user input until Escape key is pressed
                while (true){
                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    // Check if the Escape key is pressed
                    if (keyInfo.Key == ConsoleKey.Escape){
                        break; // Exit the loop and save the entry
                    }

                    // Write the entered character to the file
                    writer.Write(keyInfo.KeyChar);
                }
            }

            Console.WriteLine("Entry saved successfully.");
        } catch (Exception ex) {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
