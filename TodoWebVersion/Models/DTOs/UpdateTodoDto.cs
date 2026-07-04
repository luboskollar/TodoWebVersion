using TodoWebVersion.Enums;

namespace TodoWebVersion.Models.DTOs;

public class UpdateTodoDto
{
    public string Title { get; set; } =  string.Empty;
    public DateTime DueDate { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; } = Status.Pending;
}