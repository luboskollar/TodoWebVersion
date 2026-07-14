using Microsoft.EntityFrameworkCore;
using TodoWebVersion.Models;

namespace TodoWebVersion.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {
    }
    
    public DbSet<TodoItem> Todos { get; set; }
}