﻿namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context,string xmlString)
        {
            ImportPlayDto[] playDtos = XmlDeserialize<ImportPlayDto[]>(xmlString,"Plays");

            List<Play> plays = new();

            StringBuilder sb = new();

            foreach(ImportPlayDto playDto in playDtos)
            {
                bool isDurationValid = TimeSpan.TryParseExact(playDto.Duration
                    ,"c"
                    ,CultureInfo.InvariantCulture
                    ,TimeSpanStyles.None
                    ,out TimeSpan duration);

                if(duration.Hours < 1)
                {
                    isDurationValid = false;
                }
                bool isGenreValid = Enum.TryParse(playDto.Genre,out Genre genre);

                if(!IsValid(playDto)
                    || !isDurationValid
                    || !isGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Play play = new Play
                {
                    Title = playDto.Title,
                    Duration = duration,
                    Rating = playDto.Rating,
                    Genre = genre,
                    Description = playDto.Description,
                    Screenwriter = playDto.Screenwriter
                };
                plays.Add(play);
                sb.AppendLine(string.Format(SuccessfulImportPlay,play.Title,play.Genre.ToString(),play.Rating));
            }
            context.Plays.AddRange(plays);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportCasts(TheatreContext context,string xmlString)
        {
            ImportCastDto[] castDtos = XmlDeserialize<ImportCastDto[]>(xmlString,"Casts");

            List<Cast> casts = new();

            StringBuilder sb = new();

            foreach(ImportCastDto castDto in castDtos)
            {
                if(!IsValid(castDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Cast cast = new Cast
                {
                    FullName = castDto.FullName,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PhoneNumber = castDto.PhoneNumber,
                    PlayId = castDto.PlayId
                };
                casts.Add(cast);

                string characterType = cast.IsMainCharacter ? "main" : "lesser";

                sb.AppendLine(string.Format(SuccessfulImportActor,cast.FullName,characterType));
            }
            context.Casts.AddRange(casts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTtheatersTickets(TheatreContext context,string jsonString)
        {
            ImportTheatreDto[] theatreDtos = JsonConvert.DeserializeObject<ImportTheatreDto[]>(jsonString)!;

            List<Theatre> theatres = new();

            StringBuilder sb = new();

            foreach(ImportTheatreDto theatreDto in theatreDtos)
            {
                if(!IsValid(theatreDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Theatre theatre = new Theatre
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director
                };
                foreach(ImportTicketDto ticketDto in theatreDto.Tickets)
                {
                    if(!IsValid(ticketDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    theatre.Tickets.Add(new Ticket
                    {
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,
                        Theatre = theatre
                    });
                }
                theatres.Add(theatre);
                sb.AppendLine(string.Format(SuccessfulImportTheatre,theatre.Name,theatre.Tickets.Count));
            }
            context.Theatres.AddRange(theatres);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static T XmlDeserialize<T>(string xml,string rootName)
        {
            XmlSerializer serializer = new(typeof(T),new XmlRootAttribute(rootName));

            using StringReader reader = new(xml);

            return (T)serializer.Deserialize(reader)!;
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj,validator,validationRes,true);
            return result;
        }
    }
}
