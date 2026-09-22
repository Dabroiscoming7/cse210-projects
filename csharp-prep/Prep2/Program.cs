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

        if (numberedGrade >= 90)
        {
            Console.WriteLine(" You got an A! congradulations you passed!");
        }
        else if (numberedGrade >= 80)
        {
            Console.WriteLine(" You got an B! congradulations you passed!");
        }
        else if (numberedGrade >= 70)
        {
            Console.WriteLine(" You got an C! congradulations you passed!");
        }
        else if (numberedGrade >= 60)
        {
            Console.WriteLine(" You got an D you weren't able to pass.");
        }
        else
        {
            Console.WriteLine(" You got an F you weren't able to pass.");
        }
    }
}