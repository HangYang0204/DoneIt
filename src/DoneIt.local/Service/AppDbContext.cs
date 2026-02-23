using Microsoft.EntityFrameworkCore;
using DoneIt.Models;

public class AppDbContext : DbContext
{
    public DbSet<TodoTask> Tasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

}