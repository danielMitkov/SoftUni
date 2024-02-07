using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models;
public class Truck
{
    [Key]
    public int Id { get; set; }

    [MaxLength(8)]
    public string? RegistrationNumber { get; set; }

    [Required, MaxLength(17)]
    public string VinNumber { get; set; }

    [Required]//mistake in description!!
    public int TankCapacity { get; set; }

    [Required]//mistake in description!!
    public int CargoCapacity { get; set; }

    [Required]
    public CategoryType CategoryType { get; set; }

    [Required]
    public MakeType MakeType { get; set; }

    [Required]
    public int DespatcherId { get; set; }

    [Required, ForeignKey(nameof(DespatcherId))]
    public Despatcher Despatcher { get; set; }

    public ICollection<ClientTruck> ClientsTrucks { get; set; } = new HashSet<ClientTruck>();
}
