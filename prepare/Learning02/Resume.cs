public class Resume
{
    public string name { get; set; }

    // public List<Job> _jobs = new List<Job>();
    public List<Job> jobs = new();

    public void Display()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in jobs)
        {
            job.Display(); // Call the Display method of the Job class
        }
    }
}