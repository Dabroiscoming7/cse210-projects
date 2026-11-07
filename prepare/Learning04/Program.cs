using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("John Kenny", "Multiplication");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Parker Samuel", "Fractions", "12.3", "1-14");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Sadie Walter", "American History", "The causes of the Civil War");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}