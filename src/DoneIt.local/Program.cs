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
    //define a list of people
    var People = new List<Person>
    {
        new Person { Name = "Elice", Age = 30 },
        new Person { Name = "Cob", Age = 25 },
        new Person { Name = "Aharlie", Age = 35 }
    };
    PersonService s = new PersonService();
    //sort by name
    s.SortPerson(People, (p1, p2) => string.Compare(p1.Name, p2.Name));
    System.Console.WriteLine("Sorted by name:");
    s.PrintPerson(People);
    //sort by age
    s.SortPerson(People, (p1, p2) => p1.Age.CompareTo(p2.Age));
    System.Console.WriteLine("Sorted by age:");
    s.PrintPerson(People);

});

app.Run();
