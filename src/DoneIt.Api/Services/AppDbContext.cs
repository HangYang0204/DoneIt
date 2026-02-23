using Microsoft.EntityFrameworkCore;
using DoneIt.Api.Models;
namespace DoneIt.Api.Services
{
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TodoTask> Tasks { get; set; }
}
}