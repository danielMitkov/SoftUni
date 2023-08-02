using NUnit.Framework;
using System;
using System.Net.Http;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void Phone_Ctor_Valid()
        {
            Smartphone phone = new("S3",10);
            Assert.That(phone.ModelName,Is.EqualTo("S3"));
            Assert.That(phone.MaximumBatteryCharge,Is.EqualTo(10));
            Assert.That(phone.CurrentBateryCharge,Is.EqualTo(10));
        }
        [Test]
        public void Shop_Ctor_Valid()
        {
            Shop shop = new(5);
            Assert.That(shop.Capacity,Is.EqualTo(5));
            Assert.That(shop.Count,Is.EqualTo(0));
        }
        [Test]
        public void Capacity_ThrowsFor_Negative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new(-1);
            });
        }
        [Test]
        public void Add_Valid()
        {
            Shop shop = new(5);
            Smartphone phone = new Smartphone("S3",10);
            shop.Add(phone);
            Assert.That(shop.Count,Is.EqualTo(1));
        }
        [Test]
        public void Add_ThrowsFor_AlreadyExists()
        {
            Shop shop = new(5);
            Smartphone phone = new Smartphone("S3",10);
            shop.Add(phone);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone);
            });
            Assert.That(ex.Message,Is.EqualTo("The phone model S3 already exist."));
        }
        [Test]
        public void Add_ThrowsFor_FullShop()
        {
            Shop shop = new(1);
            Smartphone phone = new Smartphone("S3",10);
            Smartphone phone2 = new Smartphone("S4",12);
            shop.Add(phone);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone2);
            });
            Assert.That(ex.Message,Is.EqualTo("The shop is full."));
        }
        [Test]
        public void Remove_ThrowsFor_NotFound()
        {
            Shop shop = new Shop(5);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove("Bob");
            });
            Assert.That(ex.Message,Is.EqualTo("The phone model Bob doesn't exist."));
        }
        [Test]
        public void Remove_Valid()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new("S3",10);
            shop.Add(phone);
            shop.Remove("S3");
            Assert.That(shop.Count,Is.EqualTo(0));
        }
        [Test]
        public void ChargePhone_ThrowsFor_NotFound()
        {
            Shop shop = new Shop(5);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone("Bob");
            });
            Assert.That(ex.Message,Is.EqualTo("The phone model Bob doesn't exist."));
        }
        [Test]
        public void ChargePhone_Valid()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new("S3",10);
            shop.Add(phone);
            shop.TestPhone("S3",7);
            shop.ChargePhone("S3");
            Assert.That(phone.CurrentBateryCharge,Is.EqualTo(10));
        }
        [Test]
        public void TestPhone_ThrowsFor_NotFound()
        {
            Shop shop = new Shop(5);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("Bob",5);
            });
            Assert.That(ex.Message,Is.EqualTo("The phone model Bob doesn't exist."));
        }
        [Test]
        public void TestPhone_Valid()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("S3", 10);
            shop.Add(phone);
            shop.TestPhone("S3",6);
            Assert.That(phone.CurrentBateryCharge,Is.EqualTo(4));
        }
        [Test]
        public void TestPhone_ThrowsFor_LowBattery()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("S3",10);
            shop.Add(phone);
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone("S3",100);
            });
            Assert.That(ex.Message,Is.EqualTo("The phone model S3 is low on batery."));
        }
    }
}