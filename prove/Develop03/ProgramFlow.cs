using System;
using System.Collections.Generic;
#nullable enable

public class ProgramFlow
{
    int selection = 1;
    Reference? currentReference;
    public Scriptures? scriptures;

    public void Init(){
        AddStarterScriptures();
        int selectionIndex = GetSelection();
        if (selectionIndex != -1)
        {
            currentReference = scriptures?.references[selectionIndex];
            StartHideWords();
        }
        else
        {
            Console.WriteLine("No valid selection made.");
        }
    }

    public void DisplayScriptureSelection()
    {
        List<Reference> references = scriptures.GetReferences();
        foreach (Reference reference in references)
        {
            Console.WriteLine($"{references.IndexOf(reference) + 1}");
            reference.DisplayHeader(references.IndexOf(reference));
        }
    }

    // Returns the index in scriptures of the current reference the user chooses.
    public int GetSelection()
    {
        Console.WriteLine("Select a verse:");
        DisplayScriptureSelection();

        while (true)
        {
            Console.WriteLine("Select a verse to memorize");

            try
            {
                selection = int.Parse(Console.ReadLine()) - 1;

                if (selection < 0 || selection >= scriptures?.references.Count)
                {
                    Console.WriteLine("Sorry, that's not a valid selection");
                    Console.Clear();
                    DisplayScriptureSelection();
                }
                else
                {
                    return selection;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Sorry, that's not a number");
                Console.Clear();
                DisplayScriptureSelection();
            }
        }
    }

    public void AddStarterScriptures()
{
    List<Dictionary<string, object>> verseDictList = new List<Dictionary<string, object>>()
    {
        new Dictionary<string, object>
        {
            { "StandardWork", "Book of Mormon" },
            { "Book", "Moroni" },
            { "Chapter", 10 },
            { "VerseNumbers", new List<int>{4} },
            { "VerseTexts", new List<string>{ "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost." } }
        },
        new Dictionary<string, object>
        {
            { "StandardWork", "New Testament" },
            { "Book", "Matthew" },
            { "Chapter", 7 },
            { "VerseNumbers", new List<int> { 16, 17, 18, 19, 20 } },
            { "VerseTexts", new List<string>
                {
                    "16 Ye shall know them by their fruits. Do men gather grapes of thorns, or figs of thistles?",
                    "17 Even so every good tree bringeth forth good fruit; but a corrupt tree bringeth forth devil fruit.",
                    "18 A good tree cannot bring forth evil fruit, neither can a corrupt tree bring forth good fruit.",
                    "19 Every tree that bringeth not forth good fruit is hewn down, and cast into the fire.",
                    "20 Wherefore by their fruits ye shall know them."
                }
            }
        }
    };

    scriptures = new Scriptures(verseDictList);
}

    public void WaitPressKey()
    {
        while (!Console.KeyAvailable)
        {
            // Wait for key press
        }
        Console.ReadKey(true); // Consume the key press
    }

    public void StartHideWords(){
        
        bool continueHide = true;
        double hiddenPercent = 0;

        while (continueHide)
        {
            Console.Clear();
            currentReference.PrintVerse();
            currentReference.HideWords(hiddenPercent);
            hiddenPercent = currentReference.GetHiddenPercent();
            WaitPressKey();

            if (hiddenPercent == 1.00)
            {
                Console.Clear();
                currentReference.PrintVerse();
                currentReference.HideWords(hiddenPercent);
                hiddenPercent = currentReference.GetHiddenPercent();
                 WaitPressKey();
                continueHide = false;
                Console.WriteLine("You memorized the verse!.");
                Console.WriteLine("Press any key to quit.");
                WaitPressKey();
            }
        }

        Environment.Exit(0);
    }

}
