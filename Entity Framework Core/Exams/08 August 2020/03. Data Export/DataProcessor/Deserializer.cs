namespace VaporStore.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using VaporStore.Data.Models;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.ImportDto;

    public static class Deserializer
    {
        public const string ErrorMessage = "Invalid Data";

        public const string SuccessfullyImportedGame = "Added {0} ({1}) with {2} tags";

        public const string SuccessfullyImportedUser = "Imported {0} with {1} cards";

        public const string SuccessfullyImportedPurchase = "Imported {0} for {1}";

        public static string ImportGames(VaporStoreDbContext context,string jsonString)
        {
            List<ImportGameDto> gameDtos = JsonConvert.DeserializeObject<List<ImportGameDto>>(jsonString,new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd"
            })!;
            List<Game> games = new();

            List<Developer> developers = new();
            List<Genre> genres = new();
            List<Tag> tags = new();

            StringBuilder sb = new();

            foreach(ImportGameDto gameDto in gameDtos)
            {
                if(!IsValid(gameDto) || !gameDto.Tags.Any())
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Developer dev = developers.FirstOrDefault(d => d.Name == gameDto.DeveloperName);

                if(dev == null)
                {
                    dev = new Developer
                    {
                        Name = gameDto.DeveloperName
                    };
                    developers.Add(dev);
                }
                Genre genre = genres.FirstOrDefault(g => g.Name == gameDto.Genre);

                if(genre == null)
                {
                    genre = new Genre
                    {
                        Name = gameDto.Genre
                    };
                    genres.Add(genre);
                }
                Game game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                    Developer = dev,
                    Genre = genre
                };
                foreach(string tagStr in gameDto.Tags)
                {
                    Tag tag = tags.FirstOrDefault(t => t.Name == tagStr);

                    if(tag == null)
                    {
                        tag = new Tag
                        {
                            Name = tagStr
                        };
                        tags.Add(tag);
                    }
                    game.GameTags.Add(new GameTag
                    {
                        Game = game,
                        Tag = tag
                    });
                }
                games.Add(game);

                sb.AppendLine(string.Format(SuccessfullyImportedGame,game.Name,game.Genre.Name,game.GameTags.Count()));
            }
            context.Games.AddRange(games);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportUsers(VaporStoreDbContext context,string jsonString)
        {
            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(jsonString)!;

            List<User> users = new();

            StringBuilder sb = new();

            foreach(ImportUserDto userDto in userDtos)
            {
                bool IsCardTypeValid = userDto.Cards.All(cardDto => Enum.TryParse<CardType>(cardDto.Type,out _));

                if(!IsValid(userDto)
                    || !userDto.Cards.Any()
                    || userDto.Cards.Any(c => !IsValid(c))
                    || !IsCardTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                User user = new User
                {
                    FullName = userDto.FullName,
                    Username = userDto.Username,
                    Email = userDto.Email,
                    Age = userDto.Age,
                    Cards = userDto.Cards
                        .Select(cardDto => new Card
                        {
                            Number = cardDto.Number,
                            Cvc = cardDto.Cvc,
                            Type = Enum.Parse<CardType>(cardDto.Type)
                        })
                        .ToArray()
                };
                users.Add(user);

                sb.AppendLine(string.Format(SuccessfullyImportedUser,user.Username,user.Cards.Count));
            }
            context.AddRange(users);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPurchases(VaporStoreDbContext context,string xmlString)
        {
            ImportPurchaseDto[] purchaseDtos = XmlDeserialize<ImportPurchaseDto[]>(xmlString,"Purchases");

            List<Purchase> purchases = new();

            StringBuilder sb = new();

            foreach(ImportPurchaseDto purchaseDto in purchaseDtos)
            {
                bool IsTypeValid = Enum.TryParse<PurchaseType>(purchaseDto.Type,out PurchaseType type);
                bool IsDateValid = DateTime.TryParseExact(purchaseDto.Date
                    ,@"dd/MM/yyyy HH:mm"
                    ,CultureInfo.InvariantCulture
                    ,DateTimeStyles.None
                    ,out DateTime date);

                Game game = context.Games.FirstOrDefault(g => g.Name == purchaseDto.GameTitle)!;
                Card card = context.Cards.FirstOrDefault(c => c.Number == purchaseDto.CardNumber)!;

                if(!IsValid(purchaseDto)
                    || !IsTypeValid
                    || !IsDateValid
                    || game == null
                    || card == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Purchase purchase = new Purchase
                {
                    Type = type,
                    ProductKey = purchaseDto.ProductKey,
                    Date = date,
                    Game = game,
                    Card = card
                };
                purchases.Add(purchase);

                sb.AppendLine(string.Format(SuccessfullyImportedPurchase,game.Name,card.User.Username));
            }
            context.Purchases.AddRange(purchases);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static T XmlDeserialize<T>(string xml,string rootName)
        {
            XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

            using StringReader reader = new(xml);

            return (T)serializer.Deserialize(reader)!;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto,validationContext,validationResult,true);
        }
    }
}
