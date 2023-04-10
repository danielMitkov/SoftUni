using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        var list = new List<Article>();
        for (int n = int.Parse(Console.ReadLine()); n > 0; --n) {
            var line = Console.ReadLine().Split(", ").ToList();
            list.Add(new Article(line[0], line[1], line[2]));
        }
        string order = Console.ReadLine();
        switch (order) {
            case "title":
                list = list.OrderBy(x => x.Title).ToList();
                break;

            case "content":
                list = list.OrderBy(x => x.Content).ToList();
                break;
               
            case "autor":
                list = list.OrderBy(x => x.Author).ToList();
                break;
        }
        Console.WriteLine(String.Join("\n", list));
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
    public override string ToString() {
        return $"{Title} - {Content}: {Author}";
    }
}