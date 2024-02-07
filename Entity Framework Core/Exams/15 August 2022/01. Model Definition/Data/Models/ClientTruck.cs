using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trucks.Data.Models;
public class ClientTruck
{
    [Required]
    public int ClientId { get; set; }

    [Required, ForeignKey(nameof(ClientId))]
    public Client Client { get; set; }

    [Required]
    public int TruckId { get; set; }

    [Required, ForeignKey(nameof(TruckId))]
    public Truck Truck { get; set; }
}
