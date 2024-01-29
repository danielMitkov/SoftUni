namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context,string jsonString)
        {
            List<ImportDepartmentDto> departmentDtos = JsonConvert.DeserializeObject<List<ImportDepartmentDto>>(jsonString);

            StringBuilder sb = new();

            for(int i = 0;i < departmentDtos.Count;++i)
            {
                ImportDepartmentDto departmentDto = departmentDtos[i];

                if(!IsValid(departmentDto) || !departmentDto.Cells.Any() || departmentDto.Cells.Any(c => !IsValid(c)))
                {
                    sb.AppendLine(ErrorMessage);
                    departmentDtos.Remove(departmentDto);
                    i--;
                    continue;
                }
                sb.AppendLine(string.Format(SuccessfullyImportedDepartment,departmentDto.Name,departmentDto.Cells.Length));
            }
            Department[] departments = departmentDtos
                .Select(d => new Department
                {
                    Name = d.Name,
                    Cells = d.Cells
                        .Select(c => new Cell
                        {
                            CellNumber = c.CellNumber,
                            HasWindow = c.HasWindow
                        })
                        .ToArray()
                })
                .ToArray();

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context,string jsonString)
        {
            List<ImportPrisonerDto> prisonerDtos = JsonConvert.DeserializeObject<List<ImportPrisonerDto>>(jsonString,new JsonSerializerSettings
            {
                DateFormatString = "dd/MM/yyyy"
            });

            StringBuilder sb = new();

            for(int i = 0;i < prisonerDtos.Count;i++)
            {
                ImportPrisonerDto prisonerDto = prisonerDtos[i];

                if(!IsValid(prisonerDto) || prisonerDto.Mails.Any(m => !IsValid(m)))
                {
                    sb.AppendLine(ErrorMessage);
                    prisonerDtos.Remove(prisonerDto);
                    i--;
                    continue;
                }
                sb.AppendLine(string.Format(SuccessfullyImportedPrisoner,prisonerDto.FullName,prisonerDto.Age));
            }
            Prisoner[] prisoners = prisonerDtos
                .Select(dtoP => new Prisoner
                {
                    FullName = dtoP.FullName,
                    Nickname = dtoP.Nickname,
                    Age = dtoP.Age,
                    IncarcerationDate = dtoP.IncarcerationDate,
                    ReleaseDate = dtoP.ReleaseDate,
                    Bail = dtoP.Bail,
                    CellId = dtoP.CellId,
                    Mails = dtoP.Mails
                        .Select(dtoM => new Mail
                        {
                            Description = dtoM.Description,
                            Sender = dtoM.Sender,
                            Address = dtoM.Address
                        })
                        .ToArray()
                })
                .ToArray();

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context,string xmlString)
        {
            List<ImportOfficerDto> officerDtos = XmlDeserialize<List<ImportOfficerDto>>(xmlString,"Officers");

            StringBuilder sb = new();

            for(int i = 0;i < officerDtos.Count;++i)
            {
                ImportOfficerDto officerDto = officerDtos[i];

                bool isPositionValid = Enum.TryParse<Position>(officerDto.Position,out _);
                bool isWeaponValid = Enum.TryParse<Weapon>(officerDto.Weapon,out _);

                if(!IsValid(officerDto) || !isPositionValid || !isWeaponValid)
                {
                    sb.AppendLine(ErrorMessage);
                    officerDtos.Remove(officerDto);
                    i--;
                    continue;
                }
                sb.AppendLine(string.Format(SuccessfullyImportedOfficer,officerDto.FullName,officerDto.Prisoners.Length));
            }
            Officer[] officers = officerDtos
                .Select(o => new Officer
                {
                    FullName = o.FullName,
                    Salary = o.Salary,
                    Position = Enum.Parse<Position>(o.Position),
                    Weapon = Enum.Parse<Weapon>(o.Weapon),
                    DepartmentId = o.DepartmentId
                })
                .ToArray();

            for(int i = 0;i < officers.Length;++i)
            {
                officers[i].OfficerPrisoners = officerDtos[i].Prisoners
                    .Select(p => new OfficerPrisoner
                    {
                        PrisonerId = p.PrisonerId,
                        Officer = officers[i]
                    })
                    .ToArray();
            }
            context.Officers.AddRange(officers);
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
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj,validationContext,validationResult,true);
            return isValid;
        }
    }
}
