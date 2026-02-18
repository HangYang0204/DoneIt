using System.Collections;
using System.Runtime.InteropServices;
using DoneIt.Models;
using DoneIt.Service;


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


app.MapRoute("learn",() =>
{
    var sentence = new Sentence();
    System.Console.WriteLine(sentence[3]);
    sentence[3] = "dog";
    System.Console.WriteLine(sentence[3]);

    System.Console.WriteLine(app.GetType().Name.ToString()); //Runtime
    System.Console.WriteLine(typeof(CliApp).Name.ToString()); //Compile time
});

app.Run();
