using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private readonly int attack = 1;
        private readonly int durPositive = 1;
        private readonly int durZero = 0;
        private readonly int durNegative = -1;
        private Axe axeOk;
        private Axe axeDull;
        private Axe axeBroken;
        private Dummy dummyOk;
        [SetUp]
        public void SetUp()
        {
            axeOk = new Axe(attack,durPositive);
            axeDull = new Axe(attack,durZero);
            axeBroken = new Axe(attack,durNegative);
            dummyOk = new Dummy(10,10);
        }
        [Test]
        public void TestContructorAndProperties()
        {
            Assert.AreEqual(1,axeOk.AttackPoints,"Cannot set Attack!");
            Assert.AreEqual(1,axeOk.DurabilityPoints,"Cannot set Durability!");
        }
        [Test]
        public void TestAttack()
        {
            Assert.DoesNotThrow(() =>
            {
                axeOk.Attack(dummyOk);
            },$"Throws for valid durability {durPositive}");
            Assert.AreEqual(durPositive-1,axeOk.DurabilityPoints,"Doesnt decrease durability!");
            Assert.Throws<InvalidOperationException>(() =>
            {
                axeDull.Attack(dummyOk);
            },$"Doesnt throw err when durability {durZero}");
            Assert.Throws<InvalidOperationException>(() =>
            {
                axeBroken.Attack(dummyOk);
            },$"Doesnt throw err when durability {durNegative}");
        }
    }
}