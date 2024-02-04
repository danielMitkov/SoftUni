namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer // !!! SET ArtilleryProfile TO PUBLIC
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context,string xmlString)
        {
            ImportCountryDto[] countryDtos = XmlDeserialize<ImportCountryDto[]>(xmlString,"Countries");

            List<Country> countries = new();
            StringBuilder sb = new();

            foreach(ImportCountryDto countryDto in countryDtos)
            {
                if(!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Country country = new Country
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize
                };
                countries.Add(country);
                sb.AppendLine(string.Format(SuccessfulImportCountry,country.CountryName,country.ArmySize));
            }
            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context,string xmlString)
        {
            ImportManufacturerDto[] manufacturerDtos = XmlDeserialize<ImportManufacturerDto[]>(xmlString,"Manufacturers");

            List<Manufacturer> manufacturers = new();
            StringBuilder sb = new();

            foreach(ImportManufacturerDto manufacturerDto in manufacturerDtos)
            {
                if(!IsValid(manufacturerDto) || manufacturers.Any(m => m.ManufacturerName == manufacturerDto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Manufacturer manufacturer = new Manufacturer
                {
                    ManufacturerName = manufacturerDto.ManufacturerName,
                    Founded = manufacturerDto.Founded
                };
                manufacturers.Add(manufacturer);

                string[] foundedInfo = manufacturerDto.Founded.Split(", ",StringSplitOptions.RemoveEmptyEntries);

                string townCountryName = foundedInfo[foundedInfo.Length - 2] + ", " + foundedInfo[foundedInfo.Length - 1];

                sb.AppendLine(string.Format(SuccessfulImportManufacturer,manufacturer.ManufacturerName,townCountryName));
            }
            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context,string xmlString)
        {
            ImportShellDto[] shellDtos = XmlDeserialize<ImportShellDto[]>(xmlString,"Shells");

            List<Shell> shells = new();
            StringBuilder sb = new();

            foreach(ImportShellDto shellDto in shellDtos)
            {
                if(!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Shell shell = new Shell
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber
                };
                shells.Add(shell);
                sb.AppendLine(string.Format(SuccessfulImportShell,shell.Caliber,shell.ShellWeight));
            }
            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context,string jsonString)
        {
            ImportGunDto[] gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString)!;

            List<Gun> guns = new();
            StringBuilder sb = new();

            foreach(ImportGunDto gunDto in gunDtos)
            {
                bool isGunTypeValid = Enum.TryParse(gunDto.GunType,out GunType gunType);

                if(!IsValid(gunDto) || !isGunTypeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Gun gun = new Gun
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = gunType,
                    ShellId = gunDto.ShellId
                };
                gun.CountriesGuns = gunDto.Countries
                    .Select(dto => new CountryGun
                    {
                        Gun = gun,
                        CountryId = dto.Id
                    })
                    .ToArray();

                guns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun,gun.GunType.ToString(),gun.GunWeight,gun.BarrelLength));
            }
            context.Guns.AddRange(guns);
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