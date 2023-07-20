using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault vault;
        [SetUp]
        public void Setup()
        {
            item = new Item("bob","id");
            vault = new BankVault();
        }
        [Test]
        public void Item_Ctor_Valid()
        {
            item = new Item("bob","id");
            Assert.AreEqual("bob",item.Owner);
            Assert.AreEqual("id",item.ItemId);
        }
        [Test]
        public void AddItem_Valid()
        {
            string msg = vault.AddItem("A1",item);
            Assert.AreSame(item,vault.VaultCells["A1"]);
            Assert.AreEqual("Item:id saved successfully!",msg);
        }
        [Test]
        public void AddItem_ThrowsFor_CellNotFound()
        {
            var ex = Assert.Throws<ArgumentException>(()=> vault.AddItem("zzz",item));
            Assert.AreEqual("Cell doesn't exists!",ex.Message);
        }
        [Test]
        public void AddItem_ThrowsFor_CellAlreadyTaken()
        {
            vault.AddItem("A1",item);
            var ex = Assert.Throws<ArgumentException>(() => vault.AddItem("A1",null));
            Assert.AreEqual("Cell is already taken!",ex.Message);
        }
        [Test]
        public void AddItem_ThrowsFor_ItemAlreadyExists()
        {
            vault.AddItem("A1",item);
            var ex = Assert.Throws<InvalidOperationException>(() => vault.AddItem("A2",item));
            Assert.AreEqual("Item is already in cell!",ex.Message);
        }
        [Test]
        public void RemoveItem_ThrowsFor_CellNotFound()
        {
            var ex = Assert.Throws<ArgumentException>(() => vault.RemoveItem("zzz",item));
            Assert.AreEqual("Cell doesn't exists!",ex.Message);
        }
        [Test]
        public void RemoveItem_ThrowsFor_WrongItem()
        {
            vault.AddItem("A1",item);
            Item item2 = new Item("kim","4");
            var ex = Assert.Throws<ArgumentException>(() => vault.RemoveItem("A1",item2));
            Assert.AreEqual("Item in that cell doesn't exists!",ex.Message);
        }
        [Test]
        public void RemoveItem_Valid()
        {
            vault.AddItem("A1",item);
            string msg = vault.RemoveItem("A1",item);
            Assert.AreEqual("Remove item:id successfully!",msg);
            Assert.AreEqual(null,vault.VaultCells["A1"]);
        }
    }
}
