using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void Athlete_Ctor_Valid()
        {
            Athlete athlete = new Athlete("bob");
            Assert.That(athlete.FullName,Is.EqualTo("bob"));
            Assert.That(athlete.IsInjured,Is.EqualTo(false));
        }
        [Test]
        public void Gym_Ctor_Valid()
        {
            Gym gym = new Gym("gym",5);
            Assert.That(gym.Name,Is.EqualTo("gym"));
            Assert.That(gym.Capacity,Is.EqualTo(5));
            Assert.That(gym.Count,Is.EqualTo(0));
        }
        [Test]
        public void Gym_Name_ThrowsFor_NullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(null,5);
            });
        }
        [Test]
        public void Gym_Capacity_ThrowsFor_Negative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("gym",-1);
            });
        }
        [Test]
        public void Gym_AddAthlete_ThrowsFor_Full()
        {
            Gym gym = new Gym("gym",1);
            Athlete athlete = new Athlete("bob");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete);
            });
        }
        [Test]
        public void Gym_RemoveAthlete_ThrowsFor_NotFound()
        {
            Gym gym = new Gym("gym",1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("bob");
            });
        }
        [Test]
        public void Gym_RemoveAthlete_Valid()
        {
            Gym gym = new Gym("gym",1);
            Athlete athlete = new Athlete("bob");
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("bob");
            Assert.That(gym.Count,Is.EqualTo(0));
        }
        [Test]
        public void Gym_InjureAthlete_ThrowsFor_NotFound()
        {
            Gym gym = new Gym("gym",1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.InjureAthlete("bob");
            });
        }
        [Test]
        public void Gym_InjureAthlete_Valid()
        {
            Gym gym = new Gym("gym",1);
            Athlete athlete = new Athlete("bob");
            gym.AddAthlete(athlete);
            Athlete actual = gym.InjureAthlete("bob");
            Assert.That(actual,Is.SameAs(athlete));
            Assert.That(actual.IsInjured,Is.EqualTo(true));
        }
        [Test]
        public void Gym_Report_Valid()
        {
            Gym gym = new Gym("gym",3);
            Athlete athlete = new Athlete("bob");
            Athlete another = new Athlete("kim");
            Athlete injured = new Athlete("john");
            string expected = "Active athletes at gym: bob, kim";
            gym.AddAthlete(athlete);
            gym.AddAthlete(injured);
            gym.AddAthlete(another);
            gym.InjureAthlete("john");
            string actual = gym.Report();
            Assert.That(actual,Is.EqualTo(expected));
        }
    }
}
