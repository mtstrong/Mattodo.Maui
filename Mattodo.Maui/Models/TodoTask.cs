namespace Mattodo.Maui;

public class TodoTask
{
    public string Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Details { get; set; } = default!;
    public string Author { get; set; } = default!;
    public DateTime Started { get; set; }
    public DateTime Completed { get; set; }
    public DateTime LastModified { get; set; }
    public bool IsCompleted
    {
        get
        { 
            return DateTime.Compare(Started, Completed) > 0;
        }
        set
        {
            IsCompleted = value;
        }
    }
}