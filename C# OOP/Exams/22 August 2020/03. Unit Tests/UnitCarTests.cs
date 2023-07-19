using NUnit.Framework;
namespace TheRace.Tests
{
    public class UnitCarTests
    {
        [Test]
        public void Ctor_Valid()
        {
            UnitCar car = new UnitCar("bmw",100,3.4);
            Assert.AreEqual("bmw",car.Model);
            Assert.AreEqual(100,car.HorsePower);
            Assert.AreEqual(3.4,car.CubicCentimeters);
        }
    }
}
