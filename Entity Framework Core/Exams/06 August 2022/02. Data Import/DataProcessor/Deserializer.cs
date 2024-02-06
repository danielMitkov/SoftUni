namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlTypes;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context,string xmlString)
        {
            ImportCoachDto[] coachDtos = XmlDeserialize<ImportCoachDto[]>(xmlString,"Coaches");

            List<Coach> coaches = new();
            StringBuilder sb = new();

            foreach(ImportCoachDto coachDto in coachDtos)
            {
                if(!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Coach coach = new Coach
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality
                };
                foreach(ImportFootballerDto footballerDto in coachDto.Footballers)
                {
                    bool isStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate
                        ,"dd/MM/yyyy"
                        ,CultureInfo.InvariantCulture
                        ,DateTimeStyles.None,
                        out DateTime startDate);

                    bool isEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate
                        ,"dd/MM/yyyy"
                        ,CultureInfo.InvariantCulture
                        ,DateTimeStyles.None,
                        out DateTime endDate);

                    if(!IsValid(footballerDto)
                        || !isStartDateValid
                        || !isEndDateValid
                        || startDate > endDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Footballer footballer = new Footballer
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate,
                        BestSkillType = Enum.Parse<BestSkillType>(footballerDto.BestSkillType),
                        PositionType = Enum.Parse<PositionType>(footballerDto.PositionType)
                    };
                    coach.Footballers.Add(footballer);
                }
                coaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach,coach.Name,coach.Footballers.Count));
            }
            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTeams(FootballersContext context,string jsonString)
        {
            ImportTeamDto[] teamDtos = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString)!;

            List<Team> teams = new();
            StringBuilder sb = new();

            int[] footballerIds = context.Footballers.Select(f => f.Id).ToArray();

            foreach(ImportTeamDto teamDto in teamDtos)
            {
                if(!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Team team = new Team
                {
                    Name = teamDto.Name,
                    Nationality = teamDto.Nationality,
                    Trophies = teamDto.Trophies
                };
                foreach(int id in teamDto.Footballers.Distinct())
                {
                    if(footballerIds.Contains(id) == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    team.TeamsFootballers.Add(new TeamFootballer
                    {
                        Team = team,
                        FootballerId = id
                    });
                }
                teams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam,team.Name,team.TeamsFootballers.Count));
            }
            context.Teams.AddRange(teams);
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
