namespace DoneIt.Service;

public class CliAppBuilder
{
    private readonly Dictionary<Type, Type> _services = new();
    //builder.AddSingleton<ITaskService, TaskService>();
    public void AddSingleton<TInterface, TImplementation>() where TImplementation : TInterface
    {
        _services[typeof(TInterface)] = typeof(TImplementation);
    }
    //builder.build
    public CliApp Build()
    {
        var container = new Dictionary<Type, object>();
        foreach (var service in _services)
        {
            var implementation = Activator.CreateInstance(service.Value);
            if (implementation != null)
            {
                container[service.Key] = implementation;
            }
        }
        return new CliApp(container);
    }
}