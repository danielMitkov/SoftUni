using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Text;
namespace BookingApp.Models;
public class Booking:IBooking
{
    private IRoom room;
    private int residenceDuration;
    private int adultsCount;
    private int childrenCount;
    private int bookingNumber;
    public IRoom Room => room;
    public int ResidenceDuration
    {
        get => residenceDuration;
        private set
        {
            if(value < 1)
            {
                throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
            }
            residenceDuration = value;
        }
    }
    public int AdultsCount
    {
        get => adultsCount;
        private set
        {
            if(value < 1)
            {
                throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
            }
            adultsCount = value;
        }
    }
    public int ChildrenCount
    {
        get => childrenCount;
        private set
        {
            if(value < 0)
            {
                throw new ArgumentException(ExceptionMessages.ChildrenNegative);
            }
            childrenCount = value;
        }
    }
    public int BookingNumber => bookingNumber;
    public Booking(IRoom room,int residenceDuration,int adultsCount,int childrenCount,int bookingNumber)
    {
        this.room = room;
        ResidenceDuration = residenceDuration;
        AdultsCount = adultsCount;
        ChildrenCount = childrenCount;
        this.bookingNumber = bookingNumber;
    }
    public string BookingSummary()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Booking number: {BookingNumber}");
        sb.AppendLine($"Room type: {Room.GetType().Name}");
        sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
        sb.Append($"Total amount paid: {ResidenceDuration * Room.PricePerNight:F2} $");
        return sb.ToString();
    }
}
