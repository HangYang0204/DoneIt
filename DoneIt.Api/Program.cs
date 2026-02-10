using DoneIt.Models;
using DoneIt.Services;

//var app = WebApplication.Create(args);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI();


app.MapGet("/tasks", () => {
    return TaskService.Load();
    });

app.MapPost("/tasks", (TodoTask newTask) => {
    var tasks = TaskService.Load();
    tasks.Add(newTask);
    TaskService.Save(tasks);
    return Results.Created($"/tasks/{newTask.Description}", newTask);
});

app.Run();
