namespace DoneIt.Service;
public class CliApp
{
    //return CliApp(container)
    //Internal dependency injection container
    private readonly Dictionary<Type, object> _container;
    //Internal route table
    private readonly Dictionary<string, Delegate> _routes = new();
    public CliApp(Dictionary<Type, object> container)
    {
        _container = container;
    }

    public void MapRoute(string command, Delegate handler)
    {
        _routes[command.ToLower()] = handler;
    }

    //app.Run(args)
    public void Run()
    {
        while (true)
        {
            System.Console.WriteLine("\nRoute >");
            string? input = Console.ReadLine();
            if(input == "exit" || input == null) break;

            if(_routes.TryGetValue(input.ToLower(), out var handler))
            {
                //reflection
                var parameters = handler.Method.GetParameters();
                var args = new List<object>();
                foreach (var param in parameters)
                {
                    if (_container.TryGetValue(param.ParameterType, out var service))
                    {
                        args.Add(service);
                    }
                    else
                    {
                        Console.WriteLine($"No service found for type {param.ParameterType}");
                        return;
                    }
                }
                handler.DynamicInvoke(args.ToArray());
            }
            else
            {
                Console.WriteLine("Unknown command. Please try again.");
            }
        }
    }


}