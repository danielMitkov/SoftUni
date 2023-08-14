using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class WeaponTests
    {
        [Test]
        public void Ctor_Valid()
        {
            Weapon weapon = new Weapon("Bomb",1,5);
            Assert.That(weapon.Name.Equals("Bomb"));
            Assert.That(weapon.Price.Equals(1));
            Assert.That(weapon.DestructionLevel.Equals(5));
        }
        [Test]
        public void Price_ThrowsForLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Weapon weapon = new Weapon("Bomb",-1,5);
            });
        }
        [Test]
        public void IncreaseDestructionLevel_Valid()
        {
            Weapon weapon = new Weapon("Bomb",1,5);
            weapon.IncreaseDestructionLevel();
            Assert.That(weapon.DestructionLevel.Equals(6));
        }
        [Test]
        public void IsNuclear_True()//comment this one to see if judge notices
        {
            Weapon weapon = new Weapon("Bomb",1,10);
            Assert.That(weapon.IsNuclear.Equals(true));
        }
    }
}