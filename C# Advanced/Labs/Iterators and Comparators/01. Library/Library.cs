using System.Collections;

namespace IteratorsAndComparators;
public class Library:IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = books.ToList();
    }

    public List<Book> Books { get => books; }

    public IEnumerator<Book> GetEnumerator()
    {
        return books.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}