using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [Test]
        public void Ctor_Valid()
        {
            RaceEntry race = new RaceEntry();
            Assert.AreEqual(0,race.Counter);
        }
        [Test]
        public void AddDriver_ThrowsFor_Null()
        {
            RaceEntry race = new RaceEntry();
            var ex = Assert.Throws<InvalidOperationException>(()=> race.AddDriver(null));
            Assert.AreEqual("Driver cannot be null.",ex.Message);
        }
        [Test]
        public void AddDriver_ThrowsFor_Duplicate()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("bmw",100,3.4);
            UnitDriver driver = new UnitDriver("bob",car);
            race.AddDriver(driver);
            var ex = Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
            Assert.AreEqual("Driver bob is already added.",ex.Message);
        }
        [Test]
        public void CalculateAverageHorsePower_ThrowsFor_LessThan_Two_Drivers()
        {
            RaceEntry race = new RaceEntry();
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }
        [Test]
        public void CalculateAverageHorsePower_Valid()
        {
            RaceEntry race = new RaceEntry();
            UnitCar car = new UnitCar("bmw",100,3.4);
            UnitDriver driver = new UnitDriver("bob",car);
            UnitCar car2 = new UnitCar("audi",80,2.3);
            UnitDriver driver2 = new UnitDriver("kim",car2);
            race.AddDriver(driver);
            race.AddDriver(driver2);
            double actualAverage = race.CalculateAverageHorsePower();
            Assert.AreEqual(90,actualAverage);
        }
    }
}