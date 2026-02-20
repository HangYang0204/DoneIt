namespace DoneIt.Service;
using DoneIt.Models;
class PersonService : IPersonService
{
    public void PrintPerson(List<Person> people)
    {
        foreach (var p in people)
        {
            System.Console.WriteLine(p.ToString());
        }
    }

    public void SortPerson(List<Person> Lpeople, Comparison<Person> comparison)
    {
        Lpeople.Sort(comparison);
    }
}