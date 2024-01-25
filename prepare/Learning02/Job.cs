using System;

public class Job
{
    
    public string jobTitle { get; set; }
    public string company { get; set; }
    public int startYear { get; set; }
    public int endYear { get; set; }

    public Job(string c, string jT, int sY, int eY)
    {
        company = c;
        jobTitle = jT;
        startYear = sY;
        endYear = eY;
    }

    public void Display()
    {
        Console.WriteLine($"Company: {company}");
        Console.WriteLine($"Job Title: {jobTitle}");
        Console.WriteLine($"Start Year: {startYear}");
        Console.WriteLine($"End Year: {endYear}");
    }
}