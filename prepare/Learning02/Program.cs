using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Computer Engineer";
        job1._company = "Dell";
        job1._startYear = 2012;
        job1._endYear = 2014;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "McDonalds";
        job2._startYear = 2016;
        job2._endYear = 2019;

        Resume myResume = new Resume();
        myResume._name = "Porter Wells";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}