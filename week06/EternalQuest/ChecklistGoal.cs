public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonus = bonus;
    }

    // Called when the user records progress on this goal
    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount == _targetCount)
        {
            return _points + _bonus;
        }
        else
        {
            return _points;
        }
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetStatus()
    {
        string box = IsComplete() ? "[X]" : "[ ]";
        return $"{box} Completed {_currentCount}/{_targetCount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_targetCount},{_currentCount},{_bonus}";
    }

    // Setter for loading saved progress
    public void SetCurrentCount(int count)
    {
        _currentCount = count;
    }

    // Optional getters if needed elsewhere
    public int GetCurrentCount()
    {
        return _currentCount;
    }

    public int GetTargetCount()
    {
        return _targetCount;
    }
}
