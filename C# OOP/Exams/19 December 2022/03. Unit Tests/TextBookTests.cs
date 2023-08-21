namespace UniversityLibrary.Test;
using NUnit.Framework;
using System;
[TestFixture]
public class TextBookTests
{
    private const string title = "Bible";
    private const string author = "Jesus";
    private const string category = "Fantasy";
    [Test]
    public void ContructorValid()
    {
        TextBook book = new(title,author,category);
        Assert.That(book.Title,Is.EqualTo(title));
        Assert.That(book.Author,Is.EqualTo(author));
        Assert.That(book.Category,Is.EqualTo(category));
    }
    [Test]
    public void ToStringValid()
    {
        TextBook book = new(title,author,category);
        book.InventoryNumber = 1;
        string expected = $"Book: {title} - 1{Environment.NewLine}" +
            $"Category: {category}{Environment.NewLine}" +
            $"Author: {author}";
        Assert.That(expected,Is.EqualTo(book.ToString()));
    }
}