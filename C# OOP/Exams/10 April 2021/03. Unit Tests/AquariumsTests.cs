namespace Aquariums.Tests
{
    using System;
    using System.Xml.Linq;
    using NUnit.Framework;
    public class AquariumsTests
    {
        [Test]
        public void Fish_Ctor_Valid()
        {
            Fish fish = new Fish("bob");
            Assert.AreEqual("bob",fish.Name);
            Assert.AreEqual(true,fish.Available);
        }
        [Test]
        public void Aquarium_Ctor_Valid()
        {
            Aquarium aquarium = new Aquarium("box",3);
            Assert.AreEqual("box",aquarium.Name);
            Assert.AreEqual(3,aquarium.Capacity);
            Assert.AreEqual(0,aquarium.Count);
        }
        [TestCase(null)]
        [TestCase("")]
        public void Name_ThrowsFor_NullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Aquarium aquarium = new Aquarium(name,3);
            });
        }
        [Test]
        public void Capacity_ThrowFor_Negative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Aquarium aquarium = new Aquarium("box",-1);
            });
        }
        [Test]
        public void Add_ThrowsFor_Full()
        {
            Aquarium aquarium = new Aquarium("box",0);
            Fish fish = new Fish("bob");
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.Add(fish);
            });
        }
        [Test]
        public void Add_Valid()
        {
            Aquarium aquarium = new Aquarium("box",1);
            Fish fish = new Fish("bob");
            aquarium.Add(fish);
            Assert.AreEqual(1,aquarium.Count);
        }
        [Test]
        public void RemoveFish_ThrowsFor_NotFound()
        {
            Aquarium aquarium = new Aquarium("box",1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.RemoveFish("bob");
            });
        }
        [Test]
        public void RemoveFish_Valid()
        {
            Aquarium aquarium = new Aquarium("box",1);
            Fish fish = new Fish("bob");
            aquarium.Add(fish);
            aquarium.RemoveFish("bob");
            Assert.AreEqual(0,aquarium.Count);
        }
        [Test]
        public void SellFish_ThrowsFor_NotFound()
        {
            Aquarium aquarium = new Aquarium("box",1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                aquarium.SellFish("bob");
            });
        }
        [Test]
        public void SellFish_Valid()
        {
            Aquarium aquarium = new Aquarium("box",1);
            Fish fish = new Fish("bob");
            aquarium.Add(fish);
            Fish actual = aquarium.SellFish("bob");
            Assert.AreEqual(false,actual.Available);
            Assert.AreSame(fish,actual);
        }
        [Test]
        public void Report_Valid()
        {
            Aquarium aquarium = new Aquarium("box",2);
            Fish bob = new Fish("bob");
            Fish kim = new Fish("kim");
            string expected = "Fish available at box: bob, kim";
            aquarium.Add(bob);
            aquarium.Add(kim);
            Assert.AreEqual(expected,aquarium.Report());
        }
    }
}
