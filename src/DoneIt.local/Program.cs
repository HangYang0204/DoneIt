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
/*Q1 solution*/
    string Str1 = "abc";
    string Str2 = "eidbacooo";

    //two fixed lentgh window i,j
    for(int i = 0; i < Str2.Length - Str1.Length + 1; i++)
    {
        string subStr = Str2.Substring(i, Str1.Length);
        if (subStr.PermutationIdentical(Str1))
        {
            Console.WriteLine("True");
            return;
        }
    }
    Console.WriteLine("False");

});

app.Run();
