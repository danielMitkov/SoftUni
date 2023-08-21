using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityLibrary.Test;

[TestFixture]
public class UniversityLibraryTests
{
    private const string title = "Bible";
    private const string author = "Jesus";
    private const string category = "Fantasy";
    [Test]
    public void ConstructorValid()
    {
        UniversityLibrary library = new();
        Assert.That(library.Catalogue,Is.Not.SameAs(null));
    }
    [Test]
    public void AddTextBookToLibraryValid()
    {
        TextBook book = new(title,author,category);
        UniversityLibrary library = new();
        string expected = $"Book: {title} - 1{Environment.NewLine}" +
            $"Category: {category}{Environment.NewLine}" +
            $"Author: {author}";

        string result = library.AddTextBookToLibrary(book);

        Assert.That(library.Catalogue[0],Is.SameAs(book));
        Assert.That(book.InventoryNumber,Is.EqualTo(1));
        Assert.That(result,Is.EqualTo(expected));
    }
    [Test]
    public void LoanTextBookValid()
    {
        TextBook book = new(title,author,category);
        UniversityLibrary library = new();
        int id = 1;
        string name = "Bob";
        string expected = $"{title} loaned to {name}.";
        library.AddTextBookToLibrary(book);

        string actual = library.LoanTextBook(id,name);

        Assert.That(actual,Is.EqualTo(expected));
        Assert.That(book.Holder,Is.EqualTo(name));
    }
    [Test]
    public void LoanTextBookNotAvailable()
    {
        TextBook book = new(title,author,category);
        UniversityLibrary library = new();
        int id = 1;
        string name = "Bob";
        book.Holder = name;
        string expected = $"{name} still hasn't returned {title}!";
        library.AddTextBookToLibrary(book);

        string actual = library.LoanTextBook(id,name);

        Assert.That(actual,Is.EqualTo(expected));
        Assert.That(book.Holder,Is.EqualTo(name));
    }
    [Test]
    public void ReturnTextBookValid()
    {
        TextBook book = new(title,author,category);
        UniversityLibrary library = new();
        int id = 1;
        string name = "Bob";
        book.Holder = name;
        string expected = $"{title} is returned to the library.";
        library.AddTextBookToLibrary(book);

        string actual = library.ReturnTextBook(id);

        Assert.That(actual,Is.EqualTo(expected));
        Assert.That(book.Holder,Is.EqualTo(string.Empty));
    }
}