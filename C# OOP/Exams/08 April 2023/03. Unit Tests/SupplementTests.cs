using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace RobotFactory.Tests
{
    public class SupplementTests
    {
        [Test]
        public void Ctor_Valid()
        {
            Supplement supplement = new Supplement("bob",4);
            Assert.AreEqual("bob",supplement.Name);
            Assert.AreEqual(4,supplement.InterfaceStandard);
        }
        [Test]
        public void ToString_Valid()
        {
            Supplement supplement = new Supplement("bob",4);
            string msg = "Supplement: bob IS: 4";
            Assert.AreEqual(msg,supplement.ToString());
        }
    }
}
