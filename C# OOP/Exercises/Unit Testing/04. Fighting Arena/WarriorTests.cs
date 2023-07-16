namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Threading;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ConstructorValidCase()
        {
            Warrior warrior = new Warrior("Peter", 5, 10);
            Assert.AreEqual("Peter",warrior.Name);
            Assert.AreEqual(5,warrior.Damage);
            Assert.AreEqual(10,warrior.HP);
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NameThrowsForNullEmptyOrSpace(string name)
        {
            ArgumentException exArg = Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new(name,1,1);
            },$"doesnt throw for '{name}' name");
            Assert.AreEqual("Name should not be empty or whitespace!",exArg.Message,"wrong msg");
        }
        [TestCase(-1)]
        [TestCase(0)]
        public void DamageThrowsForLessOrZero(int damage)
        {
            ArgumentException exArg = Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new("Peter",damage,1);
            },$"doesnt throw for '{damage}' damage");
            Assert.AreEqual("Damage value should be positive!",exArg.Message,"wrong msg");
        }
        [Test]
        public void HpThrowsForLessThanZero()
        {
            ArgumentException exArg = Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new("Peter",1,-5);
            },$"doesnt throw for negative hp");
            Assert.AreEqual("HP should not be negative!",exArg.Message,"wrong msg");
        }
        [TestCase(29,100,"Your HP is too low in order to attack other warriors!")]
        [TestCase(30,100,"Your HP is too low in order to attack other warriors!")]
        [TestCase(100,29,"Enemy HP must be greater than 30 in order to attack him!")]
        [TestCase(100,30,"Enemy HP must be greater than 30 in order to attack him!")]
        public void AttackThrowsForWarriorsHpLessOr30(int attHp,int defHp,string exMsg)
        {
            Warrior attacker = new("Bob",35,attHp);
            Warrior defender = new("Peter",50,defHp);
            InvalidOperationException exOperation = Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            },$"doesnt throw for <=30 hp");
            Assert.AreEqual(exMsg,exOperation.Message,"wrong msg");
        }
        [Test]
        public void AttackThrowsForThisHpLessThanOtherDmg()
        {
            Warrior attacker = new("Bob",100,50);
            Warrior defender = new("Peter",51,100);
            InvalidOperationException exOperation = Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            },$"doesnt throw attacker hp less then defender dmg");
            Assert.AreEqual("You are trying to attack too strong enemy",exOperation.Message,"wrong msg");
        }
        [Test]
        public void AttackValidDoesntKill()
        {
            Warrior attacker = new("Bob",50,100);
            Warrior defender = new("Peter",25,75);
            attacker.Attack(defender);
            Assert.AreEqual(75,attacker.HP);
            Assert.AreEqual(25,defender.HP);
        }
        [Test]
        public void AttackValidKills()
        {
            Warrior attacker = new("Bob",100,100);
            Warrior defender = new("Peter",75,75);
            attacker.Attack(defender);
            Assert.AreEqual(25,attacker.HP);
            Assert.AreEqual(0,defender.HP);
        }
    }
}