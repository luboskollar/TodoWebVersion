using Microsoft.AspNetCore.Mvc;
using TodoWebVersion.Data;
using TodoWebVersion.Enums;
using TodoWebVersion.Models;
using TodoWebVersion.Models.DTOs;

namespace TodoWebVersion.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoDbContext _context;

    public TodoController(TodoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Todos.ToList());
    }

    [HttpPost]
    public IActionResult Add([FromBody] CreateTodoDto dto)
    {
        var newTodo = new TodoItem(0, dto.Title, dto.DueDate, dto.Priority);
        _context.Todos.Add(newTodo);
        _context.SaveChanges();
        return Ok(newTodo);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();    
        }
        return Ok(todo);
    }

    [HttpGet("status/{status}")]
    public IActionResult GetByStatus(Status status)
    {
        List<TodoItem> filtered = _context.Todos.Where(t => t.Status == status).ToList();
        return Ok(filtered);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateTodoDto dto)
    {
        var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        todo.UpdateFrom(dto);
        _context.SaveChanges();
        return Ok(todo);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
        {
            return NotFound();
        }
        _context.Todos.Remove(todo);
        _context.SaveChanges();
        return NoContent();
    }
}