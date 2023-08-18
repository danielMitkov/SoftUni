using NUnit.Framework;
using System;
namespace FootballTeam.Tests
{
    public class TeamTests
    {
        [Test]
        public void ConstructorValid()
        {
            FootballTeam team = new FootballTeam("team",15);
            Assert.That(team.Capacity,Is.EqualTo(15));
            Assert.That(team.Name,Is.EqualTo("team"));
            Assert.That(team.Players,Is.Not.EqualTo(null));
        }
        [TestCase("")]
        [TestCase(null)]
        public void NameThrowsForNullOrEmpty(string name)
        {
            string exMsg = "Name cannot be null or empty!";
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(name,15);
            });
            Assert.That(ex.Message,Is.EqualTo(exMsg));
        }
        [Test]
        public void CapacityThrowsForLessThan15()
        {
            string exMsg = "Capacity min value = 15";
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam("team",14);
            });
            Assert.That(ex.Message,Is.EqualTo(exMsg));
        }
        [Test]
        public void AddNewPlayerFullAndValidCases()
        {
            FootballTeam team = new FootballTeam("team",15);
            FootballPlayer player = new FootballPlayer("Bob",1,"Goalkeeper");
            string validMsg = "Added player Bob in position Goalkeeper with number 1";
            string fullMsg = "No more positions available!";
            for(int n = 15;n>0;--n)
            {
                string actualValidMsg = team.AddNewPlayer(player);
                Assert.That(actualValidMsg,Is.EqualTo(validMsg));
            }
            string actualFullMsg = team.AddNewPlayer(player);
            Assert.That(actualFullMsg,Is.EqualTo(fullMsg));
        }
        [Test]
        public void PickPlayerValid()
        {
            FootballTeam team = new FootballTeam("team",15);
            FootballPlayer player = new FootballPlayer("Bob",1,"Goalkeeper");
            team.AddNewPlayer(player);
            FootballPlayer actual = team.PickPlayer("Bob");
            Assert.That(actual,Is.SameAs(player));
        }
        [Test]
        public void PickPlayerNull()
        {
            FootballTeam team = new FootballTeam("team",15);
            FootballPlayer player = new FootballPlayer("Bob",1,"Goalkeeper");
            team.AddNewPlayer(player);
            FootballPlayer actual = team.PickPlayer("John");
            Assert.That(actual,Is.SameAs(null));
        }
        [Test]
        public void PlayerScoreValid()
        {
            FootballTeam team = new FootballTeam("team",15);
            FootballPlayer player = new FootballPlayer("Bob",5,"Goalkeeper");
            team.AddNewPlayer(player);
            string msg = "Bob scored and now has 1 for this season!";
            string actualMsg = team.PlayerScore(5);
            Assert.That(actualMsg,Is.EqualTo(msg));
        }
    }
}
