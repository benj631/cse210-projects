using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job("Manager","Del Taco",2021,2022);

        Job job2 = new Job("Employee","Panda Express",2000,2023);

        Resume myResume = new Resume();
        myResume.name = "Allison Rose";

        myResume.jobs.Add(job1);
        myResume.jobs.Add(job2);

        myResume.Display();
    }
}