using System.Text.Json;
using DoneIt.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DoneIt.Api.Services;
public  class TaskService : ITaskService
{
    private readonly AppDbContext _dbContext;

    public TaskService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<TodoTask>> GetAllAsync() => await _dbContext.Tasks.ToListAsync();
    public async Task AddAsync(TodoTask task)
    {
        _dbContext.Tasks.Add(task); //should not use async 
        await _dbContext.SaveChangesAsync();
    }
    public async Task UpdateAsync(TodoTask task)
    {
        var existingTask = _dbContext.Tasks.FirstOrDefault(t => t.Description == task.Description);
        if (existingTask != null)
        {
            existingTask.IsDone = task.IsDone;
            await _dbContext.SaveChangesAsync();
        }
    }
    public async Task DeleteAsync(string description)
    {
        var task = _dbContext.Tasks.FirstOrDefault(t => t.Description == description);
        if (task != null)
        {
            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
        }
    }
}