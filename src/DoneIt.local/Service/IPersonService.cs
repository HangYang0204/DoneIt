namespace DoneIt.Service;
using DoneIt.Models;
public interface IPersonService
{
    static void PrintPerson(List<Person> people)    
    {
        foreach (var person in people)
        {
            System.Console.WriteLine(person.ToString());
        }
    }
    static void SortPerson(List<Person> people, Comparison<Person> comparison)    
    {
        people.Sort(comparison);
    }
}