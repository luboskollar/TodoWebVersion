using TodoWebVersion.Enums;

namespace TodoWebVersion.Models.DTOs;

public class CreateTodoDto
{
    public string Title { get; set; } =  string.Empty;
    public DateTime DueDate { get; set; }
    public Priority Priority { get; set; }
}