using Microsoft.AspNetCore.Mvc;
using TodoWebVersion.Models;
using TodoWebVersion.Models.DTOs;

namespace TodoWebVersion.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private static List<TodoItem> _todoItems = new();
    private static int _nextId = 1;
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_todoItems);
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateTodoDto dto)
    {
        var newTodo = new TodoItem(_nextId, dto.Title, dto.DueDate, dto.Priority);
        _nextId++;
        _todoItems.Add(newTodo);
        return Ok(newTodo);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var todo = _todoItems.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();    
        }
        return Ok(todo);
    }
}