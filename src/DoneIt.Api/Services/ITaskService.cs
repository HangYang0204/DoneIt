namespace DoneIt.Api.Services;

using System.Runtime.CompilerServices;
using DoneIt.Api.Models;

public interface ITaskService
{
    //CURD operations for tasks
    List<TodoTask> GetAll();
    void Add(TodoTask task);
    void Update(TodoTask task);
    void Delete(string description);
}