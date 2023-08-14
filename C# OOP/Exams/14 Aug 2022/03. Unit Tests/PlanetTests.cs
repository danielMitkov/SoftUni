using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;

namespace PlanetWars.Tests
{
    public class PlanetTests
    {
        [Test]
        public void Ctor_Valid()
        {
            Planet planet = new Planet("Earth",1);
            Assert.That(planet.Name.Equals("Earth"));
            Assert.That(planet.Budget.Equals(1));
            Assert.That(planet.Weapons,Is.TypeOf(typeof(List<Weapon>)));
        }
        [TestCase(null)]
        [TestCase("")]
        public void Name_ThrowsForNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Planet planet = new Planet(name,1);
            });
        }
        [Test]
        public void Budget_ThrowsForLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Planet planet = new Planet("Earth",-1);
            });
        }
        [Test]
        public void MilitaryPowerRatio_Valid()
        {
            Planet planet = new Planet("Earth",100);
            Weapon bomb = new Weapon("Bomb",10,15);
            Weapon rocket = new Weapon("Rocket",2,5);
            planet.AddWeapon(bomb);
            planet.AddWeapon(rocket);
            Assert.That(planet.MilitaryPowerRatio.Equals(20));
        }
        [Test]
        public void Profit_Valid()
        {
            Planet planet = new Planet("Earth",100);
            planet.Profit(10);
            Assert.That(planet.Budget.Equals(110));
        }
        [Test]
        public void SpendFunds_ThrowsForTooLow()
        {
            Planet planet = new Planet("Earth",100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.SpendFunds(120);
            });
        }
        [Test]
        public void SpendFunds_Valid()
        {
            Planet planet = new Planet("Earth",100);
            planet.SpendFunds(100);
            Assert.That(planet.Budget.Equals(0));
        }
        [Test]
        public void AddWeapon_ThrowsFor_AlreadyAdded()
        {
            Planet planet = new Planet("Earth",100);
            Weapon bomb = new Weapon("Bomb",10,15);
            planet.AddWeapon(bomb);
            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.AddWeapon(bomb);
            });
        }
        [Test]
        public void RemoveWeapon_Valid()
        {
            Planet planet = new Planet("Earth",100);
            Weapon bomb = new Weapon("Bomb",10,15);
            planet.AddWeapon(bomb);
            planet.RemoveWeapon(bomb.Name);
            Assert.That(planet.Weapons.Count.Equals(0));
        }
        [Test]
        public void UpgradeWeapon_Valid()
        {
            Planet planet = new Planet("Earth",100);
            Weapon bomb = new Weapon("Bomb",10,15);
            planet.AddWeapon(bomb);
            planet.UpgradeWeapon(bomb.Name);
            Assert.That(bomb.DestructionLevel.Equals(16));
        }
        [Test]
        public void UpgradeWeapon_ThrowsFor_NotFound()
        {
            Planet planet = new Planet("Earth",100);
            Assert.Throws<InvalidOperationException>(() =>
            {
                planet.UpgradeWeapon("Bomb");
            });
        }
        [Test]
        public void DestructOpponent_ThrowsFor_EnemyTooStrong()
        {
            Planet earth = new Planet("Earth",100);
            Planet mars = new Planet("Mars",10000);
            Assert.Throws<InvalidOperationException>(() =>
            {
                earth.DestructOpponent(mars);
            });
        }
        [Test]
        public void DestructOpponent_Valid()
        {
            Weapon bomb = new Weapon("Bomb",10,15);
            Weapon rocket = new Weapon("Rocket",2,5);
            Planet earth = new Planet("Earth",100);
            earth.AddWeapon(bomb);
            earth.AddWeapon(rocket);
            Planet mars = new Planet("Mars",10000);
            Weapon laser = new Weapon("Laser",1000,100);
            mars.AddWeapon(laser);
            string result = mars.DestructOpponent(earth);
            Assert.That(result.Equals($"{earth.Name} is destructed!"));
        }
    }
}
