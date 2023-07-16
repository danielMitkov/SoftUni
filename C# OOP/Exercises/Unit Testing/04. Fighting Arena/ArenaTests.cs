namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior bob;
        private Warrior john;
        [SetUp]
        public void SetUp()
        {
            arena = new();
            bob = new("Bob",75,75);
            john = new("John",50,100);
        }
        [Test]
        public void ConstructorMakesEmptyList()
        {
            arena = new();
            Assert.AreEqual(0,arena.Count);
        }
        [Test]
        public void EnrollValidCase()
        {
            arena.Enroll(bob);
            Warrior actual = arena.Warriors.ToArray()[0];
            Assert.AreEqual(1,arena.Count);
            Assert.AreSame(bob,actual);
        }
        [Test]
        public void EnrollThrowsForSameName()
        {
            arena.Enroll(bob);
            InvalidOperationException exOperation = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Enroll(bob);
            },"doesnt throw when dublicate name");
            Assert.AreEqual("Warrior is already enrolled for the fights!",exOperation.Message,"wrong msg");
        }
        [TestCase("Bob","Peter","There is no fighter with name Peter enrolled for the fights!")]
        [TestCase("Peter","John","There is no fighter with name Peter enrolled for the fights!")]
        [TestCase("David","Peter","There is no fighter with name Peter enrolled for the fights!")]
        public void FightThrowsForMissingWarriors(string attackerName,string defenderName,string exMsg)
        {
            arena.Enroll(bob);
            arena.Enroll(john);
            InvalidOperationException exOperation = Assert.Throws<InvalidOperationException>(() =>
            {
                arena.Fight(attackerName,defenderName);
            },"doesnt throw for missing warriors");
            Assert.AreEqual(exMsg,exOperation.Message,"wrong msg");
        }
        [Test]
        public void FightValidCase()
        {
            arena.Enroll(bob);
            arena.Enroll(john);
            arena.Fight(bob.Name,john.Name);
            Assert.AreEqual(25,bob.HP);
            Assert.AreEqual(25,john.HP);
        }
    }
}
