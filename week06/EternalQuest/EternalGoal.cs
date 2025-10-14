public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    // Eternal goals are never complete, but always award points
    public override int RecordEvent()
    {
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatus()
    {
        return "[∞]"; // Symbol to indicate eternal goal
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_name},{_description},{_points}";
    }
}
