using System;

public class Word{
    public string word = "";
    public bool hidden = false;

    public Word(string word)
    {
        this.word = word;
    }

    public string Get(){
        if (hidden){
            string hiddenWord = "";
            foreach (char letter in word){
                hiddenWord += "_"; // Append "_" to hiddenWord for each character in word
            }
            return hiddenWord;
        } else {
            return this.word;
        }
    }

    public void Hide(){
        this.hidden = true;
    }

}