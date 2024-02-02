namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.Diagnostics;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context,int numbersOfHalls)
        {
            var theaters = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets
                        .Where(ticket => ticket.RowNumber >= 1 && ticket.RowNumber <= 5)
                        .Sum(ticket => ticket.Price),
                    Tickets = t.Tickets
                        .Where(ticket => ticket.RowNumber >= 1 && ticket.RowNumber <= 5)
                        .Select(ticket => new
                        {
                            Price = ticket.Price,
                            RowNumber = ticket.RowNumber
                        })
                        .OrderByDescending(ticket => ticket.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(theaters,Formatting.Indented);
        }
        public static string ExportPlays(TheatreContext context,double raiting)
        {
            ExportPlayDto[] playDtos = context.Plays
                .Where(p => p.Rating <= raiting)
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .Select(p => new ExportPlayDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .Where(c => c.IsMainCharacter)
                        .OrderByDescending(c => c.FullName)
                        .Select(c => new ExportActorDto
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .ToArray()
                })
                .ToArray();

            return XmlSerialize(playDtos,"Plays");
        }
        public static string XmlSerialize<T>(T obj,string rootName) where T : class
        {
            XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

            using StringWriter writer = new();

            XmlSerializerNamespaces namespaces = new();
            namespaces.Add(string.Empty,string.Empty);

            serializer.Serialize(writer,obj,namespaces);

            return writer.ToString();
        }
    }
}
