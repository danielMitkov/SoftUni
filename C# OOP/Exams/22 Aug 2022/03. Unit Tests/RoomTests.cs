using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontDeskApp.Tests;
public class RoomTests
{
    [Test]
    public void ConstructorValid()
    {
        Room room = new(3,10);
        Assert.That(room.BedCapacity,Is.EqualTo(3));
        Assert.That(room.PricePerNight,Is.EqualTo(10));
    }
    [TestCase(-1)]
    [TestCase(0)]
    public void BedCapacityThrowsForLessOrZero(int value)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Room room = new(value,10);
        });
    }
    [TestCase(-1)]
    [TestCase(0)]
    public void PricePerNightThrowsForLessOrZero(int value)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            Room room = new(3,value);
        });
    }
}
