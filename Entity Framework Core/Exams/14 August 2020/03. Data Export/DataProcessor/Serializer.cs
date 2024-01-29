namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System.Globalization;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context,int[] ids)
        {
            var prisoners = context.Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => new
                        {
                            OfficerName = po.Officer.FullName,
                            Department = po.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(po => po.Officer.Salary),2)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            return JsonConvert.SerializeObject(prisoners,Formatting.Indented);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context,string prisonersNames)
        {
            string[] names = prisonersNames.Split(",");

            ExportPrisonerDto[] prisonerDtos = context.Prisoners
                .Where(p => names.Contains(p.FullName))
                .Select(p => new ExportPrisonerDto
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd",CultureInfo.InvariantCulture),
                    EncryptedMessages = p.Mails
                        .Select(m => new ExportMessageDto
                        {
                            Description = string.Join("",m.Description.Reverse())
                        })
                        .ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            return XmlSerialize(prisonerDtos,"Prisoners");
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