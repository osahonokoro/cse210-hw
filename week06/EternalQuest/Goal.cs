public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    // Abstract methods to be overridden by derived classes
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatus();
    public abstract string GetStringRepresentation();

    // Public getters to support encapsulation
    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }
}
