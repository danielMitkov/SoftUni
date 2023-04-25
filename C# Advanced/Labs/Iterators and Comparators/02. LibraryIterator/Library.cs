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
        return new LibraryIterator(books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    class LibraryIterator:IEnumerator<Book>
    {
        private int index = -1;
        private List<Book> books;
        public LibraryIterator(List<Book> books) => this.books = books;
        public Book Current => books[index];
        object IEnumerator.Current => Current;
        public void Dispose() { }
        public bool MoveNext() => ++index < books.Count;
        public void Reset() => index = -1;
    }
}