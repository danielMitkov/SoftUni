namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private const string DEF_PRESENT_NAME = "Present name";
        private const double DEF_PRESENT_MAGIC = 10;

        private Present present;
        private Bag bag;

        [SetUp]
        public void Setup()
        {
            present = new Present(DEF_PRESENT_NAME,DEF_PRESENT_MAGIC);
            bag = new Bag();
            bag.Create(present);
        }
        [Test]
        public void Present_Ctor_Valid()
        {
            Present present = new Present("name",4);
            Assert.AreEqual("name",present.Name);
            Assert.AreEqual(4,present.Magic);
        }
        [Test]
        public void Bag_Ctor_Valid()
        {
            Bag bag = new Bag();
            Assert.AreEqual(0,bag.GetPresents().Count);
        }
        [Test]
        public void Create_Valid()
        {
            Bag bag = new Bag();
            Present present = new Present("name",4);
            string result = bag.Create(present);
            Assert.AreEqual(1,bag.GetPresents().Count);
            Assert.AreSame(present,bag.GetPresent("name"));
            Assert.AreEqual("Successfully added present name.",result);
        }
        [Test]
        public void Create_ThrowsFor_Null()
        {
            Bag bag = new Bag();
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }
        [Test]
        public void Create_ThrowsFor_Duplicate()
        {
            Bag bag = new Bag();
            Present present = new Present("name",4);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }
        [Test]
        public void Remove_True()
        {
            Bag bag = new Bag();
            Present present = new Present("name",4);
            bag.Create(present);
            bool isRemoved = bag.Remove(present);
            Assert.AreEqual(true,isRemoved);
            Assert.AreEqual(0,bag.GetPresents().Count);
        }
        [Test]
        public void Remove_False()
        {
            Bag bag = new Bag();
            Present present = new Present("name",4);
            bag.Create(present);
            bool isRemoved = bag.Remove(null);
            Assert.AreEqual(false,isRemoved);
            Assert.AreEqual(1,bag.GetPresents().Count);
        }
        [Test]
        public void GetPresentWithLeastMagic_Valid()
        {
            Bag bag = new Bag();
            Present present1 = new Present("name",40);
            bag.Create(present1);
            Present present2 = new Present("bob",4);
            bag.Create(present2);
            Present present = bag.GetPresentWithLeastMagic();
            Assert.AreSame(present2,present);
        }
    }
}
