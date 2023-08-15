﻿using System;
using System.Collections.Generic;
using System.Linq;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
namespace BookingApp.Models;
public class Hotel:IHotel
{
    private string fullName;
    private int category;
    private IRepository<IRoom> rooms = new RoomRepository();
    private IRepository<IBooking> bookings = new BookingRepository();
    public string FullName
    {
        get => fullName;
        private set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
            }
            fullName = value;
        }
    }
    public int Category
    {
        get => category;
        private set
        {
            if(value < 1 || value > 5)
            {
                throw new ArgumentException(ExceptionMessages.InvalidCategory);
            }
            category = value;
        }
    }
    public double Turnover => bookings.All().Sum(x=>x.ResidenceDuration * x.Room.PricePerNight);
    public IRepository<IRoom> Rooms => rooms;
    public IRepository<IBooking> Bookings => bookings;
    public Hotel(string fullName,int category)
    {
        FullName = fullName;
        Category = category;
    }
}
