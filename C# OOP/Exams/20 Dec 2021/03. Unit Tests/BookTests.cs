namespace Book.Tests;
using System;
using NUnit.Framework;

public class BookTests
{
    [Test]
    public void Ctor_Valid()
    {
        Book book = new Book("book","author");
        Assert.That(book.BookName,Is.EqualTo("book"));
        Assert.That(book.Author,Is.EqualTo("author"));
    }
    [Test]
    public void BookName_ThrowsFor_NullOrEmpty()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Book book = new Book("","author");
        });
    }
    [Test]
    public void Author_ThrowsFor_NullOrEmpty()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Book book = new Book("book","");
        });
    }
    [Test]
    public void AddFootnote_Valid()
    {
        Book book = new Book("book","author");
        book.AddFootnote(1,"text");
        Assert.That(book.FootnoteCount,Is.EqualTo(1));
    }
    [Test]
    public void AddFootnote_ThrowsFor_AlreadyExists()
    {
        Book book = new Book("book","author");
        book.AddFootnote(1,"text");
        Assert.Throws<InvalidOperationException>(() =>
        {
            book.AddFootnote(1,"text");
        });
    }
    [Test]
    public void FindFootnote_ThrowsFor_NotFound()
    {
        Book book = new Book("book","author");
        Assert.Throws<InvalidOperationException>(() =>
        {
            book.FindFootnote(1);
        });
    }
    [Test]
    public void FindFootnote_Valid()
    {
        Book book = new Book("book","author");
        book.AddFootnote(1,"text");
        string expected = "Footnote #1: text";
        string actual = book.FindFootnote(1);
        Assert.That(actual,Is.EqualTo(expected));
    }
    [Test]
    public void AlterFootnote_ThrowsFor_NotFound()
    {
        Book book = new Book("book","author");
        Assert.Throws<InvalidOperationException>(() =>
        {
            book.AlterFootnote(1,"new");
        });
    }
    [Test]
    public void AlterFootnote_Valid()
    {
        Book book = new Book("book","author");
        book.AddFootnote(1,"text");
        book.AlterFootnote(1,"new");
        string expected = "Footnote #1: new";
        string actual = book.FindFootnote(1);
        Assert.That(actual,Is.EqualTo(expected));
    }
}
