public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Called when the user marks this goal as complete
    public override int RecordEvent()
    {
        _isComplete = true;
        return _points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStatus()
    {
        return _isComplete ? "[X]" : "[ ]";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
    }

    // Setter for loading saved completion status
    public void SetComplete(bool complete)
    {
        _isComplete = complete;
    }

    // Optional getter if needed elsewhere
    public bool GetComplete()
    {
        return _isComplete;
    }
}
