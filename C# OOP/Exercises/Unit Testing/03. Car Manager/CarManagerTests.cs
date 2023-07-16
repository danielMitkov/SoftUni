namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        const string make = "Ford";
        const string model = "Focus";
        const int fuelConsumption = 48;
        const int fuelCapacity = 551;
        [Test]
        public void ConstructorValidCase()
        {
            Car car = new(make,model,fuelConsumption,fuelCapacity);
            Assert.AreEqual(make,car.Make,"make doesnt match");
            Assert.AreEqual(model,car.Model,"model doesnt match");
            Assert.AreEqual(fuelConsumption,car.FuelConsumption,"fuelConsumption doesnt match");
            Assert.AreEqual(fuelCapacity,car.FuelCapacity,"fuelCapacity doesnt match");
            Assert.AreEqual(0,car.FuelAmount,"fuelAmount doesnt match");
        }
        [TestCase(null)]
        [TestCase("")]
        public void MakeThrowsForNullOrEmpty(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new(value,model,fuelConsumption,fuelCapacity);
            },$"doesnt throw for {value} make");
        }
        [TestCase(null)]
        [TestCase("")]
        public void ModelThrowsForNullOrEmpty(string value)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new(make,value,fuelConsumption,fuelCapacity);
            },$"doesnt throw for {value} model");
        }
        [TestCase(-1)]
        [TestCase(0)]
        public void FuelConsumptionThrowsForLessOrZero(int amount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new(make,model,amount,fuelCapacity);
            },$"doesnt throw for {amount} fuelConsumption");
        }
        //[Test]Unreachable code!!
        //public void FuelAmountThrowsForLessThanZero()
        //{
        //    Car car = new(make,model,fuelConsumption,fuelCapacity);
        //    Assert.Throws<ArgumentException>(() =>
        //    {
        //        car.Drive(10000000);
        //    },"doesnt throw for negative fuelAmount");
        //}
        [TestCase(-1)]
        [TestCase(0)]
        public void FuelCapacityThrowsForLessOrZero(int amount)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new(make,model,fuelConsumption,amount);
            },$"doesnt throw for {amount} fuelCapacity");
        }
        [TestCase(-1)]
        [TestCase(0)]
        public void RefuelThrowsForLessOrZero(int amount)
        {
            Car car = new(make,model,fuelConsumption,fuelCapacity);
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(amount);
            },$"doesnt throw for {amount} refuel");
        }
        [Test]
        public void RefuelSameOrLessOfCapacity()
        {
            int amount = 5;
            Car car = new(make,model,fuelConsumption,fuelCapacity);
            car.Refuel(amount);
            Assert.AreEqual(amount,car.FuelAmount);
        }
        [Test]
        public void RuelBiggerThenCapacity()
        {
            int amount = 1000;
            Car car = new(make,model,fuelConsumption,fuelCapacity);
            car.Refuel(amount);
            Assert.AreEqual(fuelCapacity,car.FuelAmount);
        }
        [Test]
        public void DriveThrowsForNeededBiggerThenAmount()
        {
            double distance = 5;
            Car car = new(make,model,fuelConsumption,fuelCapacity);
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            },$"doesnt throw for {distance} distance");
        }
        [Test]
        public void DriveValidCase()
        {
            Car car = new(make,model,fuelConsumption,fuelCapacity);
            car.Refuel(10);
            car.Drive(5);
            Assert.AreEqual(7.6,car.FuelAmount,"fuel amount doesnt match");
        }
    }
}