﻿
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context,double shellWeight)
        {
            var shells = context.Shells
                .Where(s => s.ShellWeight >= shellWeight)
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                        .Where(g => g.GunType == GunType.AntiAircraftGun)
                        .Select(g => new
                        {
                            GunType = g.GunType.ToString(),
                            GunWeight = g.GunWeight,
                            BarrelLength = g.BarrelLength,
                            Range = g.Range > 3000 ? "Long-range" : "Regular range"
                        })
                        .OrderByDescending(g => g.GunWeight)
                        .ToArray()
                })
                .OrderBy(s => s.ShellWeight)
                .ToArray();

            return JsonConvert.SerializeObject(shells,Formatting.Indented);
        }

        public static string ExportGuns(ArtilleryContext context,string manufacturer)
        {
            ExportGunDto[] gunDtos = context.Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new ExportGunDto
                {
                    ManufacturerName = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    GunWeight = g.GunWeight,
                    BarrelLength = g.BarrelLength,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                        .Where(cg => cg.Country.ArmySize > 4_500_000)
                        .Select(cg => new ExportCountryDto
                        {
                            CountryName = cg.Country.CountryName,
                            ArmySize = cg.Country.ArmySize
                        })
                        .OrderBy(c => c.ArmySize)
                        .ToArray()
                })
                .OrderBy(g => g.BarrelLength)
                .ToArray();

            return XmlSerialize(gunDtos,"Guns");
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
