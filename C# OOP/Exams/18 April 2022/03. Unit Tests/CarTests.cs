using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace RepairShop.Tests
{
    public class CarTests
    {
        [Test]
        public void Ctor_Valid()
        {
            Car car = new Car("BMW",0);
            Assert.That(car.CarModel.Equals("BMW"));
            Assert.That(car.NumberOfIssues.Equals(0));
            Assert.That(car.IsFixed.Equals(true));
        }
    }
}
