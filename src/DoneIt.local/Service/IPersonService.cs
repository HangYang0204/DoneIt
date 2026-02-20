namespace DoneIt.Service;
using DoneIt.Models;
public interface IPersonService
{
    void PrintPerson(List<Person> people);

    void SortPerson(List<Person> people, Comparison<Person> comparison);

}