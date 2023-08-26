using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace RobotFactory.Tests
{
    public class RobotTests
    {
        [Test]
        public void Ctor_Valid()
        {
            Robot robot = new Robot("model",4.121,9);
            Assert.AreEqual("model",robot.Model);
            Assert.AreEqual(4.121,robot.Price);
            Assert.AreEqual(9,robot.InterfaceStandard);
            Assert.AreEqual(0,robot.Supplements.Count);
            Assert.IsInstanceOf(typeof(List<Supplement>),robot.Supplements);
        }
        [Test]
        public void ToString_Valid()
        {
            Robot robot = new Robot("model",4.121,9);
            string msg = "Robot model: model IS: 9, Price: 4.12";
            Assert.AreEqual(msg,robot.ToString());
        }
    }
}
