using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
namespace BookingApp.Repositories;
public class HotelRepository:IRepository<IHotel>
{
    private List<IHotel> hotels = new();
    public void AddNew(IHotel model) => hotels.Add(model);
    public IReadOnlyCollection<IHotel> All() => hotels.AsReadOnly();
    public IHotel Select(string hotelName) => hotels.FirstOrDefault(x => x.FullName == hotelName);
}
