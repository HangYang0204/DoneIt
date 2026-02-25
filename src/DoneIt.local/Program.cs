using System.Collections;
using System.Runtime.InteropServices;
using DoneIt.Models;
using DoneIt.Service;
using System.Linq;
using DoneIt.Utils;
using Microsoft.Extensions.Options;


var builder = new CliAppBuilder();
builder.AddSingleton<ITaskService, TaskService>();


var app = builder.Build();

app.MapRoute("add", (ITaskService taskService) =>
{
    Console.WriteLine("Enter task description:");
    var description = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(description))
    {
        var tasks = taskService.Load();
        tasks.Add(new TodoTask { Description = description });
        taskService.Save(tasks);
        Console.WriteLine($"Added task: {description}");
    }
    else
    {
        Console.WriteLine("Task description cannot be empty.");
    }
});

app.MapRoute("list", (ITaskService taskService) =>
{
    var tasks = taskService.Load();
    if (tasks.Count == 0)
    {
        Console.WriteLine("No tasks found.");
        return;
    }
    foreach (var t in tasks)
    {
        Console.WriteLine($"[{(t.IsDone ? "X" : " ")}] {t.Description}");
    }
});


app.MapRoute("Main",() =>
{
    // frequency array for letters a-z
    string sentence = "mama mama and papa are here";
    var mostFrequentLetters = sentence.MostFrequentLetters(); //Compile does this for you : PeopleExtension.MostFrequentLetters(sentence);
    if(mostFrequentLetters.Any())
    {
        Console.WriteLine($"Most frequent letter(s) in the sentence: {string.Join(", ", mostFrequentLetters)}");
    }
    else
    {
        Console.WriteLine("No letters found in the sentence.");
    }
});

app.Run();
