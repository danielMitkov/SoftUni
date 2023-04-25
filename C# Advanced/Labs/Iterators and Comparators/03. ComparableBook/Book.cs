namespace IteratorsAndComparators;
public class Book : IComparable<Book>
{
    private string title;
    private int year;
    private List<string> authors;

    public Book(string title,int year,params string[] authors)
    {
        this.title = title;
        this.year = year;
        this.authors = authors.ToList();
    }

    public string Title { get => title; }
    public int Year { get => year; }
    public List<string> Authors { get => authors; }

    public int CompareTo(Book other)
    {
        if(year < other.year)
        {
            return -1;
        }
        if(year > other.year)
        {
            return 1;
        }
        return title.CompareTo(other.Title);
    }
    public override string ToString()
    {
        return $"{title} - {year}";
    }
}