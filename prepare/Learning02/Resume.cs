//Resume.cs
using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;
    public List<Job> _jobs;

    //Constructor
    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>();
    }

    //Display method
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs");

        foreach (var job in _jobs)
        {
            job.Display();
        }
    }

    //AddJob method
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }
}