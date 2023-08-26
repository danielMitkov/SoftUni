using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace RobotFactory.Tests
{
    public class FactoryTests
    {
        [Test]
        public void Ctor_Valid()
        {
            Factory factory = new Factory("bob",5);
            Assert.AreEqual("bob",factory.Name);
            Assert.AreEqual(5,factory.Capacity);
            Assert.AreEqual(0,factory.Robots.Count);
            Assert.AreEqual(0,factory.Supplements.Count);
            Assert.IsInstanceOf(typeof(List<Robot>),factory.Robots);
            Assert.IsInstanceOf(typeof(List<Supplement>),factory.Supplements);
        }
        [Test]
        public void ProduceRobot_Unable()
        {
            Factory factory = new Factory("bob",0);
            string msg = "The factory is unable to produce more robots for this production day!";
            string actual = factory.ProduceRobot("model",4.121,9);
            Assert.AreEqual(msg,actual);
        }
        [Test]
        public void ProduceRobot_Valid()
        {
            Factory factory = new Factory("bob",1);
            Robot robot = new Robot("model",4.121,9);
            string msg = $"Produced --> {robot.ToString()}";
            string actual = factory.ProduceRobot("model",4.121,9);
            Assert.AreEqual(msg,actual);
            Assert.AreEqual(1,factory.Robots.Count);
            Assert.AreEqual("model",factory.Robots[0].Model);
            Assert.AreEqual(4.121,factory.Robots[0].Price);
            Assert.AreEqual(9,factory.Robots[0].InterfaceStandard);
            Assert.IsInstanceOf(typeof(Robot),factory.Robots[0]);
        }
        [Test]
        public void ProduceSupplement_Valid()
        {
            Factory factory = new Factory("fac",1);
            Supplement supplement = new Supplement("bob",4);
            string msg = "Supplement: bob IS: 4";
            string actual = factory.ProduceSupplement("bob",4);
            Assert.AreEqual("bob",factory.Supplements[0].Name);
            Assert.AreEqual(4,factory.Supplements[0].InterfaceStandard);
            Assert.IsInstanceOf(typeof(Supplement),factory.Supplements[0]);
            Assert.AreEqual(msg,actual);
            Assert.AreEqual(1,factory.Supplements.Count);
            
            //
        }
        [Test]
        public void UpgradeRobot_False()
        {
            Factory factory = new Factory("fac",4);
            Supplement supplement = new Supplement("sup",3);
            Robot robot = new Robot("model",2.121,9);
            robot.Supplements.Add(supplement);
            bool actual = factory.UpgradeRobot(robot,supplement);
            Assert.AreEqual(false,actual);
            robot.Supplements.Remove(supplement);
            bool actual2 = factory.UpgradeRobot(robot,supplement);
            Assert.AreEqual(false,actual);
        }
        [Test]
        public void UpgradeRobot_True()
        {
            Factory factory = new Factory("fac",4);
            Supplement supplement = new Supplement("sup",3);
            Robot robot = new Robot("model",2.121,3);
            bool actual = factory.UpgradeRobot(robot,supplement);
            Assert.AreEqual(true,actual);
            Assert.AreEqual(1,robot.Supplements.Count);
            Assert.AreSame(supplement,robot.Supplements[0]);
        }
        [Test]
        public void SellRobot_Valid()
        {
            Factory factory = new Factory("fac",4);
            Robot robot = new Robot("model",2.121,3);
            Robot robot2 = new Robot("model",3.121,3);
            Robot robot3 = new Robot("model",4.121,3);
            factory.Robots.Add(robot);
            factory.Robots.Add(robot2);
            factory.Robots.Add(robot3);
            Robot actual = factory.SellRobot(9999);
            Assert.AreSame(robot3,actual);
        }
        [Test]
        public void SellRobot_Null()
        {
            Factory factory = new Factory("fac",4);
            Robot actual = factory.SellRobot(9999);
            Assert.AreSame(null,actual);
        }
    }
}
