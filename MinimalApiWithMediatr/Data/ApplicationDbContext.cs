using Microsoft.EntityFrameworkCore;
using MinimalApiWithMediatr.Todo.Entities;

namespace MinimalApiWithMediatr.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<TodoGroup> TodoGroups => Set<TodoGroup>();
}