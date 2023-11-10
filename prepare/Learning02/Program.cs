using System;

class Program
{
    static void Main()
    {
        //Creat job instances
        Job job1 = new Job("Microsoft", "Software Engineer", 2019, 2022);
        Job job2 = new Job("Apple", "Manager", 2022, 2023);    

        //Create resume instance
        Resume myResume = new Resume("Allison Rose");

        //Add jobs to this resume
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        //Display resume information
        myResume.Display();
    }
}