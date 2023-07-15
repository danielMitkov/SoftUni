using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private readonly int hpPositive = 10;
        private readonly int hpZero = 0;
        private readonly int hpNegative = -1;
        private readonly int exp = 5;
        private Dummy dummyOk;
        private Dummy dummyOut;
        private Dummy dummyDead;
        [SetUp]
        public void SetUp()
        {
            dummyOk = new(hpPositive,exp);
            dummyOut = new(hpZero,exp);
            dummyDead = new(hpNegative,exp);
        }
        [Test]
        public void ConstructorAndPropertiesTest()
        {
            Assert.AreEqual(hpPositive,dummyOk.Health,"Cannot set Hp right!");
        }
        [Test]
        public void TakeAttackTest()
        {
            const int attack = 1;
            Assert.DoesNotThrow(() =>
            {
                dummyOk.TakeAttack(attack);
            },$"Throws ex even when alive with {dummyOk.Health} hp");
            Assert.AreEqual(hpPositive - attack,dummyOk.Health,"Doesnt decrease hp well!");
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummyOut.TakeAttack(attack);
            },$"Doesnt throw when hp is {hpZero}");
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummyDead.TakeAttack(attack);
            },$"Doesnt throw when hp is {hpNegative}");
        }
        [Test]
        public void GiveExperienceTest()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummyOk.GiveExperience();
            },$"Doesnt throw for positive hp dummy!");
            int expectedExp = dummyDead.GiveExperience();
            Assert.AreEqual(exp,expectedExp,"Doesnt give exp well!");
        }
        [TestCase(1,false)]
        [TestCase(0,true)]
        [TestCase(-1,true)]
        public void IsDeadTest(int hp,bool expected)
        {
            Dummy dummy = new Dummy(hp,0);
            bool result = dummy.IsDead();
            Assert.AreEqual(expected,result,$"Isnt giving correct state for {hp} hp");
        }
    }
}