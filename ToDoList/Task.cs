public class Task
{
    private static int nextId = 1; // Auto-incrementing ID tracker

    public int Id { get; private set; }
    public string Title { get; set; }
    public DateTime DueDate { get; set; }
    public string Project { get; set; }
    public bool IsDone { get; set; }

    public Task(string title, DateTime dueDate, string project)
    {
        Id = nextId++; // Assign and increment the ID
        Title = title;
        DueDate = dueDate;
        Project = project;
        IsDone = false; // Default status is pending
    }

    public override string ToString()
    {
        return $" {Id,-3} |  {Title.PadRight(30)} | {DueDate:yyyy-MM-dd} |  {(IsDone ? "Done" : "Pending").PadRight(10)} |  {Project.PadRight(20)}";
    }
}
