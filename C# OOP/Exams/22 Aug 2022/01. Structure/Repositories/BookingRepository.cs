using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
namespace BookingApp.Repositories;
public class BookingRepository:IRepository<IBooking>
{
    private List<IBooking> bookings = new();
    public void AddNew(IBooking model) => bookings.Add(model);
    public IReadOnlyCollection<IBooking> All() => bookings.AsReadOnly();
    public IBooking Select(string number) => bookings.FirstOrDefault(x => x.BookingNumber == int.Parse(number));
}
