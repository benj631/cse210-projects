using System;
using System.Collections.Generic;

public class Reference{
    string standardWork = "";
    string bookTitle = "";
    int chapter = 0;
    List<int> verseNumbers = new List<int>();
    List<List<Word>> verseTexts = new List<List<Word>>();

    double hiddenPercent = 0;

    public Reference(Dictionary<string, object> referenceInfo)
    {
        this.standardWork = (string)referenceInfo["StandardWork"];
        this.bookTitle = (string)referenceInfo["Book"];
        this.chapter = (int)referenceInfo["Chapter"];
        this.verseNumbers = (List<int>)referenceInfo["VerseNumbers"];

        foreach (string verse in (List<string>)referenceInfo["VerseTexts"])
        {
            List<Word> words = new List<Word>();
            foreach (string word in verse.Split(' '))
            {
                words.Add(new Word(word));
            }
            this.verseTexts.Add(words);
        }
    }

    public void DisplayHeader(int verseIndex)
    {
        Console.WriteLine($"Standard Work: {this.standardWork} \nBook Title: {this.bookTitle} \nChapter: {this.chapter} \nVerse Number: {this.verseNumbers[verseIndex]}");
    }

    public double GetHiddenPercent()
    {
        int totalWords = 0;
        int hiddenWords = 0;

        // Count total words and hidden words
        foreach (List<Word> verseList in verseTexts)
        {
            foreach (Word word in verseList)
            {
                totalWords++;
                if (word.hidden)
                {
                    hiddenWords++;
                }
            }
        }

        // Avoid division by zero
        if (totalWords == 0)
        {
            return 0;
        }

        // Calculate and return the percentage of hidden words
        return (double)hiddenWords / totalWords;
    }

    static Random rand = new Random(); // Moved Random instance to avoid repeated creation

    static bool DeterminePrintCase(double hiddenPercent)
    {
        if (hiddenPercent <= 0.33)
        {
            return rand.Next(0, 3) == 0; // 33% chance
        }
        else if (hiddenPercent <= 0.66)
        {
            return rand.Next(0, 2) == 0; // 50% chance
        }
        else
        {
            return true; // Always hide for hiddenPercent > 0.66
        }
    }

    public void PrintVerse()
    {
        string verseDisplay = "";
        foreach (List<Word> verseList in verseTexts)
        {
            int index = verseTexts.IndexOf(verseList);
            verseDisplay += verseNumbers[index] + " ";
            
            foreach (Word word in verseList)
            {
                if (!word.hidden) // Only append visible words
                {
                    verseDisplay += word.Get() + " ";
                }
                else
                {
                    verseDisplay += new string('_', word.word.Length) + " "; // Replace hidden words with underscores
                }
            }
            verseDisplay += "\n"; // Newline for each verse
        }
        Console.WriteLine(verseDisplay);
    }

    public void HideWords(double hiddenPercent){
        foreach (List<Word> verseList in verseTexts)
        {
            foreach (Word word in verseList)
            {
                if (!word.hidden)
                {
                    if (DeterminePrintCase(hiddenPercent))
                    {
                        word.Hide();
                    }
                }
            }
        }
    }
}

