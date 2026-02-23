using System.Security.Cryptography.X509Certificates;
using DoneIt.Api.Models;
using DoneIt.Api.Services;
using Microsoft.EntityFrameworkCore;

//var app = WebApplication.Create(args);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITaskService, TaskService>(); // Register TaskService with the DI container

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Use SQL Server database

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/tasks", (ITaskService taskService) => Results.Ok(taskService.GetAll()));

app.MapPost("/tasks", (TodoTask newTask, ITaskService taskService) => {
    taskService.Add(newTask);
    return Results.Created($"/tasks/{newTask.Description}", newTask);
});

app.MapDelete("/tasks/{description}", (string description, ITaskService taskService) => {
    taskService.Delete(description);
    return Results.NoContent();
});

app.Run();
