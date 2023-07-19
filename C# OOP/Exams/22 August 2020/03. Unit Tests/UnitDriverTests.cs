using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class UnitDriverTests
    {
        [Test]
        public void Ctor_Valid()
        {
            UnitCar car = new UnitCar("bmw",100,3.4);
            UnitDriver driver = new UnitDriver("bob",car);
            Assert.AreEqual("bob",driver.Name);
            Assert.AreSame(car,driver.Car);
        }
        [Test]
        public void Name_ThrowsFor_Null()
        {
            UnitCar car = new UnitCar("bmw",100,3.4);
            Assert.Throws<ArgumentNullException>(() =>
            {
                UnitDriver driver = new UnitDriver(null,car);
            });
        }
    }
}
