namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context,string xmlString)
        {
            ImportDespatcherDto[] truckDtos = XmlDeserialize<ImportDespatcherDto[]>(xmlString,"Despatchers");

            List<Despatcher> despatchers = new();
            StringBuilder sb = new();

            foreach(ImportDespatcherDto despatcherDto in truckDtos)
            {
                if(!IsValid(despatcherDto)
                    || string.IsNullOrWhiteSpace(despatcherDto.Position))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Despatcher despatcher = new Despatcher
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position
                };
                foreach(ImportTruckDto truckDto in despatcherDto.Trucks)
                {
                    bool isCategoryTypeValid = Enum.TryParse(truckDto.CategoryType,out CategoryType categoryType);
                    bool isMakeTypeValid = Enum.TryParse(truckDto.MakeType,out MakeType makeType);

                    if(!IsValid(truckDto)
                        || !isCategoryTypeValid
                        || !isMakeTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    despatcher.Trucks.Add(new Truck
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = categoryType,
                        MakeType = makeType
                    });
                }
                despatchers.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher,despatcher.Name,despatcher.Trucks.Count));
            }
            context.Despatchers.AddRange(despatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context,string jsonString)
        {
            ImportClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString)!;

            List<Client> clients = new();
            StringBuilder sb = new();

            int[] truckIds = context.Trucks.Select(t => t.Id).ToArray();

            foreach(ImportClientDto clientDto in clientDtos)
            {
                if(!IsValid(clientDto) || clientDto.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Client client = new Client
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };
                foreach(int id in clientDto.Trucks.Distinct())
                {
                    if(truckIds.Contains(id) == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    client.ClientsTrucks.Add(new ClientTruck
                    {
                        Client = client,
                        TruckId = id
                    });
                }
                clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient,client.Name,client.ClientsTrucks.Count));
            }
            context.Clients.AddRange(clients);
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