// I added checklist goals where the user adds a checklist goal, like an eternal goal but with multiple steps and has an end.
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new();
        bool running = true;

        while (running)
        {
            Console.WriteLine($"\nYou have {manager.Score} points.");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    manager.AddGoal(CreateGoal());
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    manager.RecordEvent();
                    break;
                case "4":
                    manager.SaveGoals();
                    break;
                case "5":
                    manager.LoadGoals();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Please enter a number from 1 to 6.");
                    break;
            }
        }
    }

    private static Goal CreateGoal()
    {
        Console.WriteLine("Goal types: 1. Simple  2. Eternal  3. Checklist");
        Console.Write("Choose a type: ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            return new SimpleGoal(name, description, points);
        }
        else if (type == "2")
        {
            return new EternalGoal(name, description, points);
        }
        else if (type == "3")
        {
            Console.Write("How many times to complete it? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            return new ChecklistGoal(name, description, points, target, bonus);
        }

        Console.WriteLine("That is not a goal type.");
        return null;
    }
}
