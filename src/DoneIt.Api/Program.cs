using DoneIt.Api.Models;
using DoneIt.Api.Services;

//var app = WebApplication.Create(args);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITaskService, TaskService>(); // Register TaskService with the DI container

var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/tasks", (ITaskService taskService) => {
    return taskService.Load();
    });

app.MapPost("/tasks", (TodoTask newTask, ITaskService taskService) => {
    var tasks = taskService.Load();
    tasks.Add(newTask);
    taskService.Save(tasks);
    return Results.Created($"/tasks/{newTask.Description}", newTask);
});

app.Run();
