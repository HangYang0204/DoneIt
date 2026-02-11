using System.Text.Json;
using DoneIt.Api.Models;

namespace DoneIt.Api.Services;
public  class TaskService : ITaskService
{
    private const string FilePath = "tasks.json";
    public List<TodoTask> Load()
    {
        if (!File.Exists(FilePath))
        {
            return new List<TodoTask>();
        }

        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<TodoTask>>(json) ?? new List<TodoTask>();
    }

    public void Save(List<TodoTask> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}