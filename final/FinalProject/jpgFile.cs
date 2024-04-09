using System;
using System.IO;
// using SixLabors.ImageSharp;


public class JpgFile : SystemFile{

    private string filePath = "";
    private string fileName = "";
    private double fileSize = 0;
    private DateTime dateCreated = new();
    private DateTime lastModified = new();
    private ushort cameraMake;
    private ushort shutterSpeed;
    private ushort iso = 0;

    public JpgFile(string filePath) : base(filePath)
    {
        GetMetaData();
    }

    public override void GetMetaData()
    {
        // not written
    }

    public override void ViewMetaData()
    {
        Console.WriteLine("Camera Make: " + cameraMake);
        Console.WriteLine("Shutter Speed: " + shutterSpeed);
        Console.WriteLine("ISO: " + iso);
    }

    public override string GetEditOption()
    {
        while (true)
        {
            Console.WriteLine("Select a field to edit: (#)");
            Console.WriteLine("1. Camera Make");
            Console.WriteLine("2. Shutter Speed");
            Console.WriteLine("3. ISO");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    return "make";
                case "2":
                    return "ss";
                case "3":
                    return "iso";
                default:
                    Console.WriteLine("No valid option selected, try again.");
                    break;
            }
        }
    }

    public override void ChangeMetaData(string toChange, string newValue)
    {
        try
        {
            Console.WriteLine("Doesn't exist yet");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving changes: {ex.Message}");
        }
    }
}