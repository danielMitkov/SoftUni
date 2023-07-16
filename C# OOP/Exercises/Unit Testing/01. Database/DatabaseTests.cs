namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private int[] ok = { 1,2,3 };
        private int[] full = Enumerable.Range(1,16).ToArray();
        private Database databaseOk;
        private Database databaseEmpty;
        private Database databaseFull;
        [SetUp]
        public void SetUp()
        {
            databaseOk = new(ok);
            databaseEmpty = new();
            databaseFull = new(full);
        }
        [Test]
        public void TestFetch()
        {
            int[] actual = databaseOk.Fetch();
            Assert.IsTrue(ok.SequenceEqual(actual),"sequences arent equal");
        }
        [Test]
        public void TestRemoveThrows()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                databaseEmpty.Remove();
            },"Remove doest throw when data is empty");
        }
        [Test]
        public void TestRemoveNormalCase()
        {
            databaseOk.Remove();
            int[] expected = ok.Take(ok.Length - 1).ToArray();
            int[] actual = databaseOk.Fetch();
            Assert.IsTrue(expected.SequenceEqual(actual),"sequences arent equal");
            Assert.AreEqual(expected.Length,databaseOk.Count,"count doesnt match");
        }
        [Test]
        public void TestAddThrows()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                databaseFull.Add(1);
            },"Add doest throw when data is full");
        }
        [Test]
        public void TestAddNormalCase()
        {
            int num = 1;
            databaseOk.Add(num);
            int[] expected = ok.Concat(new int[] { num }).ToArray();
            int[] actual = databaseOk.Fetch();
            Assert.IsTrue(expected.SequenceEqual(actual),"sequences arent equal");
            Assert.AreEqual(expected.Length,databaseOk.Count,"count doesnt match");
        }
    }
}
