namespace DoneIt.Api.Services;
using DoneIt.Api.Models;

public interface ITaskService
{
    List<TodoTask> Load();
    void Save(List<TodoTask> tasks);
}