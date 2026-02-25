namespace DoneIt.Utils;
using System.Collections.Generic;
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

    public static void PrintAll<T>(this IEnumerable<T> people)
    {
        foreach (var p in people)
        {
            System.Console.WriteLine(p.ToString());
        }
    }
    public static void PrintSorted<T>(this IEnumerable<T> people) where T : IComparable<T>
    {
        var sortedPeople = people.OrderBy(p => p).ToList();
        foreach (var p in sortedPeople)
        {
            System.Console.WriteLine(p.ToString());
        }
    }

    public static void PrintSortedBy<T>(this IEnumerable<T> people, Func<T, object> keySelector)
    {
        var sortedPeople = people.OrderBy(keySelector).ToList();
        foreach (var p in sortedPeople)
        {
            System.Console.WriteLine(p.ToString());
        }
    }

    //MyWhere class
    public static IEnumerable<T> MyWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    //MySelect class
    //Func<TSource, TResult> selector: a function that takes an element of type TSource and returns an element of type TResult.
    public static IEnumerable<TResult> MySelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
    {
        foreach (var item in source)
        {
            yield return selector(item);
        }
    }

    //Most frequent letter in a sentence
    public static List<char> MostFrequentLetters(this string sentence)
    {
        int[] frequency = new int[26];
        int max = 0;
        foreach(char c in sentence)
        {
            if (char.IsLetter(c))
            {
                char LowerC = char.ToLower(c);
                frequency[LowerC - 'a']++;
                if (frequency[LowerC - 'a'] > max)                
                {
                    max = frequency[LowerC - 'a'];
                }
            }
        }
        if(max == 0)
        {
            return new List<char>();
        }
        List<char> mostFrequentLetters = new List<char>();
        for(int i = 0; i < frequency.Length; i++)
        {
            if(frequency[i] == max)
            {
                mostFrequentLetters.Add((char)('a' + i));
            }
        }
        return mostFrequentLetters;
    }
}