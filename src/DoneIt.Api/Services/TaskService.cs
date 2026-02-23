using System.Text.Json;
using DoneIt.Api.Models;

namespace DoneIt.Api.Services;
public  class TaskService : ITaskService
{
    private readonly AppDbContext _dbContext;

    public TaskService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public List<TodoTask> GetAll() => _dbContext.Tasks.ToList();
    public void Add(TodoTask task)
    {
        _dbContext.Tasks.Add(task);
        _dbContext.SaveChanges();
    }
    public void Update(TodoTask task)
    {
        var existingTask = _dbContext.Tasks.FirstOrDefault(t => t.Description == task.Description);
        if (existingTask != null)
        {
            existingTask.IsDone = task.IsDone;
            _dbContext.SaveChanges();
        }
    }
    public void Delete(string description)
    {
        var task = _dbContext.Tasks.FirstOrDefault(t => t.Description == description);
        if (task != null)
        {
            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
        }
    }
}