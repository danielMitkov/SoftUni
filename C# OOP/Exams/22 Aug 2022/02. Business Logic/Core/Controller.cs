﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Core.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using BookingApp.Models;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Bookings.Contracts;
namespace BookingApp.Core;
public class Controller:IController
{
    private IRepository<IHotel> hotels = new HotelRepository();
    public string AddHotel(string hotelName,int category)
    {
        if(hotels.All().Any(x=>x.FullName == hotelName))
        {
            return string.Format(OutputMessages.HotelAlreadyRegistered,hotelName);
        }
        IHotel hotel = new Hotel(hotelName,category);
        hotels.AddNew(hotel);
        return string.Format(OutputMessages.HotelSuccessfullyRegistered,category,hotelName);
    }
    public string BookAvailableRoom(int adults,int children,int duration,int category)
    {
        int people = adults + children;
        List<IHotel> selectedHotels = hotels.All().Where(x=>x.Category == category).ToList();
        if(selectedHotels.Count ==0)
        {
            return string.Format(OutputMessages.CategoryInvalid,category);
        }
        Dictionary<IRoom,IHotel> selectedRooms = new();
        foreach(IHotel hotel in selectedHotels)
        {//collecting fit rooms from ALL hotels
            foreach(IRoom room in hotel.Rooms.All()
                .Where(x=>x.PricePerNight > 0)
                .Where(x=>x.BedCapacity >= people))
            {
                selectedRooms.Add(room,hotel);
            }
        }
        var chosenPair = selectedRooms.OrderBy(x => x.Key.BedCapacity).FirstOrDefault();
        if(chosenPair.Key != null)
        {
            IRoom room = chosenPair.Key;
            IHotel hotel = chosenPair.Value;
            int bookingNum = hotel.Bookings.All().Count + 1;
            IBooking booking = new Booking(room,duration,adults,children,bookingNum);
            hotel.Bookings.AddNew(booking);
            return string.Format(OutputMessages.BookingSuccessful,bookingNum,hotel.FullName);
        }
        return OutputMessages.RoomNotAppropriate;
    }
    public string HotelReport(string hotelName)
    {
        IHotel hotel = hotels.Select(hotelName);
        if(hotel == null)
        {
            return string.Format(OutputMessages.HotelNameInvalid,hotelName);
        }
        StringBuilder sb = new();
        sb.AppendLine($"Hotel name: {hotelName}");
        sb.AppendLine($"--{hotel.Category} star hotel");
        sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
        sb.AppendLine($"--Bookings:");
        if(hotel.Bookings.All().Count == 0)
        {
            sb.AppendLine();
            sb.AppendLine("none");
        }
        else
        {
            foreach(IBooking booking in hotel.Bookings.All())
            {
                sb.AppendLine();
                sb.AppendLine(booking.BookingSummary());
            }
        }
        return sb.ToString().TrimEnd();
    }
    public string SetRoomPrices(string hotelName,string roomTypeName,double price)
    {
        IHotel hotel = hotels.Select(hotelName);
        if(hotel == null)
        {
            return string.Format(OutputMessages.HotelNameInvalid,hotelName);
        }
        if(roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
        {
            throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
        }
        IRoom room = hotel.Rooms.Select(roomTypeName);
        if(room == null)
        {
            return OutputMessages.RoomTypeNotCreated;
        }
        if(room.PricePerNight > 0)
        {
            throw new InvalidOperationException(ExceptionMessages.CannotResetInitialPrice);
        }
        room.SetPrice(price);
        return string.Format(OutputMessages.PriceSetSuccessfully,roomTypeName,hotelName);
    }
    public string UploadRoomTypes(string hotelName,string roomTypeName)
    {
        IHotel hotel = hotels.Select(hotelName);
        if(hotel == null)
        {
            return string.Format(OutputMessages.HotelNameInvalid,hotelName);
        }
        if(hotel.Rooms.Select(roomTypeName) != null)
        {
            return OutputMessages.RoomTypeAlreadyCreated;
        }
        IRoom room = null;
        switch(roomTypeName)
        {
            case "Apartment":
                room = new Apartment();
                break;
            case "DoubleBed":
                room = new DoubleBed();
                break;
            case "Studio":
                room = new Studio();
                break;
            default:
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
        }
        hotel.Rooms.AddNew(room);
        return string.Format(OutputMessages.RoomTypeAdded,roomTypeName,hotel.FullName);
    }
}
