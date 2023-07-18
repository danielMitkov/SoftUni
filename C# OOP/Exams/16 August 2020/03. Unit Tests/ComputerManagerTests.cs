using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    [TestFixture]
    public class Tests
    {
        private const string _manufacturer = "bob";
        private const string _model = "S10";
        private const decimal _price = 3.4m;
        private Computer computer;
        private ComputerManager computerManager;
        [SetUp]
        public void Setup()
        {
            computer = new Computer(_manufacturer,_model,_price);
            computerManager = new ComputerManager();
        }
        [Test]
        public void Computer_Ctor_Valid()
        {
            computer = new Computer(_manufacturer,_model,_price);
            Assert.AreEqual(_manufacturer,computer.Manufacturer);
            Assert.AreEqual(_model,computer.Model);
            Assert.AreEqual(_price,computer.Price);
        }
        [Test]
        public void ComputerManager_Ctor_Valid()
        {
            computerManager = new ComputerManager();
            Assert.AreEqual(0,computerManager.Count);
            Assert.IsInstanceOf<IReadOnlyCollection<Computer>>(computerManager.Computers);
        }
        [Test]
        public void AddComputer_Valid()
        {
            computerManager.AddComputer(computer);
            Assert.AreEqual(1,computerManager.Count);
            Assert.AreSame(computer,computerManager.Computers.First());
        }
        [Test]
        public void AddComputer_ThrowsFor_Null()
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.AddComputer(null));
        }
        [Test]
        public void AddComputer_ThrowsFor_Duplicate()
        {
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(()=> computerManager.AddComputer(computer));
        }
        [Test]
        public void RemoveComputer_Valid()
        {
            computerManager.AddComputer(computer);
            Computer actual = computerManager.RemoveComputer(_manufacturer,_model);
            Assert.AreSame(computer,actual);
            Assert.AreEqual(0,computerManager.Count);
        }
        [Test]
        public void RemoveComputer_ThrowsFor_NotFound()
        {
            Assert.Throws<ArgumentException>(() => computerManager.RemoveComputer("zz","zzz"));
        }
        [Test]
        public void GetComputer_Valid()
        {
            computerManager.AddComputer(computer);
            Computer actual = computerManager.GetComputer(_manufacturer,_model);
            Assert.AreSame(computer,actual);
            Assert.AreEqual(1,computerManager.Count);
            Assert.AreSame(computer,computerManager.Computers.First());
        }
        [Test]
        public void GetComputer_ThrowsFor_NotFound()
        {
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer(_manufacturer,_model));
            computerManager.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer(_manufacturer,"not"));
            Assert.Throws<ArgumentException>(() => computerManager.GetComputer("not",_model));
        }
        [TestCase(null,"zzz")]
        [TestCase("zzz",null)]
        public void GetComputer_ThrowsFor_Null(string manufacturer,string model)
        {
            Assert.Throws<ArgumentNullException>(() => computerManager.GetComputer(manufacturer,model));
        }
        [Test]
        public void GetComputersByManufacturer_Valid()
        {
            Computer computer2 = new Computer("kim",_model,_price);
            computerManager.AddComputer(computer);
            computerManager.AddComputer(computer2);
            var collection = computerManager.GetComputersByManufacturer(_manufacturer);
            Assert.AreEqual(1,collection.Count);
            Assert.AreSame(computer,collection.First());
        }
        [Test]
        public void GetComputersByManufacturer_ThrowsFor_Null()
        {
            Assert.Throws<ArgumentNullException>(()=>computerManager.GetComputersByManufacturer(null));
        }
    }
}
