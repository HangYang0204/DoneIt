using System.Collections;
using System.Runtime.InteropServices;
using DoneIt.Models;
using DoneIt.Service;
using System.Linq;
using DoneIt.Utils;


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
    //define a list of people
    var People = new List<Person>
    {
        new Person { Name = "Elice", Age = 30 },
        new Person { Name = "Cob", Age = 25 },
        new Person { Name = "Aharlie", Age = 35 }
    };
    //print people using extension method
    People.PrintPeople();

    //use LINQ to filter people older than 30
    var olderThan30 = People.MyWhere(p => p.Age > 30);
    var names = People.MySelect(p => p.Name);
    
    olderThan30.PrintPeople();
    names.PrintAll();
});

app.Run();
