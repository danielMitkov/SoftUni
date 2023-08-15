using System;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
namespace BookingApp.Models;
public abstract class Room:IRoom
{
    private int bedCapacity;
    private double pricePerNight;
    public int BedCapacity { get => bedCapacity; private set => bedCapacity = value; }
    public double PricePerNight
    {
        get => pricePerNight;
        private set
        {
            if(value < 0)
            {
                throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
            }
            pricePerNight = value;
        }
    }
    protected Room(int bedCapacity)
    {
        BedCapacity = bedCapacity;
        PricePerNight = 0;
    }
    public void SetPrice(double price) => PricePerNight = price;
}
