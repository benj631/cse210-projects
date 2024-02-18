using System;
using System.Collections.Generic;

public class Scriptures
{
    public List<Reference> references = new List<Reference>();

    public Scriptures(List<Dictionary<string, object>> verseDictList)
    {
        AddVerses(verseDictList);
    }

    public void AddVerses(List<Dictionary<string, object>> verseDictList)
    {
        foreach (Dictionary<string, object> verseDict in verseDictList)
        {
            Reference reference = new Reference(verseDict);
            references.Add(reference);
        }
    }

    public List<Reference> GetReferences()
    {
        return references;
    }
}
