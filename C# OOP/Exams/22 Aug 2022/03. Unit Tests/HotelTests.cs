using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FrontDeskApp.Tests;
public class HotelTests
{
    [Test]
    public void ConstructorValid()
    {
        Hotel hotel = new("Bob",5);
        Assert.That(hotel.FullName,Is.EqualTo("Bob"));
        Assert.That(hotel.Category,Is.EqualTo(5));
        Assert.That(hotel.Rooms,Is.TypeOf(typeof(List<Room>)));
        Assert.That(hotel.Bookings,Is.TypeOf(typeof(List<Booking>)));
        Assert.That(hotel.Turnover,Is.EqualTo(0));
    }
    [TestCase(null)]
    [TestCase("")]
    [TestCase(" ")]
    public void FullNameThrowsForNullEmptyOrSpace(string name)
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            Hotel hotel = new(name,5);
        });
    }
    [TestCase(0)]
    [TestCase(6)]
    public void CategoryThrowsForOutOf1To5Range(int stars)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Hotel hotel = new("Bob",stars);
        });
    }
    [Test]
    public void AddRoomValid()
    {
        Room room = new(3,10);
        Hotel hotel = new("Bob",5);
        hotel.AddRoom(room);
        Assert.That(hotel.Rooms.Count,Is.EqualTo(1));
        Assert.That(hotel.Rooms.First(),Is.SameAs(room));
    }
    [TestCase(-1)]
    [TestCase(0)]
    public void BookRoomThrowsForAdultsLessOrZero(int adults)
    {
        Hotel hotel = new("Bob",5);
        Assert.Throws<ArgumentException>(() =>
        {
            hotel.BookRoom(adults,2,7,100);
        });
    }
    [Test]
    public void BookRoomThrowsForChildrenLessThanZero()
    {
        Hotel hotel = new("Bob",5);
        Assert.Throws<ArgumentException>(() =>
        {
            hotel.BookRoom(2,-1,7,100);
        });
    }
    [Test]
    public void BookRoomThrowsForDurationLessThanOne()
    {
        Hotel hotel = new("Bob",5);
        Assert.Throws<ArgumentException>(() =>
        {
            hotel.BookRoom(2,2,0,100);
        });
    }
    [Test]
    public void BookRoomIsSameAfterBedCapacityTooSmall()
    {
        Hotel hotel = new("Bob",5);
        Room room1 = new(1,10);
        Room room2 = new(2,10);
        hotel.AddRoom(room1);
        hotel.AddRoom(room2);
        hotel.BookRoom(2,2,7,10);
        Assert.That(hotel.Bookings.Count,Is.EqualTo(0));
        Assert.That(hotel.Turnover,Is.EqualTo(0));
    }
    [Test]
    public void BookRoomIsSameAfterNotEnoughMoney()
    {
        Hotel hotel = new("Bob",5);
        Room room1 = new(10,1000);
        Room room2 = new(12,1000);
        hotel.AddRoom(room1);
        hotel.AddRoom(room2);
        hotel.BookRoom(2,2,7,5);
        Assert.That(hotel.Bookings.Count,Is.EqualTo(0));
        Assert.That(hotel.Turnover,Is.EqualTo(0));
    }
    [Test]
    public void BookRoomValid()
    {
        Hotel hotel = new("Bob",5);
        Room room1 = new(3,10);
        hotel.AddRoom(room1);
        hotel.BookRoom(2,1,5,100);
        Assert.That(hotel.Bookings.Count,Is.EqualTo(1));
        Assert.That(hotel.Turnover,Is.EqualTo(50));
        Assert.That(hotel.Bookings.First().ResidenceDuration,Is.EqualTo(5));
        Assert.That(hotel.Bookings.First().BookingNumber,Is.EqualTo(1));
        Assert.That(hotel.Bookings.First().Room,Is.SameAs(room1));
    }
}
