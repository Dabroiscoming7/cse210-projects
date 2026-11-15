class ChecklistGoal : Goal
{
    private int _completedCount;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonus = bonus;
    }

    public int CompletedCount
    {
        get => _completedCount;
        set => _completedCount = value;
    }

    public int TargetCount
    {
        get => _targetCount;
        set => _targetCount = value;
    }

    public int Bonus
    {
        get => _bonus;
        set => _bonus = value;
    }

    public override bool IsComplete => _completedCount >= _targetCount;

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        _completedCount++;
        return Points + (IsComplete ? _bonus : 0);
    }

    public override string GetStatus()
    {
        return $"[{(IsComplete ? "X" : " ")}] (Completed {_completedCount}/{_targetCount} times)";
    }

    public override string GetSaveString()
    {
        return $"Checklist | {Name} | {Description} | {Points} | {_completedCount} | {_targetCount} | {_bonus}";
    }
}
