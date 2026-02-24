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

app.MapGet("/tasks", async (ITaskService taskService) => Results.Ok(await taskService.GetAllAsync()));

app.MapPost("/tasks", async (TodoTask newTask, ITaskService taskService) => {
    await taskService.AddAsync(newTask);
    return Results.Created($"/tasks/{newTask.Description}", newTask);
});

app.MapPut("/tasks", async (TodoTask updatedTask, ITaskService taskService) => {
    await taskService.UpdateAsync(updatedTask);
    return Results.NoContent();
});

app.MapDelete("/tasks/{description}", async (string description, ITaskService taskService) => {
    await taskService.DeleteAsync(description);
    return Results.NoContent();
});

app.Run();
