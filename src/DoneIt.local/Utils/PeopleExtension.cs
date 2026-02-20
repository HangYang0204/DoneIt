namespace DoneIt.Utils;

using DoneIt.Models;

/// <summary>
/// Extension methods for the <see cref="List{Person}"/> class.
/// Provides utility functionality for working with collections of Person objects.
/// </summary>
public static class PeopleExtension
{
    /// <summary>
    /// Prints all people in the collection to the console output.
    /// Each person is printed on a separate line using their <see cref="Person.ToString()"/> representation.
    /// </summary>
    /// <param name="people">The list of Person objects to print. Must not be null.</param>
    /// <remarks>
    /// This method iterates through each person in the collection and outputs their string representation
    /// to the standard console output (System.Console.WriteLine).
    /// </remarks>
    public static void PrintPeople(this IEnumerable<Person> people)
    {
        foreach (var p in people)
        {
            System.Console.WriteLine(p.ToString());
        }
    }
}