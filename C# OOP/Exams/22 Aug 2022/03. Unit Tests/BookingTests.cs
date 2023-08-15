using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests;
public class BookingTests
{
    [Test]
    public void ConstructorValid()
    {
        Room room = new(3,10);
        Booking booking = new Booking(1,room,7);
        Assert.That(booking.BookingNumber,Is.EqualTo(1));
        Assert.That(booking.ResidenceDuration,Is.EqualTo(7));
        Assert.That(booking.Room,Is.SameAs(room));
        Assert.That(booking.BookingNumber,Is.EqualTo(1));
    }
}
