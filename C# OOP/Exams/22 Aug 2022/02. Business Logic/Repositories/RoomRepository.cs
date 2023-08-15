using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
namespace BookingApp.Repositories;
public class RoomRepository:IRepository<IRoom>
{
    private List<IRoom> rooms = new();
    public void AddNew(IRoom model) => rooms.Add(model);
    public IReadOnlyCollection<IRoom> All() => rooms.AsReadOnly();
    public IRoom Select(string typeName) => rooms.FirstOrDefault(x => x.GetType().Name == typeName);
}
