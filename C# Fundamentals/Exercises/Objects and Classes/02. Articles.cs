using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var data = Console.ReadLine().Split(", ").ToList();
        var obj = new Article(data[0], data[1], data[2]);
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
            var line = Console.ReadLine().Split(": ").ToList();
            switch (line[0]) {
                case "Edit":
                    obj.Edit(line[1]);
                    break;
                case "ChangeAuthor":
                    obj.ChangeAuthor(line[1]);
                    break;
                case "Rename":
                    obj.Rename(line[1]);
                    break;
            }
        }
        Console.WriteLine(obj.ToString());
    }
}
class Article {
    public Article(string title, string content, string author) {
        Title = title;
        Content = content;
        Author = author;
    }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }
    public void Edit(string text) {
        Content = text;
    }
    public void ChangeAuthor(string text) {
        Author = text;
    }
    public void Rename(string text) {
        Title = text;
    }
    public override string ToString() {
        return $"{Title} - {Content}: {Author}";
    }
}