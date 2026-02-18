namespace DoneIt.Service;

using DoneIt.Models;

public interface ITaskService
{
    List<TodoTask> Load();
    void Save(List<TodoTask> tasks);
}