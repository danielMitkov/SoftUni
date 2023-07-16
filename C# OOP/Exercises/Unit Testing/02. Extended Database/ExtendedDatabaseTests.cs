namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private static Person[] GetPeople(int amount)
        {
            Person[] people = new Person[amount];
            for(int i = 0;i<people.Length;++i)
            {
                people[i] = new Person(i,i.ToString());
            }
            return people;
        }
        [Test]
        public void TestRemoveShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                new Database().Remove();
            },"Doesnt throw when removing from empty");
        }
        [Test]
        public void TestRemoveValidCase()
        {
            Person person1 = new Person(1,"Bob");
            Person person2 = new Person(2,"John");
            Database database = new(person1,person2);
            database.Remove();
            Assert.AreEqual(1,database.Count,"Count doesnt match");
            Assert.AreSame(person1,database.FindByUsername("Bob"),"Expected Bob obj");
        }
        [Test]
        public void TestAddThrowsForCount()
        {
            Database database = new(GetPeople(16));
            InvalidOperationException exOperation = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(new Person(17,"Bob"));
            },"Add doesnt throw when full");
            Assert.AreEqual("Array's capacity must be exactly 16 integers!",exOperation.Message,"Err msg not match");
        }
        [Test]
        public void TestAddThrowsForSameName()
        {
            Person bob = new Person(1,"Bob");
            Person bob2 = new Person(2,"Bob");
            Database database = new Database(bob);
            InvalidOperationException exOperation = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(bob2);
            },"Add doesnt throw when names repeat");
            Assert.AreEqual("There is already user with this username!",exOperation.Message,"Err msg not match");
        }
        [Test]
        public void TestAddThrowsForSameId()
        {
            Person bob = new Person(1,"Bob");
            Person john = new Person(1,"John");
            Database database = new Database(bob);
            InvalidOperationException exOperation = Assert.Throws<InvalidOperationException>(() =>
            {
                database.Add(john);
            },"Add doesnt throw when ids repeat");
            Assert.AreEqual("There is already user with this Id!",exOperation.Message,"Err msg not match");
        }
        [Test]
        public void TestAddValidCase()
        {
            Person bob = new Person(1,"Bob");
            Person john = new Person(2,"John");
            Database database = new();
            database.Add(bob);
            database.Add(john);
            Assert.AreSame(bob,database.FindById(1),"bob doesnt match");
            Assert.AreSame(john,database.FindById(2),"john doesnt match");
            Assert.AreEqual(2,database.Count);
        }
        [Test]
        public void TestAddRangeThrowsForCount()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Database database = new(GetPeople(17));
            },"doesnt throw when full");
        }
        [Test]
        public void TestAddRangeValidCase()
        {
            Person bob = new Person(1,"Bob");
            Person john = new Person(2,"John");
            Database database = new(bob,john);
            Assert.AreSame(bob,database.FindById(1),"bob doesnt match");
            Assert.AreSame(john,database.FindById(2),"john doesnt match");
            Assert.AreEqual(2,database.Count);
        }
        [Test]
        public void TestFindByUsernameThrowsForNull()
        {
            Person bob = new Person(1,"Bob");
            Database database = new(bob);
            ArgumentNullException exNull = Assert.Throws<ArgumentNullException>(() =>
            {
                database.FindByUsername("");
            },"doesnt throw for empty name");
            Assert.AreEqual("Username parameter is null!",exNull.ParamName,"Err msg not match");
        }
        [Test]
        public void TestFindByUsernameThrowsForNotFound()
        {
            Person bob = new Person(1,"Bob");
            Database database = new(bob);
            InvalidOperationException exNull = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindByUsername("John");
            },"doesnt throw for not found");
            Assert.AreEqual("No user is present by this username!",exNull.Message,"Err msg not match");
        }
        [Test]
        public void TestFindByUsernameValidCase()
        {
            Person bob = new Person(1,"Bob");
            Database database = new(bob);
            Person actual = database.FindByUsername("Bob");
            Assert.AreSame(bob,actual);
        }
        [Test]
        public void TestFindByIdThrowsForNegative()
        {
            Person bob = new Person(1,"Bob");
            Database database = new(bob);
            ArgumentOutOfRangeException exRange = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                database.FindById(-1);
            },"doesnt throw for negative id");
            Assert.AreEqual("Id should be a positive number!",exRange.ParamName,"Err msg not match");
        }
        [Test]
        public void TestFindByIdThrowsForNotFound()
        {
            Person bob = new Person(1,"Bob");
            Database database = new(bob);
            InvalidOperationException exOperation = Assert.Throws<InvalidOperationException>(() =>
            {
                database.FindById(2);
            },"doesnt throw for not found id");
            Assert.AreEqual("No user is present by this ID!",exOperation.Message,"Err msg not match");
        }
        [Test]
        public void TestFindByIdValidCase()
        {
            Person bob = new Person(1,"Bob");
            Database database = new(bob);
            Person actual = database.FindById(1);
            Assert.AreSame(bob,actual);
        }
    }
}