# DoneIt
ASP .NET staff

## Phase 1
Minimal API, DI, JSON Serialization, Kestrel lifecycle

### 2 important things regarding interface and class
1. static method must be defined within the Interface body
2. override must be in the model definition, in our example, ToString() 

### 3 Extension and IEnumerable<T>
1. Extension requires static class and static method
2. First parameter should be IEnumerable<T>, in our example IEnumerable<Person>
3. Func<TSource, TResult> multi-parameter generic, Func<T, bool> is called predicate
   ```c#
       public IEnumerable<T> Find(Func<T, bool> predicate)
       {
            return _storage.Where(predicate);//_storage = List<T>
       }

       var names = userRepo.Find(u => u.Name);
   ```
4. yeild return => deferred execution and it ensures code executed when data is asked.

## Phase 1
EFCore, ORM, DbContext

download tools 
```tool install --global dotnet-ef```

create db 
```dotnet ef migrations add InitialCreate```

you might get error list below:
``` Powershell
A connection was successfully established with the server, but then an error occurred during the login process. (provider: SSL Provider, error: 0 - The certificate chain was issued by an authority that is not trusted.)
```
Add the following line in you ConnectionStrings

```Xml
TrustServerCertificate=True
```
### Reflection in DI
The constructor TaskService is called by the framework behind the sence:
```c#
    app.MapGet("/task" (ITaskService service)...)
    //under the hood it finds implemetaion of Interface and activator creates the instance Activator.CreateInstance basically does
    var dbContext = new AppDbContext(options);
    var TaskService = new TaskService(dbContext);
```