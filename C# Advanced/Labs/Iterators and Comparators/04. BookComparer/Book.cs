namespace IteratorsAndComparators;
public class Book
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
    public override string ToString()
    {
        return $"{title} - {year}";
    }
}