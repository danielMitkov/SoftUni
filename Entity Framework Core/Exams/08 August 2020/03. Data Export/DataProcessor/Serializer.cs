namespace VaporStore.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Xml.Serialization;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ExportDto;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context,string[] genreNames)
        {
            var gamesByGenres = context.Genres
                .Where(ge => genreNames.Contains(ge.Name))
                .ToArray()
                .Select(ge => new
                {
                    Id = ge.Id,
                    Genre = ge.Name,
                    Games = ge.Games
                        .Where(ga => ga.Purchases.Any())
                        .Select(ga => new
                        {
                            Id = ga.Id,
                            Title = ga.Name,
                            Developer = ga.Developer.Name,
                            Tags = string.Join(", ",ga.GameTags.Select(gt => gt.Tag.Name)),
                            Players = ga.Purchases.Count
                        })
                        .OrderByDescending(ga => ga.Players)
                        .ThenBy(ga => ga.Id)
                        .ToArray(),
                    TotalPlayers = ge.Games.Sum(ga => ga.Purchases.Count)
                })
                .OrderByDescending(ge => ge.TotalPlayers)
                .ThenBy(ge => ge.Id)
                .ToArray();

            return JsonConvert.SerializeObject(gamesByGenres,Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context,string purchaseType)
        {
            PurchaseType purchaseTypeEnum = Enum.Parse<PurchaseType>(purchaseType);

            ExportUserDto[] users = context.Users
                .Where(u => u.Cards.Any(c => c.Purchases.Any(p => p.Type == purchaseTypeEnum)))
                .Select(u => new ExportUserDto()
                {
                    Username = u.Username,
                    Purchases = context.Purchases
                        .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                        .OrderBy(p => p.Date)
                        .Select(p => new ExportPurchaseDto()
                        {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm",CultureInfo.InvariantCulture),
                            Game = new ExportGameDto()
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = (double)p.Game.Price
                            }
                        })
                        .ToArray(),//cast to double to remove trailing zeros
                    TotalSpent = (double)context.Purchases
                        .Where(p => p.Card.User.Username == u.Username && p.Type == purchaseTypeEnum)
                        .Sum(p => p.Game.Price)
                })
                .OrderByDescending(u => u.TotalSpent)
                .ThenBy(u => u.Username)
                .ToArray();

            return XmlSerialize(users,"Users");
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