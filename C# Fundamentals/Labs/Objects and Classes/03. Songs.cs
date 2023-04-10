using System;
using System.Collections.Generic;
using System.Linq;
class SoftUni {
    static void Main() {
        int n = int.Parse(Console.ReadLine());
        var songs = new List<Song>();
        for (int i = 0; i < n; ++i) {
            var data = Console.ReadLine().Split('_');
            Song song = new Song(data[0], data[1]);
            songs.Add(song);
        }
        string type = Console.ReadLine();
        if (type != "all") {
            songs.Where(x => x.Type == type).ToList().ForEach(x => Console.WriteLine(x.Name));
        } else {
            songs.ForEach(x => Console.WriteLine(x.Name));
        }
    }
}
class Song {
    public string Type { get; set; }
    public string Name { get; set; }
    public Song(string type, string name) {
        Type = type;
        Name = name;
    }
}