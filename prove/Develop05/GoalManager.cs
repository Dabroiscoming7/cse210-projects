class GoalManager
{
    private List<Goal> _goals = new();

    public int Score { get; private set; }

    public void AddGoal(Goal goal)
    {
        if (goal != null)
        {
            _goals.Add(goal);
            Console.WriteLine("Goal created.");
        }
    }

    public void ListGoals()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].Name} ({_goals[i].Description})");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int selection = int.Parse(Console.ReadLine());
        int points = _goals[selection - 1].RecordEvent();
        Score += points;

        if (points > 0)
        {
            Console.WriteLine($"You earned {points} points.");
        }
        else
        {
            Console.WriteLine("That goal is already complete.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter a file name to save to: ");
        string fileName = Console.ReadLine();
        List<string> lines = new() { Score.ToString() };

        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetSaveString());
        }

        File.WriteAllLines(fileName, lines);
        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("Enter the name of the file to load: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);
        Score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (parts[0] == "Simple")
            {
                SimpleGoal goal = new(name, description, points);
                goal.Completed = bool.Parse(parts[4]);
                _goals.Add(goal);
            }
            else if (parts[0] == "Eternal")
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (parts[0] == "Checklist")
            {
                ChecklistGoal goal = new(name, description, points, int.Parse(parts[5]), int.Parse(parts[6]));
                goal.CompletedCount = int.Parse(parts[4]);
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded.");
    }
}
