using TodoWebVersion.Enums;

namespace TodoWebVersion.Models;

public class TodoItem
{
    public int Id { get; private set; }
    public string Title { get; set; } = string.Empty;
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; private set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; } = Status.Pending;
    public TodoItem(int id, string title, DateTime dueDate, Priority priority)
    {
        Id = id;
        Title = title;
        DueDate = dueDate;
        CreatedAt = DateTime.Now;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"[{Id}] {Title} | {Priority} | {Status} | Due: {DueDate:dd.MM.yyyy}";
    }
}