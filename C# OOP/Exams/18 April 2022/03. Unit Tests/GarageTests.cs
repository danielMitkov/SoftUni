using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class GarageTests
    {
        [Test]
        public void Ctor_Valid()
        {
            Garage garage = new Garage("Bob",1);
            Assert.That(garage.Name.Equals("Bob"));
            Assert.That(garage.MechanicsAvailable.Equals(1));
        }
        [Test]
        public void Name_ThrowsFor_NullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Garage garage = new Garage(null,1);
            });
        }
        [Test]
        public void MechanicsAvailable_ThrowsFor_LessOrZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Garage garage = new Garage("Bob",0);
            });
        }
        [Test]
        public void AddCar_ThrowsFor_Both()
        {
            Garage garage = new Garage("Bob",1);
            Car car = new Car("BMW",0);
            garage.AddCar(car);
            Assert.Throws<InvalidOperationException>(() =>
            {
                garage.AddCar(car);
            });
        }
        [Test]
        public void FixCar_ThrowsFor_NoCar()
        {
            Garage garage = new Garage("Bob",1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                garage.FixCar("BMW");
            });
        }
        [Test]
        public void FixCar_Valid()
        {
            Garage garage = new Garage("Bob",1);
            Car car = new Car("BMW",1);
            garage.AddCar(car);
            Car actual = garage.FixCar("BMW");
            Assert.That(actual,Is.SameAs(car));
            Assert.That(actual.NumberOfIssues.Equals(0));
        }
        [Test]
        public void RemoveFixedCar_ThrowsFor_NoCar()
        {
            Garage garage = new Garage("Bob",1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                garage.RemoveFixedCar();
            });
        }
        [Test]
        public void RemoveFixedCar_Valid()
        {
            Garage garage = new Garage("Bob",1);
            Car car = new Car("BMW",1);
            garage.AddCar(car);
            garage.FixCar("BMW");
            int removedCount = garage.RemoveFixedCar();
            Assert.That(removedCount.Equals(1));
            Assert.That(garage.CarsInGarage.Equals(0));
        }
        [Test]
        public void Report_Valid()
        {
            Car bmw = new Car("BMW",5);
            Car ford = new Car("Ford",0);
            Car tesla = new Car("Tesla",1);
            Garage garage = new Garage("Bob",3);
            string expected = $"There are 2 which are not fixed: BMW, Tesla.";
            garage.AddCar(bmw);
            garage.AddCar(ford);
            garage.AddCar(tesla);
            string actual = garage.Report();
            Assert.That(actual,Is.EqualTo(expected));
        }
    }
}
