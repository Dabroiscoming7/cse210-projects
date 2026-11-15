class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override bool IsComplete => _isComplete;

    public override int RecordEvent()
    {
        if (_isComplete)
        {
            return 0;
        }

        _isComplete = true;
        return Points;
    }

    public override string GetSaveString()
    {
        return $"Simple | {Name} | {Description} | {Points} | {_isComplete}";
    }

    public bool Completed
    {
        get => _isComplete;
        set => _isComplete = value;
    }
}
