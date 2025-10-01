namespace Assignment_6._3;

public class Call(string callerName)
{
    public string CallerName { get; set; } = callerName;
    public DateTime CallTime { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return $"{CallerName} (Called at: {CallTime})";
    }
}