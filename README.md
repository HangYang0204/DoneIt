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