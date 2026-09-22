using System;

class Program
{
    static void Main(string[] args)
    {
        string score;
        Console.WriteLine(" What is your grade percentage: ");
        score = Console.ReadLine();
        string grade = score;
        int numberedGrade = int.Parse(grade);
        string letter = "";

        if (numberedGrade >= 90)
        {
            letter = "A";
        }
        else if (numberedGrade >= 80)
        {
            letter = "B";
        }
        else if (numberedGrade >= 70)
        {
            letter = "C";
        }
        else if (numberedGrade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (numberedGrade >= 70)
        {
            Console.WriteLine("Congradulations you passed!");
        }
        else
        {
            Console.WriteLine("You failed, do better next time.");
        }
    }
}