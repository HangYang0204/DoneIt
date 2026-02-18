namespace DoneIt.Api.Models;

public class TodoTask
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; } = string.Empty;
    public bool IsDone { get; set; } = false;
}