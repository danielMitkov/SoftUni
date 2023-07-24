namespace Robots.Tests
{
    using System;
    using NUnit.Framework;
    public class RobotsTests
    {
        [Test]
        public void Robot_Ctor_Valid()
        {
            Robot robot = new Robot("bob",5);
            Assert.That(robot.Name,Is.EqualTo("bob"));
            Assert.That(robot.MaximumBattery.Equals(5));
            Assert.AreEqual(robot.Battery,5);
        }
        [Test]
        public void RobotManager_Ctor_Valid()
        {
            RobotManager manager = new RobotManager(3);
            Assert.AreEqual(3,manager.Capacity);
            Assert.AreEqual(0,manager.Count);
        }
        [Test]
        public void Capacity_ThrowsFor_Negative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager manager = new RobotManager(-1);
            });
        }
        [Test]
        public void Add_Valid()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("bob",5);
            manager.Add(robot);
            Assert.AreEqual(1,manager.Count);
        }
        [Test]
        public void Add_ThrowsFor_Duplicate()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("bob",5);
            string msg = "There is already a robot with name bob!";
            manager.Add(robot);
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(robot);
            });
            Assert.AreEqual(msg,ex.Message);
        }
        [Test]
        public void Add_ThrowsFor_Full()
        {
            RobotManager manager = new RobotManager(1);
            Robot bob = new Robot("bob",5);
            Robot kim = new Robot("kim",10);
            string msg = "Not enough capacity!";
            manager.Add(bob);
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Add(kim);
            });
            Assert.AreEqual(msg,ex.Message);
        }
        [Test]
        public void Remove_ThrowsFor_NotFound()
        {
            RobotManager manager = new RobotManager(1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Remove("bob");
            });
        }
        [Test]
        public void Remove_Valid()
        {
            RobotManager manager = new RobotManager(1);
            Robot bob = new Robot("bob",5);
            manager.Add(bob);
            manager.Remove("bob");
            Assert.AreEqual(0,manager.Count);
        }
        [Test]
        public void Work_ThrowsFor_NotFound()
        {
            RobotManager manager = new RobotManager(1);
            string msg = "Robot with the name bob doesn't exist!";
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("bob","?",5);
            });
            Assert.AreEqual(msg,ex.Message);
        }
        [Test]
        public void Work_ThrowsFor_LowBattery()
        {
            RobotManager manager = new RobotManager(1);
            Robot bob = new Robot("bob",5);
            string msg = "bob doesn't have enough battery!";
            manager.Add(bob);
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Work("bob","?",10000);
            });
            Assert.AreEqual(msg,ex.Message);
        }
        [Test]
        public void Work_Valid()
        {
            RobotManager manager = new RobotManager(1);
            Robot bob = new Robot("bob",5);
            manager.Add(bob);
            manager.Work("bob","?",2);
            Assert.AreEqual(3,bob.Battery);
        }
        [Test]
        public void Charge_ThrowsFor_NotFound()
        {
            RobotManager manager = new RobotManager(1);
            Assert.Throws<InvalidOperationException>(() =>
            {
                manager.Charge("bob");
            });
        }
        [Test]
        public void Charge_Valid()
        {
            RobotManager manager = new RobotManager(1);
            Robot bob = new Robot("bob",5);
            manager.Add(bob);
            manager.Work("bob","?",2);
            manager.Charge("bob");
            Assert.AreEqual(5,bob.Battery);
        }
    }
}
