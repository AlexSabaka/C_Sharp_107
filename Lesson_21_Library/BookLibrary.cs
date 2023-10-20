using System.Diagnostics.CodeAnalysis;
using System.Dynamic;

namespace Lesson_21_Library;


public record SomeOtherRecord(string Property);

public class Author
{
    public string Name {get;set;} 
    public int Age {get; set;}
    public string Phone{get; set;}
}

public class Book
{
    public string Title { get; set; }
    public int Year { get; set; }
    public Author Author { get; set; }
}

public class Library
{
    public List<Book> Books { get; } = new List<Book>();
}
