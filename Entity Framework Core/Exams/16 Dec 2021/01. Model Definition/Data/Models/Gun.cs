using Artillery.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artillery.Data.Models;
public class Gun
{
    [Key]
    public int Id { get; set; }

    public int ManufacturerId { get; set; }

    [ForeignKey(nameof(ManufacturerId))]
    public Manufacturer Manufacturer { get; set; }

    public int GunWeight { get; set; }

    public double BarrelLength { get; set; }

    public int? NumberBuild { get; set; }

    public int Range { get; set; }

    public GunType GunType { get; set; }

    public int ShellId { get; set; }

    [ForeignKey(nameof(ShellId))]
    public Shell Shell { get; set; }

    public ICollection<CountryGun> CountriesGuns { get; set; } = new HashSet<CountryGun>();
}
