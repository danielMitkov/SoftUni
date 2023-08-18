using NUnit.Framework;
using System;
namespace FootballTeam.Tests
{
    public class PlayerTests
    {
        [Test]
        public void ConstructorValid()
        {
            FootballPlayer player = new FootballPlayer("Bob",1,"Goalkeeper");
            Assert.That(player.Name,Is.EqualTo("Bob"));
            Assert.That(player.PlayerNumber,Is.EqualTo(1));
            Assert.That(player.Position,Is.EqualTo("Goalkeeper"));
            Assert.That(player.ScoredGoals,Is.EqualTo(0));
        }
        [TestCase("")]
        [TestCase(null)]
        public void NameIsThrowsForNullOrEmpty(string name)
        {
            string expectedExMsg = "Name cannot be null or empty!";
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer(name,1,"Goalkeeper");
            },"doesnt throw for null or empty name");
            Assert.That(ex.Message,Is.EqualTo(expectedExMsg));
        }
        [TestCase(0)]
        [TestCase(22)]
        public void PlayerNumberThrowsForInvalidRange(int number)
        {
            string expectedExMsg = "Player number must be in range [1,21]";
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer("Bob",number,"Goalkeeper");
            },"doesnt throw for invalid range");
            Assert.That(ex.Message,Is.EqualTo(expectedExMsg));
        }
        [Test]
        public void PositionThrowsForInvalid()
        {
            string expectedExMsg = "Invalid Position";
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                FootballPlayer player = new FootballPlayer("Bob",1,null);
            },"doesnt throw for invalid position");
            Assert.That(ex.Message,Is.EqualTo(expectedExMsg));
        }
        [Test]
        public void ScoreValid()
        {
            FootballPlayer player = new FootballPlayer("Bob",1,"Goalkeeper");
            player.Score();
            Assert.That(player.ScoredGoals,Is.EqualTo(1));
        }
    }
}