using System;
using System.Diagnostics;
using System.IO;
using System.Net;

class ProgramFlow {

    SystemFile fileLoaded;

    string fileLoadedExtension = "";

    List<string> options1 = new List<string> {
        "Show file information",
        "View metadata",
        "Edit metadata",
        "Edit file"
    };

    List<string> supportedFileTypes = new List<string> {
        "mp3",
        "jpg",
        "txt"
    };

    public ProgramFlow() {
    }

    public void Init() {
        bool continueMainLoop = true;

        while (continueMainLoop) {
            
            
            bool continueLoop01 = true;

            // Load file
            while (continueLoop01) {

                Console.WriteLine("Please enter the path of a file to load (txt, mp3, jpg):");
                string userFilePath = Console.ReadLine();

                if (!string.IsNullOrEmpty(userFilePath)) {
                    if (PathExists(userFilePath)){

                        string extension = Path.GetExtension(userFilePath);
                        Console.Write(extension);

                        if (!string.IsNullOrEmpty(extension) && extension.StartsWith(".")) {
                            extension = extension.Substring(1); // Removes the first character (which is the period)
                            Console.WriteLine(extension);
                        }

                        Console.WriteLine($"{extension} checkpoint 01");
                        if (!supportedFileTypes.Contains(extension)) {
                                Console.WriteLine("Extension not a supported file type. Please try again.");
                        } else {
                            fileLoadedExtension = extension;
                            switch (fileLoadedExtension) {
                                case "mp3":
                                    fileLoaded = new mp3File(userFilePath);
                                    break;
                                case "jpg":
                                    // fileLoaded = new jpgFile(userFilePath);
                                    break;
                                case "txt":
                                    fileLoaded = new txtFile(userFilePath);
                                    break;
                                default:
                                    Console.WriteLine("This should never print");
                                    break;
                            }
                        }
                    } else {
                        Console.WriteLine("Sorry, invalid file path.");
                    }
                }
            }   

            
            
            bool continueLoop02 = true;
            while (continueLoop02) {
                Console.WriteLine("Please select an action to perform on the file: (#)");
                for (int i = 0; i < options1.Count; i++) {
                    Console.WriteLine($"{i + 1}. {options1[i]}");
                }

                int response01;
                if (!int.TryParse(Console.ReadLine(), out response01) || response01 < 1 || response01 > options1.Count) {
                    Console.WriteLine("Sorry, that response was invalid, please try again.");
                } else {
                    string optionSelected = options1[response01 - 1];
                    continueLoop02 = false;

                    switch (optionSelected) {
                        case "Show file information":
                            fileLoaded.ViewBasicFileInfo();
                            break;
                        case "View metadata":
                            fileLoaded.ViewMetaData();
                            break;
                        case "Edit metadata":

                            string fieldToChange = fileLoaded.GetEditOption();
                            bool editMetadataLoop = true;
                            string userInput = "";
                            
                                while (editMetadataLoop){
                                    
                                    Console.WriteLine("Enter the information for the desired field:");
                                    userInput = Console.ReadLine();
                                    if (!int.TryParse(userInput, out int newValue)){
                                        Console.WriteLine("Sorry, please enter a number.");
                                    } else {
                                        editMetadataLoop = false;
                                    }
                            }

                            fileLoaded.ChangeMetaData(fieldToChange, userInput);
                            Console.WriteLine("Metadata successfully changed.");
                            break;

                        case "Edit file":
                            if (fileLoadedExtension == "mp3" || fileLoadedExtension == "jpg"){
                                Console.WriteLine($"Option not available for {fileLoadedExtension} files");
                            } else {
                                fileLoaded.EditTxt();
                            }
                            break;
                        default:
                            break;
                        }
                    }
                }
            }
             
        bool continueLoop03 = true;

        while(continueLoop03){
            Console.WriteLine("Would you like to work with another file? (y/n)");
            string response = Console.ReadLine();
            if (response == "y") {
                continueLoop03 = false;
            } else if (response == "n") {
                continueLoop03 = false;
                continueMainLoop = false;
                Console.WriteLine("Thank you for using the program.");
            } else {
                Console.WriteLine("Sorry, invalid response, please try again.");
            }
        }
    }

    public bool PathExists(string path) {
        return System.IO.File.Exists(path) || Directory.Exists(path);
    }
}
