namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Xml.Linq;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context,4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context,int producerId)
        {
            var albums = context.Producers
                .First(p => p.Id == producerId)
                .Albums
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    a.Name,
                    a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    a.Price,
                    Songs = a.Songs
                        .OrderByDescending(s => s.Name)
                        .ThenBy(s => s.Writer.Name)
                        .Select(s => new
                        {
                            s.Name,
                            s.Price,
                            WriterName = s.Writer.Name
                        })
                        .ToArray()
                })
                .ToArray();

            StringBuilder sb = new();

            foreach(var album in albums)
            {
                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int n = 1;
                foreach(var song in album.Songs)
                {
                    sb.AppendLine($"---#{n++}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }
                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context,int duration)
        {
            var songs = context.Songs
            .ToArray()
            .Where(s => s.Duration.TotalSeconds > duration)
            .OrderBy(s => s.Name)
            .ThenBy(s => s.Writer.Name)
            .Select(s => new
            {
                s.Name,
                WriterName = s.Writer.Name,
                AlbumProducerName = s.Album.Producer.Name,
                s.Duration,
                PerformersNames = s.SongPerformers
                    .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                    .OrderBy(name => name)
                    .ToArray()
            })
            .ToArray();

            StringBuilder sb = new();
            int n = 1;
            foreach(var song in songs)
            {
                sb.AppendLine($"-Song #{n++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                //sb.AppendLine(string.Join(Environment.NewLine, song.PerformersNames.Select(name => $"---Performer: {name}")));

                foreach(var performerName in song.PerformersNames)
                {
                    sb.AppendLine($"---Performer: {performerName}");
                }
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducerName}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
