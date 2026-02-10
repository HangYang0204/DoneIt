using System.Text.Json;
using DoneIt.Models;

namespace DoneIt.Services;
public static class TaskService
{
    private const string FilePath = "tasks.json";
    public static List<TodoTask> Load()
    {
        if (!File.Exists(FilePath))
        {
            return new List<TodoTask>();
        }

        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<TodoTask>>(json) ?? new List<TodoTask>();
    }

    public static void Save(List<TodoTask> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }
}