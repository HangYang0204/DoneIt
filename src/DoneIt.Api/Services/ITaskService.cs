namespace DoneIt.Api.Services;

using System.Runtime.CompilerServices;
using DoneIt.Api.Models;

public interface ITaskService
{
    //CURD operations for tasks
    Task<List<TodoTask>> GetAllAsync();
    Task AddAsync(TodoTask task);
    Task UpdateAsync(TodoTask task);
    Task DeleteAsync(string description);
}